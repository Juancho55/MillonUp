using System;
using System.Collections.Generic;
using System.Text;

namespace OAuth
{
    using System.Threading.Tasks;
    using Microsoft.Owin;
    using Microsoft.Owin.Security.OAuth;

    /// <summary>
    /// Authentication context extensions.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Gets the usertype value.
        /// </summary>
        /// <param name="context">Authentication context.</param>
        /// <returns>The awaited task (int).</returns>
        public static async Task<int?> GetUserTypeAsync(this OAuthGrantResourceOwnerCredentialsContext context)
        {
            if (int.TryParse(await context.GetParameterByNameAsync("userType"), out int userTypeID))
            {
                return userTypeID;
            }

            return null;
        }

        /// <summary>
        /// Gets a parameter by name from the current authentication context.
        /// </summary>
        /// <param name="context">The current authentication context.</param>
        /// <param name="name">The name of the parameter to return</param>
        /// <returns>The parameter value if any.</returns>
        private static async Task<string> GetParameterByNameAsync(this OAuthGrantResourceOwnerCredentialsContext context, string name)
        {
            IFormCollection parameters = await context.Request.ReadFormAsync();
            return parameters[name];
        }
    }
}
