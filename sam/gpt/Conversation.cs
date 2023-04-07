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
using System.Text.RegularExpressions;

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
            this.userPersonality = userPersonality;
            this.roleEnforcer = roleEnforcer;
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
            chatHistory.Clear();
            try
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
                else
                {
                    Console.WriteLine("The database file does not exist.");
                }
            }
            catch (SqliteException ex)
            {
                Console.WriteLine($"An error occurred while loading chat history: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

            return chatHistory;
        }


        public async Task<List<ChatMessage>> LoadTopMessages(string searchParameter)
        {
            var topMessages = new List<ChatMessage>();
            var connectionString = "Data Source=chat.db";


            var sqlBuilder = "SELECT Role, Content FROM ChatMemory WHERE AgentId = @AgentId";
            List<string> dbString = new List<string>();

            using (var connection = new SqliteConnection(connectionString))
            using (var command = new SqliteCommand(sqlBuilder, connection))
            {
                connection.Open();

                // Set command parameters
                command.Parameters.AddWithValue("@AgentId", agentId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dbString.Add(reader.GetString(1).ToLower());
                    }
                }
            }
            if (dbString.Count > 0)
            {

                List<string> filteredSearch = SearchList(dbString, searchParameter.ToLower(), 20);
                StringBuilder combinedResults = new StringBuilder();
                foreach (string filter in filteredSearch)
                {
                    combinedResults.Append(filter + ", ");
                }
                if (combinedResults.Length > 0)
                {
                    combinedResults.Length -= 2; // Remove the last comma and space
                    if (combinedResults.ToString() != "")
                    {
                        var chatMessage = new ChatMessage("user", "Tiedät tämän: " + combinedResults.ToString() + "");
                        topMessages.Add(chatMessage);
                    }
                }
            }

            return topMessages;
        }



        public static List<string> SearchList(List<string> inputList, string searchSentence, int surroundingSentences)
        {
            // Combine the input list into a single text.
            string text = string.Join(" ", inputList);

            // Split the text into individual sentences.
            string[] sentences = text.Split(new char[] { '.', '?', '!', ';' });

            string[] searchWords = searchSentence.Split(' ');

            Dictionary<int, int> sentenceCounts = new Dictionary<int, int>();
            for (int i = 0; i < sentences.Length; i++)
            {
                string sentence = sentences[i];
                int count = 0;
                foreach (string word in searchWords)
                {
                    if (Regex.IsMatch(sentence, @"\b" + word + @"\b", RegexOptions.IgnoreCase))
                    {
                        count++;
                    }
                }
                if (count > 0)
                {
                    sentenceCounts[i] = count;
                }
            }

            var topMatchIndex = sentenceCounts.OrderByDescending(x => x.Value)
                                              .ThenBy(x => x.Key)
                                              .FirstOrDefault().Key;

            var topMatches = sentences.Skip(topMatchIndex)
                                      .Take(surroundingSentences + 1)
                                      .ToList();

            return topMatches;
        }




        // Method to start a conversation by taking a user's input and returning a response.
        public async Task<List<string>> StartConversation(string userInput, bool requiresResponse, float focus)
        {
            List<string> convResponse = new List<string> { "Sorry, I don't understand." };
            List<ChatMessage> convMessages = new List<ChatMessage>();
            List<ChatMessage> systemMemory = await LoadTopMessages(userInput);

            // Add system and user personalities to conversation
            if (systemPersonality.Count > 0)
            {
                systemPersonality.ForEach(per => convMessages.Add(new ChatMessage("system", per)));
            }


            // Add system memory 
            if (systemMemory.Count > 0)
            {
                //systemMemory.ForEach(convMessages.Add);
                string memory = "";
                foreach (ChatMessage message in systemMemory)
                {
                    memory = message.Content + " ";
                }
                if (userPersonality.Count > 0)
                {
                    userPersonality.ForEach(per => convMessages.Add(new ChatMessage("user", per + " " + memory)));
                }

            }
            else
            {
                if (userPersonality.Count > 0)
                {
                    userPersonality.ForEach(per => convMessages.Add(new ChatMessage("user", per)));
                }
            }


            List<ChatMessage> messagesToAdd = new List<ChatMessage>();
            int totalLength = 0;

            // Add the most recent messages to the messagesToAdd list in reverse order
            for (int i = chatHistory.Count - 1; i >= 0; i--)
            {
                ChatMessage message = chatHistory[i];
                if (totalLength + message.Content.Length > 2500)
                {
                    break;
                }
                messagesToAdd.Add(message);
                totalLength += message.Content.Length;
            }

            // Reverse the order of the messagesToAdd list so that the messages are in chronological order
            messagesToAdd.Reverse();

            // Add the messages from messagesToAdd to convMessages
            messagesToAdd.ForEach(convMessages.Add);



            //chatHistory.ForEach(convMessages.Add);

            // Save user input and add to conversation messages
            ChatMessage cmessage = new ChatMessage("user", userInput);
            SaveChatMessage(cmessage);
            convMessages.Add(cmessage);
            chatHistory.Add(cmessage);

            // Add role enforcer to conversation
            if (chatHistory.Count > 0)
            {
                roleEnforcer.ForEach(per => convMessages.Add(new ChatMessage("user", per)));
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
                    systemMemory.ForEach(per => convResponse.Add(per.Content));

                    completionResult.Choices.ForEach(choises =>
                    {
                        convResponse.Add(choises.Message.Content);
                        ChatMessage npcmessage = new ChatMessage("assistant", choises.Message.Content);
                        chatHistory.Add(npcmessage);
                        SaveChatMessage(npcmessage);
                    });

                    return convResponse;
                }

                return convResponse;
            }
            else
            {
                return new List<string>();
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

