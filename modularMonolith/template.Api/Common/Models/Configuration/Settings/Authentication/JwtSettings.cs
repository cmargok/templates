namespace template.Api.Common.Models.Configuration.Settings.Authentication
{
    public class JwtSettings
    {
        public required string Issuer { get; set; }
        public required string Audience { get; set; }
        public required string SecureKey { get; set; }
    }

   
}
