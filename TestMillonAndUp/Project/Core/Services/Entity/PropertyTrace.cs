/// <summary>
/// Class property trace
/// </summary>

namespace Services.Entity
{
    using System;

    /// <summary>
    /// Class entity property trace
    /// </summary>
    public class PropertyTrace
    {
        /// <summary>
        /// Gets or Sets property trace id
        /// </summary>
        public long IdPropertyTrace { get; set; }

        /// <summary>
        /// Gets or Sets Date sale.
        /// </summary>
        public DateTime DateSale { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Value
        /// </summary>
        public Decimal Value { get; set; }

        /// <summary>
        /// Gets or Sets Tax
        /// </summary>
        public Decimal Tax { get; set; }

        /// <summary>
        /// Gets or Sets IdProperty
        /// </summary>
        public long IdProperty { get; set; }
    }
}
