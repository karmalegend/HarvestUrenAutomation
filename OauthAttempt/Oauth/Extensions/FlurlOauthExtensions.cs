using Flurl;
using Flurl.Http;

namespace OauthAttempt.Oauth.Extensions;

public static class FlurlOauthExtensions
{
    public static IFlurlRequest DoMyThing(this IFlurlRequest req) {
        // do something interesting with req.Settings, req.Headers, req.Url, etc.
        return req;
    }

    // keep these overloads DRY by constructing a Url and deferring to the above method
    public static IFlurlRequest DoMyThing(this Url url) => new FlurlRequest(url).DoMyThing();
    public static IFlurlRequest DoMyThing(this Uri uri) => new FlurlRequest(uri).DoMyThing();
    public static IFlurlRequest DoMyThing(this string url) => new FlurlRequest(url).DoMyThing();
}
