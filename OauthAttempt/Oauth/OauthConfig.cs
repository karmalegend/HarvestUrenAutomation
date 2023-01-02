using Microsoft.Extensions.Configuration;

namespace OauthAttempt.Oauth;

public class OauthConfig : IOauthConfig
{
    private const string CONFIG_PREFIX = "ZohoSecrets";
    
    public string RefreshToken { get; init; }
    public string ClientId { get; init; }
    public string ClientSecret { get; init; }

    public OauthConfig(IConfiguration configuration)
    {
        RefreshToken = configuration[$"{CONFIG_PREFIX}:RefreshToken"];
        ClientId = configuration[$"{CONFIG_PREFIX}:ClientId"];
        ClientSecret = configuration[$"{CONFIG_PREFIX}:ClientSecret"];
    }
}
