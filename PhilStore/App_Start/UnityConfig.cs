using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using PhilStore.BLL.Services;
using PhilStore.BLL.Specifications;

namespace PhilStore.App_Start
{
    public class UnityConfig
    {
        private static IUnityContainer _container;
        public static IUnityContainer RegisterTypes() 
        {
            
            _container = new UnityContainer();
            _container.RegisterType<IAdvertisementService, AdvertisementService2>();
            return _container;
        }
    }
}