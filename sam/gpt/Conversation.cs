using OpenAI.GPT3.Managers;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using FastColoredTextBoxNS;
using SQLitePCL;

namespace sam.gpt
{
    // This is a class for a conversation, which holds the SDK instance and a list of system personalities.

    internal class Conversation
    {
        private readonly OpenAIService sdk;
        private readonly List<string> systemPersonality;

        public List<string> userPersonality { get; private set; }
        public List<string> roleEnforcer { get; private set; }
        public string agentId { get; private set; }
        public float temperature { get; private set; }

        // Create a list to hold chat messages
        public List<ChatMessage> chatHistory = new List<ChatMessage>();

        // Constructor for Conversation class that takes an API key and a list of system personalities as input.
        public Conversation(string apiKey, List<string> systemPersonality, List<string> userPersonality, List<string> roleEnforcer, string agentId, float focus)
        {
            // Initialize the SQLitePCLRaw library
            Batteries.Init();

            sdk = new OpenAIService(new OpenAiOptions()
            {
                ApiKey = apiKey
            });
            this.systemPersonality = systemPersonality;
            this.userPersonality= userPersonality;
            this.roleEnforcer= roleEnforcer;
            this.agentId = agentId;
            this.temperature = focus;
            CreateTable();
            CreateMemoryTable();
            LoadChatHistory();
        }
        static void CreateMemoryTable()
        {
            try
            {
                if (!File.Exists("chat.db"))
                {
                    // Create a new database file if it doesn't exist
                    File.Create("chat.db");
                }

                // Connect to the database
                using (var connection = new SqliteConnection("Data Source=chat.db"))
                {
                    // Open the connection
                    connection.Open();

                    // Create the ChatHistory table if it doesn't exist
                    string createsql = @"CREATE TABLE IF NOT EXISTS ChatMemory (id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, AgentId TEXT, Role TEXT, Content TEXT)";
                    using (var cmd = new SqliteCommand(createsql, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Close the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating database: {ex.Message}");
            }
        }

        static void CreateTable()
        {
            try
            {
                if (!File.Exists("chat.db"))
                {
                    // Create a new database file if it doesn't exist
                    File.Create("chat.db");
                }

                // Connect to the database
                using (var connection = new SqliteConnection("Data Source=chat.db"))
                {
                    // Open the connection
                    connection.Open();

                    // Create the ChatHistory table if it doesn't exist
                    string createsql = @"CREATE TABLE IF NOT EXISTS ChatHistory (id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, AgentId TEXT, Role TEXT, Content TEXT)";
                    using (var cmd = new SqliteCommand(createsql, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Close the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating database: {ex.Message}");
            }
        }
        public void ClearChatHistory()
        {
            if (File.Exists("chat.db"))
            {
                using (var connection = new SqliteConnection("Data Source=chat.db"))
                {
                    connection.Open();

                    var command = new SqliteCommand();
                    command.Connection = connection;
                    command.CommandText = "delete from ChatHistory where AgentId = @AgentId";
                    command.Parameters.AddWithValue("@AgentId", agentId);
                    command.ExecuteNonQuery();
                }
            }
            chatHistory.Clear();
        }

        public void SaveChatMessage(ChatMessage chatMessage)
        {
            if (File.Exists("chat.db"))
            {
                using (var connection = new SqliteConnection("Data Source=chat.db"))
                {
                    connection.Open();

                    var command = new SqliteCommand();
                    command.Connection = connection;
                    command.CommandText = "insert into ChatHistory(AgentId, Role, Content) values (@AgentId, @Role, @Content)";
                    command.Parameters.AddWithValue("@AgentId", agentId);
                    command.Parameters.AddWithValue("@Role", chatMessage.Role);
                    command.Parameters.AddWithValue("@Content", chatMessage.Content);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<ChatMessage> LoadChatHistory()
        {

            if (File.Exists("chat.db"))
            {
                using (var connection = new SqliteConnection("Data Source=chat.db"))
                {
                    connection.Open();

                    var command = new SqliteCommand();
                    command.Connection = connection;
                    command.CommandText = "select Role, Content from ChatHistory where AgentId = @AgentId order by id";
                    command.Parameters.AddWithValue("@AgentId", agentId);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ChatMessage chatMessage = new ChatMessage((string)reader["Role"], (string)reader["Content"]);
                            chatHistory.Add(chatMessage);
                        }
                    }
                }
            }
            return chatHistory;
        }

        public List<ChatMessage> LoadTopMessages(string searchParameter)
        {
            var topMessages = new List<ChatMessage>();
            var connectionString = "Data Source=chat.db";
            var agentIdParam = "@AgentId";
            var limit = 5;

            // Build the SQL command with LIKE or LIKE %query%
            var searchWords = searchParameter.Split(' ');
            var sqlBuilder = new StringBuilder("SELECT Role, Content FROM ChatMemory WHERE AgentId = " + agentIdParam + " AND (");

            for (int i = 0; i < searchWords.Length; i++)
            {
                if (i > 0)
                {
                    sqlBuilder.Append(" OR ");
                }
                sqlBuilder.Append("Content LIKE '%' || @SearchParam" + i + " || '%'");
            }

            sqlBuilder.Append(") ORDER BY id desc LIMIT " + limit);

            using (var connection = new SqliteConnection(connectionString))
            using (var command = new SqliteCommand(sqlBuilder.ToString(), connection))
            {
                connection.Open();

                // Set command parameters
                command.Parameters.AddWithValue(agentIdParam, agentId);
                for (int i = 0; i < searchWords.Length; i++)
                {
                    command.Parameters.AddWithValue("@SearchParam" + i, searchWords[i]);
                }

                // Read results
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var chatMessage = new ChatMessage("user", "{tiedät nämä tiedot: " + reader.GetString(1) + "}");
                        topMessages.Add(chatMessage);
                    }
                }
            }

            return topMessages;
        }


        // Method to start a conversation by taking a user's input and returning a response.
        public async Task<List<string>> StartConversation(string userInput, bool requiresResponse, float focus)
        {
            List<string> convResponse = new List<string> { };
            convResponse.Add("Sorry, I don't understand.");
            List<ChatMessage> convMessages = new List<ChatMessage> { };
            List<ChatMessage> systemMemory = new List<ChatMessage> { };

            foreach(var usr in chatHistory)
            {
                if(usr.Role=="user") 
                {
                   systemMemory.AddRange(LoadTopMessages(userInput));
                }
            }
            

            systemMemory = LoadTopMessages(userInput);
            

            // Add system personality to conversation
            foreach (var per in systemPersonality)
            {
                ChatMessage chatMessage = new ChatMessage("system", per);
                convMessages.Add(chatMessage);
            }

            // Add user personality to conversation
            foreach (var per in userPersonality)
            {
                ChatMessage chatMessage = new ChatMessage("user", per);
                convMessages.Add(chatMessage);
            }

            // Add system memory to conversation
            foreach (var per in systemMemory)
            {
                convMessages.Add(per);
            }

            // Add conversation history to conversation
            foreach (var chis in chatHistory)
            {
                convMessages.Add(chis);
            }

            ChatMessage cmessage = new ChatMessage("user", userInput);
            SaveChatMessage(cmessage);
            convMessages.Add(cmessage);
            chatHistory.Add(cmessage);

            // Add role enforcer to conversation
            foreach (var per in roleEnforcer)
            {
                ChatMessage chatMessage = new ChatMessage("user", per);
                convMessages.Add(chatMessage);
            }

            if (requiresResponse)
            {
                // Create a completion result using the SDK and the conversation messages
                var completionResult = await sdk.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest
                {
                    Messages = convMessages,
                    Model = Models.ChatGpt3_5Turbo0301,
                    Temperature = focus,
                });
                
                // If successful, return the response and add it to the chat history
                if (completionResult.Successful)
                {
                    convResponse.Clear();
                    // Add system memory to conversation
                    foreach (var per in systemMemory)
                    {
                        convResponse.Add(per.Content);
                    }

                    foreach (var choises in completionResult.Choices)
                    {
                        convResponse.Add(choises.Message.Content);
                        ChatMessage npcmessage = new ChatMessage("assistant", choises.Message.Content);
                        chatHistory.Add(npcmessage);
                        SaveChatMessage(npcmessage);
                    }

                    return convResponse;
                }
                
                return convResponse;
            }
            else
            {
                return new List<string> { };
            }
        }

        // Method to start a conversation by taking a user's input and returning a response.
        public async Task<List<string>> AnalyzeAudio(string audioFile)
        {
            List<string> convResponse = new List<string> { };
            convResponse.Add("Sorry, failed to analyze audio");

            var sampleFile = await File.ReadAllBytesAsync(audioFile);


            var audioResult = await sdk.Audio.CreateTranscription(new AudioCreateTranscriptionRequest
            {
                FileName = audioFile,
                File = sampleFile,
                Model = Models.WhisperV1,
                ResponseFormat = StaticValues.AudioStatics.ResponseFormat.VerboseJson
            });


            if (audioResult.Successful)
            {
                convResponse.Clear();
                convResponse.Add(audioResult.Text);
                ChatMessage npcmessage = new ChatMessage("assistant", audioResult.Text);
                chatHistory.Add(npcmessage);
                SaveChatMessage(npcmessage);
            }
            else
            {
                if (audioResult.Error == null)
                {
                    throw new Exception("Unknown Error");
                }

                Console.WriteLine($"{audioResult.Error.Code}: {audioResult.Error.Message}");
            }
            return convResponse;
        }
    }
}

