using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PointlessDataStorage.Models
{
    public class UselessDataBlock
    {
        //Yes I'm aware of naming violations. Lesson learnt
        public int ID { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string name { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date")]
        public DateTime randomDate { get; set; }
        [Required]
        [Display(Name = "Some Number")]
        public float garbageFloat { get; set; }
    }
}
