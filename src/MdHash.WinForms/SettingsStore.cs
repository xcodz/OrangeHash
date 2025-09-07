using System;
using System.Collections.Generic;
using System.IO;

namespace MdHash.WinForms
{
    internal sealed class SettingsStore
    {
        public bool MD5 { get; set; } = true;
        public bool SHA1 { get; set; } = true;
        public bool SHA256 { get; set; } = true;
        public bool SHA384 { get; set; } = false;
        public bool SHA512 { get; set; } = false;

        private string FilePath
        {
            get
            {
                var dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "OrangeHash");
                Directory.CreateDirectory(dir);
                return Path.Combine(dir, "settings.ini");
            }
        }

        public void Load()
        {
            var path = FilePath;
            if (!File.Exists(path)) return;
            var dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (var line in File.ReadAllLines(path))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var idx = line.IndexOf('=');
                if (idx <= 0) continue;
                var key = line.Substring(0, idx).Trim();
                var val = line.Substring(idx + 1).Trim();
                dict[key] = val;
            }

            MD5 = GetBool(dict, nameof(MD5), MD5);
            SHA1 = GetBool(dict, nameof(SHA1), SHA1);
            SHA256 = GetBool(dict, nameof(SHA256), SHA256);
            SHA384 = GetBool(dict, nameof(SHA384), SHA384);
            SHA512 = GetBool(dict, nameof(SHA512), SHA512);
        }

        public void Save()
        {
            var lines = new[]
            {
                $"{nameof(MD5)}={MD5}",
                $"{nameof(SHA1)}={SHA1}",
                $"{nameof(SHA256)}={SHA256}",
                $"{nameof(SHA384)}={SHA384}",
                $"{nameof(SHA512)}={SHA512}",
                
            };
            File.WriteAllLines(FilePath, lines);
        }

        private static bool GetBool(Dictionary<string, string> dict, string key, bool defaultValue)
        {
            if (dict.TryGetValue(key, out var v))
            {
                if (bool.TryParse(v, out var b)) return b;
                if (string.Equals(v, "1", StringComparison.OrdinalIgnoreCase)) return true;
                if (string.Equals(v, "0", StringComparison.OrdinalIgnoreCase)) return false;
            }
            return defaultValue;
        }
    }
}
