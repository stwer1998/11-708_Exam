using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamPart2.ViewModels
{
    public class RestaurantModel
    {
        [Required]
        public string Name { get; set; }
    }
}
