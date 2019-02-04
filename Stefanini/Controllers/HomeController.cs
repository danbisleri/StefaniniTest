
using Domain.Services;
using Entities;
using Stefanini.Models;
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

        public HomeController()
        {
            _customer = new Service<Customer>();
            _seller = new Service<UserSys>();
            _login = new Service<UserSys>();
            _city = new Service<City>();
            _region = new Service<Region>();
            _gender = new Service<Gender>();
            _classification = new Service<Classification>();
        }

        [Route("Customer/List")]
        public ActionResult Index(Search model)
        {

            ViewBag.Sellers = new SelectList(_seller.GetAll(), "Id", "Login", model == null ? null : model.UserSysId);
            ViewBag.Cities = new SelectList(_city.GetAll(), "Id", "Name", model == null ? null : model.CityId);
            ViewBag.Regions = new SelectList(_region.GetAll(), "Id", "Name", model == null ? null : model.RegionId);
            ViewBag.Classifications = new SelectList(_classification.GetAll(), "Id", "Name", model == null ? null : model.ClassificationId);
            ViewBag.Gender = new SelectList(_gender.GetAll(), "Id", "Name", model == null ? null : model.GenderId);

            UserSys userSys = _login.GetAll().Where(u => u.Email == User.Identity.Name && u.UserRole.IsAdmin ).FirstOrDefault();
            
            ViewData["IsAdmin"] = _login.Get(userSys.Id).UserRole.IsAdmin;

            return View(new CustomerList(_customer.GetAll().Where( c => c.City.Id.ToString() == model.CityId 
                                                                     || c.Region.Id.ToString() == model.RegionId 
                                                                     || c.UserSys.Id.ToString() == model.UserSysId 
                                                                     || c.Classification.Id.ToString() == model.ClassificationId  )
                                                                     ) { Search = model } )  ;


        }
    }
}
