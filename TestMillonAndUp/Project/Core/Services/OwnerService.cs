/// <summary>
/// Service of owner.
/// </summary>

namespace Services
{
    using System;
    using System.Data;
    using Data;
    using Entity;
    using Filters;
    using Logic;

    /// <summary>
    /// filters by owner in service.
    /// </summary>
    public class OwnerService
    {

        private readonly Acctions acctions;
        private readonly TraslapEntityToDictionary traslapEntityTo;

        public OwnerService(Acctions acctions, TraslapEntityToDictionary traslapEntityTo)            
        {
            this.acctions = acctions;
            this.traslapEntityTo = traslapEntityTo;
        }

        public Owner AuthUser(FilterOwner filter)
        {
            Owner owner = new Owner();

            DataTable result = acctions.GetsAny("RealCompany.sp_UserAuth", traslapEntityTo.OwnerFilters(filter));

            if (result != null)
            {


                foreach (DataRow item in result.Rows)
                {
                    owner.IdOwner = Convert.ToInt64(item.ItemArray[0].ToString());
                    owner.Name = item.ItemArray[1].ToString();
                    owner.Address = item.ItemArray[2].ToString();
                    owner.Photo = item.ItemArray[3].ToString();
                    owner.BirthDate = Convert.ToDateTime(item.ItemArray[4].ToString());
                }
            }

            return owner;
        }
    }
}
