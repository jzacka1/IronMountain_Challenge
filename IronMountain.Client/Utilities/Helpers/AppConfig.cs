using Iron_Mountain_Coding_Challenge.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iron_Mountain_Coding_Challenge.Utilities.Helpers
{
    public static class AppConfig
    {
        public static AppMessages AppMessages { get; private set; }

        static AppConfig()
        {
            Load();
        }

        public static void Load()
        {
            var projectDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)
                          .Parent
                          .Parent
                          .FullName;
            var jsonPath = Path.Combine(projectDir, "appsettings.json");
            var json = File.ReadAllText(jsonPath);
            AppMessages = JsonConvert.DeserializeObject<AppMessages>(json);
        }
    }
}
