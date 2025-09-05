using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertiesManager.Model;

namespace PropertiesManager.Services
{
    public interface IRetrieveTitleBlkInfoService
    {
        TitleBlockInfoModel Get();
    }
}
