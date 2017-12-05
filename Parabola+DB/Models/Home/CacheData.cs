using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;

namespace ParabolaDB.Models
{
    public class CacheData
    {
        [Required]
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int CacheDataId { get; set; }
        [Required]
        public int ParamId { get; set; }
        [Required]
        public double PointX { get; set; }
        [Required]
        public double PointY { get; set; }
    }
}