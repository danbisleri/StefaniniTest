using Entities;
using System;
using System.ComponentModel.DataAnnotations;
namespace Stefanini.Models
{
    public class Search
    {
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Gender")]
        public string GenderId { get; set; }

        [Display(Name = "City")]
        public string CityId { get; set; }

        [Display(Name = "Region")]
        public string RegionId { get; set; }

        [Display(Name = "Last Purchase")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:dd/MM/YYYY}")]
        public Nullable<DateTime> LastPurchase { get; set; }

        [Display(Name = "Until")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:dd/MM/YYYY}")]
        public Nullable<DateTime> Until { get; set; }

        [Display(Name = "Classification")]
        public string ClassificationId { get; set; }

        [Display(Name = "Seller")]
        public string UserSysId { get; set; }
    }
}