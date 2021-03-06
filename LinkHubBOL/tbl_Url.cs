//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LinkHubBOL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public partial class tbl_Url
    {
        public int UrlId { get; set; }
        [Required]
        [DisplayName("URL Title")]
        public string UrlTitle { get; set; }
        [DisplayName("URL")]
        [Required]
        [Url]
        [UniqueUrl]
        public string Url { get; set; }
        [Required]
        [DisplayName("URL Description")]
        public string UrlDesc { get; set; }
        [DisplayName("Category")]
        public Nullable<int> CategoryId { get; set; }
        public Nullable<int> UserId { get; set; }
        public string IsApproved { get; set; }
    
        public virtual tbl_Category tbl_Category { get; set; }
        public virtual tbl_User tbl_User { get; set; }
    }

    public class UniqueUrlAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext contex )
        {
            LinkHubDbEntities db = new LinkHubDbEntities();
            string urlValue = value.ToString();
            int count = db.tbl_Url.Where(x => x.Url == urlValue).Count();
            if(count != 0)
            {
                return new ValidationResult("Url is existed");
            }
            return ValidationResult.Success;
        }
    } // end class UniqueUrlAttribute
}
