using OauthAttempt.Oauth;

namespace OauthAttempt;

public class ZohoInteractionService
{
    private readonly string RefreshToken;
    private OauthToken? _oauthToken { get; set; }
    
    public ZohoInteractionService(IOauthConfig oauthConfig)
    {
        RefreshToken = oauthConfig.RefreshToken;
    }
}
