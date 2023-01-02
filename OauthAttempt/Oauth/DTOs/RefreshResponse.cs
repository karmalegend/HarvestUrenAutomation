namespace OauthAttempt.Oauth.DTOs;

public class RefreshResponse
{
    public string access_token { get; set; }
    public string api_domain { get; set; }
    public string token_type { get; set; }
    public int expires_in { get; set; }
}

