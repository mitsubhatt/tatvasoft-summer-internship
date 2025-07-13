using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mission.Entities.Models.CommonModel;

namespace Mission.Services.IServices
{
    public interface ICommonService
    {
        List<DropDownResponseModel> CountryList();

        List<DropDownResponseModel> CityList(int countryId);
    }
}
