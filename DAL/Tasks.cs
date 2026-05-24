using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Tasks
    {
        [Key]
        public int TasksId { get; set; }
        public string TasksName { get; set; }
        public string TasksDescription { get; set; }
        public DateTime TasksDate { get; set; }
        public TaskStatus TasksStatus { get; set; }


        [ForeignKey("UserId")]

        public int UserId { get; set; }
        public virtual Users User { get; set; }

        [ForeignKey("CategoriesId")]
        public int CategoriesId { get; set; }
        public virtual Categories Category { get; set; }
    }
}
