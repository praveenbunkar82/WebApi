using System;
using System.ComponentModel.DataAnnotations;

namespace Egras.Entities
{
    public class Menu
    {
        public int MenuId { get; set; }

        [Required(ErrorMessage = "Menu Name is required")]
        [StringLength(20, ErrorMessage = "Name can't be longer than 20 characters")]
        public string MenuDesc { get; set; }

        [Required(ErrorMessage = "Menu Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string NavigationUrl { get; set; }
        
        [Required(ErrorMessage = "Parent ID is required")]
        public string MenuParentId { get; set; }
        public string MenuSecured { get; set; }
        public string ModuleId { get; set; }
        public string ObjectType { get; set; }
        public string OrderId { get; set; }
        public string MenuEnable { get; set; }
        public string MenuVisible { get; set; }
        public DateTime TransDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        [Required(ErrorMessage = "CreatedById is required")]
        public Int32 CreatedById { get; set; }
        public Int32 UpdatedById { get; set; }
    }
}
