using System.Text.Json.Serialization;

namespace JwtAuthentication.Services.Models
{
    public class UserAccount
    {
        [JsonIgnore]
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }
}
