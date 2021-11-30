namespace EmployeeManagemnetWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Employee
    {
        [StringLength(7)]
        [MaxLength(7)]
        [RegularExpression("^(ace|ACE)[0-9]{4}$", ErrorMessage ="Employee Id should start with ACE followed by four digit number")]
        
        public string EmployeeID { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "numeric")]
        public decimal MobileNo { get; set; }

        [Column(TypeName = "date")]
        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime DateOfJoining { get; set; }

        [Required]
        [StringLength(20)]
        public string Email { get; set; }

      

       

    }
}
