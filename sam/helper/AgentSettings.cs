namespace sam.helper
{

    public class AgentSettings
    {
        public string AgentName { get; set; }
        public string AgentID { get; set; }
        public string AgentPersonality { get; set; }
        public List<AgentSettings>? SlaveAgents { get; set; }
        public string SlaveAgentMessage { get; set; }
        public string AgentSystem { get; set; }
        public string AgentEnforcer { get; set; }
        public int AgentFocus { get; set; }
    }

}