using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProPresenterRemote
{
    internal class ItemData
    {
        public string UUID { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
    internal class Config
    {
        public string Ip;
        public string Port;
        public ItemData BeforeServiceLook;
        public ItemData NormalLook;
        public ItemData BeforeServiceProp;
        public ItemData PipProp;
        public ItemData SpeakerNameLibrary;
        public ItemData SpeakerNamePresentation;
        public ItemData SpeakerNameLook;

        internal static Config ReadConfig()
        {
            var config = new Config();

            if (File.Exists("config.json"))
            {
                var configJson = File.ReadAllText("config.json");
                config = JsonConvert.DeserializeObject<Config>(configJson);
            }

            return config;
        }

        internal static void WriteConfig(Config config)
        {
            var configJson = JsonConvert.SerializeObject(config, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            Debug.WriteLine(configJson);
            File.WriteAllText("config.json", configJson);
        }
    }

   
}
