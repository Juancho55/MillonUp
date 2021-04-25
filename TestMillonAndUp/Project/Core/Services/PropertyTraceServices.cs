namespace Services
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using Data;
    using Services.Entity;

    public class PropertyTraceServices
    {
        private readonly Acctions acctions;

        public PropertyTraceServices(Acctions acctions)
        {
            this.acctions = acctions;
        }

        public List<PropertyTrace> GetPropertyTracesByPropertyId(long propertyId)
        {
            List<PropertyTrace> propertyTraces = new List<PropertyTrace>();

            IDictionary<string, object> valuePairs = new Dictionary<string, object>();

            valuePairs.Add("IdPropety", propertyId);

            DataTable data = acctions.GetsAny("RealCompany.sp_getPropertyTrace", valuePairs);

            if (data != null)
            {
                propertyTraces = (from a in data.AsEnumerable()
                              select new PropertyTrace
                              {
                                  IdPropertyTrace = Convert.ToInt64(a.ItemArray[0].ToString()),
                                  DateSale = Convert.ToDateTime(a.ItemArray[1].ToString()),
                                  Name = a.ItemArray[2].ToString(),
                                  Value = Convert.ToDecimal(a.ItemArray[3].ToString()),
                                  Tax = Convert.ToDecimal(a.ItemArray[4].ToString())
                              }).ToList();
            }

            return propertyTraces;
        }
    }
}
