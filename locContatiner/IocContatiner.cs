using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using IBLL;
using IDAO;
using DAO;
using System.Configuration;
using Microsoft.Practices.Unity.Configuration;

namespace locContatiner
{
  public  class IocContatiner
    {
        public static TIDAO CreateDao<TIDAO, TDAO>() where TDAO : TIDAO
        {
            UnityContainer ioc = new UnityContainer();
            ioc.RegisterType<TIDAO, TDAO>();
            return ioc.Resolve<TIDAO>();
        }

        public static TIBLL CreateBLL<TIBLL>(string name)
        {
            UnityContainer ioc = new UnityContainer();
            ExeConfigurationFileMap ef = new ExeConfigurationFileMap();
            ef.ExeConfigFilename = @"C:\Users\Administrator\Documents\Visual Studio 2015\Projects\hr\hr\Unity.config";
            Configuration cf = ConfigurationManager.OpenMappedExeConfiguration(ef, ConfigurationUserLevel.None);
            UnityConfigurationSection cs = cf.GetSection("unity") as UnityConfigurationSection;
            ioc.LoadConfiguration(cs, "containerTwo");
            return ioc.Resolve<TIBLL>(name);
        }
    }
}
