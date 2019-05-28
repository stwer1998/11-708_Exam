using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamPart2.Models
{
    public class Restaurant
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public List<Food> Foods { get; set; }
    }
}
