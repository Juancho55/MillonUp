namespace Services
{
    using Data;
    using Services.Entity;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;

    public class PropertyImageService
    {
        private readonly Acctions actions;

        public PropertyImageService(Acctions actions)
        {
            this.actions = actions;
        }

        public List<PropertyImage> getsImagesByPropertyId(long propertyId)
        {
            List<PropertyImage> propertyImages = new List<PropertyImage>();

            IDictionary<string, object> valuePairs = new Dictionary<string, object>();

            valuePairs.Add("IdPropety", propertyId);

            DataTable data = actions.GetsAny("RealCompany.sp_getImagePropertyByProperty", valuePairs);

            if (data != null)
            {
                propertyImages = (from a in data.AsEnumerable()
                                  select new PropertyImage()
                                  {
                                      IdPropertyImage = Convert.ToInt64(a.ItemArray[0].ToString()),
                                      IdPropertyId = Convert.ToInt64(a.ItemArray[1].ToString()),
                                      File = a.ItemArray[2].ToString()
                                  }).ToList();
            }

            return propertyImages;
        }
    }
}
