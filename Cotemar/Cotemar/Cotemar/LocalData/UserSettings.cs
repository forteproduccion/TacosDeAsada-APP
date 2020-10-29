using Newtonsoft.Json;
using Cotemar.Api;
using Cotemar.Settings;
using Xamarin.Essentials;

namespace Cotemar.LocalData
{
    public static class UserSettings
    {
        #region Setters
        public static void SetLong(Key name, long value) => Preferences.Set($"{AppConfiguration.Values.NameApp}_{name}", value);

        public static void SetInteger(Key name, int value) => Preferences.Set($"{AppConfiguration.Values.NameApp}_{name}", value);

        public static void SetString(Key name, string value) => Preferences.Set($"{AppConfiguration.Values.NameApp}_{name}", value);

        public static void SetBoolean(Key name, bool value) => Preferences.Set($"{AppConfiguration.Values.NameApp}_{name}", value);

        public static void SetDouble(Key name, double value) => Preferences.Set($"{AppConfiguration.Values.NameApp}_{name}", value);

        public static void SetFloat(Key name, float value) => Preferences.Set($"{AppConfiguration.Values.NameApp}_{name}", value);
        #endregion

        #region Getters
        public static double GetDouble(Key name) => Preferences.Get($"{AppConfiguration.Values.NameApp}_{name}", (double)0);

        public static long GetLong(Key name) => Preferences.Get($"{AppConfiguration.Values.NameApp}_{name}", (long)0);

        public static int GetInteger(Key name) => Preferences.Get($"{AppConfiguration.Values.NameApp}_{name}", 0);

        public static float GetFloat(Key name) => Preferences.Get($"{AppConfiguration.Values.NameApp}_{name}", (float)0);

        public static string GetString(Key name) => Preferences.Get($"{AppConfiguration.Values.NameApp}_{name}", string.Empty);

        public static bool GetBoolean(Key name) => Preferences.Get(name.ToString(), false);
        #endregion

        public static void ClearUserSettings() => Preferences.Clear();

        public static AuthenticationToken AuthenticationToken
        {
            get
            {
                if (string.IsNullOrEmpty(GetString(Key.Token))) return null;
                var tokenModel = JsonConvert.DeserializeObject<AuthenticationToken>(GetString(Key.Token));
                return tokenModel;
            }
            set
            {
                if (value == null)
                {
                    SetString(Key.Token, string.Empty);
                    return;
                }
                var serializedToken = JsonConvert.SerializeObject(value);
                if (string.IsNullOrEmpty(GetString(Key.Token)) || GetString(Key.Token) != serializedToken)
                    SetString(Key.Token, serializedToken);
            }
        }
    }
    public enum Key
    {
        Username,
        Name,
        Token,
        Logged,
        Phone,
        Email,
        Identifier,
        Avatar,
        Role
    }
}


