using GTAVLogger;
using System;
using System.Configuration;

namespace GTAVConfigManager
{
    public class ConfigManager
    {
        private static Configuration Config = null;

        private static string GetConfigValueByKey(string key)
        {
            if (Config == null) return null;
            var setting = Config.AppSettings.Settings[key];
            if (setting == null) return null;
            return setting.Value;
        }

        public static void LoadConfig(string dllPath)
        {
            try
            {
                Config = ConfigurationManager.OpenExeConfiguration(dllPath);
                Logger.Log("Load config file success: " + dllPath);
                Logger.Log("Current config version is " + Version);
            }
            catch (Exception ex)
            {
                Logger.Error("Load config file error: " + ex.Message);
                Logger.Error("dllPath: " + dllPath);
            }
        }

        public static string Version
        {
            get
            {
                return GetConfigValueByKey("version");
            }
        }
    }
}
