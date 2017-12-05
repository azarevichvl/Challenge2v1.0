using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ParabolaDB.Attributes;
using System.Data.Linq.Mapping;


namespace ParabolaDB.Models
{
    public class Param
    {
        [ScaffoldColumn(false)]
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ParamId { get; set; }
        [Required(ErrorMessage = "The field must be set")]
        [Display(Name = "First coefficient")]
        public double CoefficientA { get; set; }
        [Required]
        public double CoefficientB { get; set; }
        [Required]
        public double CoefficientC { get; set; }

        [Required]       
        public double Step { get; set; }
        [Required]
        public double RangeFrom { get; set; }
        [Required]
        public double RangeTo { get; set; }

    }
}