namespace Services
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using Data;
    using Entity;

    public class PropertyService
    {
        private readonly Acctions acctions;

        public PropertyService(Acctions acctions)
        {
            this.acctions = acctions;
        }

        public List<Property> getPropertisByOwnerId(long OwnerId)
        {
            List<Property> properties = new List<Property>();

            IDictionary<string, object> valuePairs = new Dictionary<string, object>();

            valuePairs.Add("IdOwner", OwnerId);

            DataTable data = acctions.GetsAny("RealCompany.sp_getPropertysByOwner", valuePairs);

            if (data != null)
            {
                properties = (from a in data.AsEnumerable()
                             select new Property
                             {
                                 IdProperty = Convert.ToInt64(a.ItemArray[0].ToString()),
                                 Name = a.ItemArray[1].ToString(),
                                 Address = a.ItemArray[2].ToString(),
                                 Price = Convert.ToDecimal(a.ItemArray[3].ToString()),
                                 CodeInternal = a.ItemArray[4].ToString(),
                                 Year = Convert.ToInt32(a.ItemArray[5].ToString())
                             }).ToList();
            }

            return properties;
        }

    }
}
