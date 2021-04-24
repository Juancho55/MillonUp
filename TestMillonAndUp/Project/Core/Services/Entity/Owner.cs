/// <summary>
/// Class of Owner.
/// </summary>
namespace Services.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Class entity owner
    /// </summary>
    public class Owner
    {
        /// <summary>
        /// Gets or Sets id owner
        /// </summary>
        public long IdOwner { get; set; }

        /// <summary>
        /// Gets or Sets name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or Sets photo in base 64.
        /// </summary>
        public string Photo { get; set; }

        /// <summary>
        /// Gets or Sets birth date.
        /// </summary>
        public DateTime BirthDate { get; set; }
    }
}
