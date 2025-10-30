using Iron_Mountain_Coding_Challenge.Models;
using Newtonsoft.Json;
using System.IO;

namespace Iron_Mountain_Coding_Challenge.Repository
{
    public class MessageProvider : IMessageProvider
    {
        public ApplicationMessages Messages { get; private set; }

        public MessageProvider()
        {
            var json = File.ReadAllText("..\\..\\Utilities\\POCO\\messages.json");
            Messages = JsonConvert.DeserializeObject<ApplicationMessages>(json);
        }
    }
}
