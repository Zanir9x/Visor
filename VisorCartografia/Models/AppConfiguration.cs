using System.Collections.Generic;

namespace VisorCartografia.Models
{
    public class AppConfiguration
    {
        public string App { get; set; }
        public string Key { get; set; }
        public string RefreshToken { get; set; }
        public Dictionary<string, string> Files { get; set; }
    }
}
