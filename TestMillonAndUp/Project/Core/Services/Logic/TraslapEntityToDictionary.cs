
namespace Services.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Filters;

    public class TraslapEntityToDictionary
    {
        public IDictionary<string, object> OwnerFilters(FilterOwner filter)
        {
            IDictionary<string, object> owner = new Dictionary<string, object>();
            owner.Add("NikName", filter.NickName);
            owner.Add("Password", filter.NickName);
            return owner;
        }
    }
}
