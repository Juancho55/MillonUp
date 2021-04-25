/// <summary>
/// Provider OAut2
/// </summary>

namespace OAuth
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Data;
    using Microsoft.Owin.Security;
    using Microsoft.Owin.Security.OAuth;
    using Services;
    using Services.Entity;
    using Services.Filters;
    using Services.Logic;

    /// <summary>
    /// Authorization server provider
    /// </summary>
    public class Provider : OAuthAuthorizationServerProvider
    {
        /// <summary>
        /// Create a new authentication property.
        /// </summary>
        /// <param name="scopes">The user roles.</param>
        /// <returns>An authentication property.</returns>
        /// public static AuthenticationProperties CreateProperties(string clientKey, string applicationKey, IEnumerable<Data.Context.Entities.Scope> scopes).
        public static AuthenticationProperties CreateProperties(List<string> scopes)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "scopes", string.Join(",", scopes.Select(s => s)) }
            };

            return new AuthenticationProperties(data);
        }

        /// <summary>
        /// Create a new authentication claim.
        /// </summary>
        /// <param name="claimsIdentity">The claim identity name.</param>
        /// <param name="user">The user.</param>
        /// <param name="scopes">The user scopes.</param>
        /// <returns>The claims identity for the ticket.</returns>        
        /// public static ClaimsIdentity CreateClaims(string claimsIdentity, string dataBase, Data.Context.Entities.User user, IEnumerable<Data.Context.Entities.Scope> scopes)
        public static ClaimsIdentity CreateClaims(string claimsIdentity, Services.Entity.Owner owner)
        {
            ClaimsIdentity authIdentity = new ClaimsIdentity(claimsIdentity);
            authIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, owner.IdOwner.ToString()));
            authIdentity.AddClaim(new Claim(ClaimTypes.Name, owner.Name));
            authIdentity.AddClaim(new Claim(ClaimTypes.Surname, owner.Address));
            authIdentity.AddClaim(new Claim(ClaimTypes.Thumbprint, owner.Photo.ToString()));
            authIdentity.AddClaim(new Claim(ClaimTypes.DateOfBirth, owner.BirthDate.ToString()));

            return authIdentity;
        }

        /// <summary>
        /// Validates the user credential and generate a new token if valid.
        /// </summary>
        /// <param name="context">Authentication context.</param>
        /// <returns>The awaited task (void).</returns>
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            if (!string.IsNullOrWhiteSpace(context.UserName))
            {
                Acctions acctions = new Acctions();
                TraslapEntityToDictionary traslapEntityToDictionary = new TraslapEntityToDictionary();
                OwnerService ownerService = new OwnerService(acctions, traslapEntityToDictionary);

                FilterOwner filterOwner = new FilterOwner()
                {
                    NickName = context.UserName,
                    Password = context.Password
                };

                Owner owner = ownerService.AuthUser(filterOwner);

                if (owner != null)
                {
                    List<string> items = new List<string>();
                    ClaimsIdentity authIdentity = CreateClaims("password", owner);
                    AuthenticationProperties properties = CreateProperties(items);
                    AuthenticationTicket ticket = new AuthenticationTicket(authIdentity, properties);

                    context.Validated(ticket);
                    return;
                }
            }

            context.SetError("invalid_grant", "The user type, user name or password is incorrect.");
        }

        /// <summary>
        /// Token endpoint.
        /// </summary>
        /// <param name="context">Authentication context.</param>
        /// <returns>The awaited task (void).</returns>
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        /// <summary>
        /// Refresh token validation and claims refresh.
        /// </summary>
        /// <param name="context">OWIN context.</param>
        /// <returns>The async task.</returns>
        public async override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            IEnumerable<Claim> claims = context.Ticket.Identity.Claims;
            if (int.TryParse(claims.FirstOrDefault(f => f.Type.Equals(ClaimTypes.NameIdentifier)).Value, out int userID))
            {
                Acctions acctions = new Acctions();
                TraslapEntityToDictionary traslapEntityToDictionary = new TraslapEntityToDictionary();
                OwnerService ownerService = new OwnerService(acctions, traslapEntityToDictionary);

                Owner owner = ownerService.GetById(userID);

                if (owner != null)
                {
                    ClaimsIdentity authIdentity = CreateClaims("refresh_token", owner);
                    List<string> items = new List<string>();
                    AuthenticationProperties properties = CreateProperties(items);
                    AuthenticationTicket ticket = new AuthenticationTicket(authIdentity, properties);

                    context.Validated(ticket);
                    return;
                }
            }

            context.SetError("invalid_refresh_token", "Refresh token is no longer valid.");
        }
    }
}
