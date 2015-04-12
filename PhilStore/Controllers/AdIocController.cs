using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhilStore.BLL;
using PhilStore.BLL.Specifications;

namespace PhilStore.Controllers
{
    public class AdIocController : Controller
    {
        private IAdvertisementService _service;
        //public AdIocController()
        //{
        //    _service = new AdvertisementService();
        //}
        public AdIocController( IAdvertisementService service )
        {
            _service = service;
        }

        public ActionResult Index()
        {
            ViewBag.Message = _service.GetAdDescription();
            return View();
        }
    }
}