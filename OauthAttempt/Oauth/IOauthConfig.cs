namespace OauthAttempt.Oauth;

public interface IOauthConfig
{
    string RefreshToken { get; init; }
    string ClientId { get; init; }
    string ClientSecret { get; init; }
}
