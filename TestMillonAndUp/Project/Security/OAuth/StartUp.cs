/// <summary>
/// Straup Owin
/// </summary>

namespace OAuth
{
    using System;
    using Microsoft.Owin;
    using Microsoft.Owin.Security;
    using Microsoft.Owin.Security.Infrastructure;
    using Microsoft.Owin.Security.OAuth;
    using Owin;

    public class StartUp
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        /// <summary>
        /// Initialize method for the authentication system.
        /// </summary>
        /// <param name="app">Application builder interface.</param>
        public static void Initialize(IAppBuilder app)
        {
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new Provider(),
                AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(5),
                RefreshTokenProvider = new AuthenticationTokenProvider()
                {
                    OnCreate = CreateRefreshToken,
                    OnReceive = ReceiveRefreshToken,
                },
                AllowInsecureHttp = true
            };

            //app.UseOAuthBearerTokens(OAuthOptions);
        }

        /// <summary>
        /// Generates a new refresh token
        /// </summary>
        /// <param name="context">Authentication context</param>
        private static void CreateRefreshToken(AuthenticationTokenCreateContext context)
        {
            AuthenticationProperties refreshTokenProperties = new AuthenticationProperties(context.Ticket.Properties.Dictionary)
            {
                IssuedUtc = context.Ticket.Properties.IssuedUtc,
                ExpiresUtc = context.Ticket.Properties.IssuedUtc.Value.AddMinutes(300)
            };

            AuthenticationTicket refreshTokenTicket = new AuthenticationTicket(context.Ticket.Identity, refreshTokenProperties);

            OAuthOptions.RefreshTokenFormat.Protect(refreshTokenTicket);
            context.SetToken(context.SerializeTicket());
        }

        /// <summary>
        /// Receive and deserialize the token.
        /// </summary>
        /// <param name="context">Authentication token.</param>
        private static void ReceiveRefreshToken(AuthenticationTokenReceiveContext context)
        {
            context.DeserializeTicket(context.Token);
        }

    }
}
