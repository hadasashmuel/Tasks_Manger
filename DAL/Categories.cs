using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAL
{
    public class Categories
    {
        [Key]
        public int CategoriesId { get; set; }
        [MinLength(4)]
        public string CategoriesName { get; set; }
        public string CategoriesDescription { get; set; }
        //[JsonIgnore]
        public virtual List<Tasks> tasks { get; set; }
    }
}
