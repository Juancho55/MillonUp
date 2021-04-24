/// <summary>
/// Class property.
/// </summary>

namespace Services.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Class entity property.
    /// </summary>
    public class Property
    {
        /// <summary>
        /// Gets or Sets Id Property.
        /// </summary>
        public long IdProperty { get; set; }

        /// <summary>
        /// Gets or Sets Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Addres.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or Sets Price.
        /// </summary>
        public Decimal Price { get; set; }

        /// <summary>
        /// Gets or Sets code internal.
        /// </summary>
        public string CodeInternal { get; set; }

        /// <summary>
        /// Gets or Sets year.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Gets or Sets state.
        /// </summary>
        public byte State { get; set; }
    }
}
