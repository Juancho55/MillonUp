/// <summary>
/// Filter by owner
/// </summary>

namespace Services.Filters
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// A filter by owner for login.
    /// </summary>
    public class FilterOwner
    {
        /// <summary>
        /// Gets or sets NickName
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// Gets or sets Password
        /// </summary>
        public string Password { get; set; }
    }
}
