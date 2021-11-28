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
        public string EmployeeID { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Column(TypeName = "numeric")]
        public decimal MobileNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfJoining { get; set; }

        [Required]
        [StringLength(20)]
        public string Email { get; set; }

    }
}
