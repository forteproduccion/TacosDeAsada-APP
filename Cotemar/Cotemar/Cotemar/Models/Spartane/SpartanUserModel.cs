using Newtonsoft.Json;
using System.Collections.Generic;

namespace Cotemar.Models.Spartane
{
    public class SpartanUserListModel
    {
        [JsonProperty("Spartan_Users")]
        public List<Spartan_User> SpartanUsers { get; set; }

        [JsonProperty("RowCount")]
        public long RowCount { get; set; }
    }
    public class Spartan_User
    {
        [JsonProperty("Id_User")]
        public long IdUser { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Role")]
        public long? Role { get; set; }

        [JsonProperty("Image")]
        public long? Image { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Status")]
        public long? Status { get; set; }

        [JsonProperty("Username")]
        public string Username { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }
    }
}
