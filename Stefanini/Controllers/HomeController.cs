
using Domain.Services;
using Entities;
using Stefanini.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace Crud_FluentNHibernate.Models
{
    public class HomeController : Controller
    {
        private readonly Service<Customer> _customer ;
        private readonly Service<UserSys> _login ;
        private readonly Service<UserSys> _seller;
        private readonly Service<City> _city;
        private readonly Service<Region> _region ;
        private readonly Service<Gender> _gender;
        private readonly Service<Classification> _classification;
        private readonly ServiceRegion _regionCity;

        public HomeController()
        {
            _customer = new Service<Customer>();
            _seller = new Service<UserSys>();
            _login = new Service<UserSys>();
            _city = new Service<City>();
            _region = new Service<Region>();
            _gender = new Service<Gender>();
            _classification = new Service<Classification>();

            _regionCity = new ServiceRegion();
        }

        [Route("Customer/List")]
        public ActionResult Index(Search model)
        {

            ViewBag.Sellers = new SelectList(_seller.GetAll(), "Id", "Login", model == null ? null : model.UserSysId);
            ViewBag.Cities = new SelectList(_city.GetAll(), "Id", "Name", model == null ? null : model.CityId);
            ViewBag.Regions = new SelectList(_region.GetAll(), "Id", "Name", model == null ? null : model.RegionId);
            ViewBag.Classifications = new SelectList(_classification.GetAll(), "Id", "Name", model == null ? null : model.ClassificationId);
            ViewBag.Gender = new SelectList(_gender.GetAll(), "Id", "Name", model == null ? null : model.GenderId);

            UserSys userSys = _login.GetAll().Where(u => u.Email == User.Identity.Name ).FirstOrDefault();
            
            ViewData["IsAdmin"] = _login.Get(userSys.Id).UserRole.IsAdmin;

            var customerFilter = _customer.GetAll();

            if (!_login.Get(userSys.Id).UserRole.IsAdmin)
                customerFilter = customerFilter.Where(c => c.UserSys.Id.ToString() == _login.Get(userSys.Id).Id.ToString() );

            if (!string.IsNullOrEmpty(model.Name))
                customerFilter = customerFilter.Where(c => c.Name.Contains( model.Name ));

            if (!string.IsNullOrEmpty(model.LastPurchase.ToString()))
                customerFilter = customerFilter.Where(c => DateTime.Parse(c.LastPurchase) >= model.LastPurchase );

            if (!string.IsNullOrEmpty(model.Until.ToString()))
                customerFilter = customerFilter.Where(c => DateTime.Parse(c.LastPurchase) <= model.Until);

            if (!string.IsNullOrEmpty(model.CityId))
                customerFilter = customerFilter.Where(c => c.City.Id.ToString() == model.CityId);

            if (!string.IsNullOrEmpty(model.RegionId))
                customerFilter = customerFilter.Where(c => c.Region.Id.ToString() == model.RegionId);

            if (!string.IsNullOrEmpty(model.UserSysId))
                customerFilter = customerFilter.Where(c => c.UserSys.Id.ToString() == model.UserSysId);

            if (!string.IsNullOrEmpty(model.ClassificationId))
                customerFilter = customerFilter.Where(c => c.Classification.Id.ToString() == model.ClassificationId);

            if (!string.IsNullOrEmpty(model.GenderId))
                customerFilter = customerFilter.Where(c => c.Gender.Id.ToString() == model.GenderId);


            return View(new CustomerList( customerFilter.OrderBy(c=> c.LastPurchase) ) { Search = model } )  ;


        }

        public JsonResult GetRegions(string cityId)
        {
            return Json(new SelectList(_regionCity.GetRegions(cityId) , "Id", "Name"), JsonRequestBehavior.AllowGet);
        }
    }
}
