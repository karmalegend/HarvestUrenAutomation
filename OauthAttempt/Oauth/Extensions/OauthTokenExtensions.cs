namespace OauthAttempt.Oauth.Extensions;

public static class OauthTokenExtensions
{

    public static bool IsValid(this OauthToken? token)
    {
        return token != null && token.ExpireDate <= DateTime.Now.AddMinutes(-6);
    }
    
}
