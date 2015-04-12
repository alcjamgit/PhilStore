using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhilStore.BLL.Specifications;

namespace PhilStore.BLL.Services
{
    public class AdvertisementService: IAdvertisementService
    {

        public string GetAdDescription()
        {
            return "Power tool set";
        }
    }
}
