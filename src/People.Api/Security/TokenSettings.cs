using System;

namespace People.Api.Security
{
    public class TokenSettings
    {
        public string Issuer { get; set; } = "people.com";
        public string Audience { get; set; } = "people.com";
        public DateTime IssuedAt { get; set; } = DateTime.UtcNow;
        public DateTime NotBefore { get; set; } = DateTime.UtcNow;
        public DateTime Expiration => DateTime.UtcNow.AddHours(1);
    }
}
