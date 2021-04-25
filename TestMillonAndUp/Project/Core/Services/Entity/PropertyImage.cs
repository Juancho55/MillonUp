/// <summary>
/// Class property image.
/// </summary>
namespace Services.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Class entity property image
    /// </summary>
    public class PropertyImage
    {
        /// <summary>
        /// Gets or sets property image id
        /// </summary>
        public long IdPropertyImage { get; set; }

        /// <summary>
        /// Gets or sets id Propety
        /// </summary>
        public long? IdPropertyId { get; set; }

        /// <summary>
        /// Gets or sets image on base 64.
        /// </summary>
        public string File { get; set; }
    }
}
