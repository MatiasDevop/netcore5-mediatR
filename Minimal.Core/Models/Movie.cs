using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimal.Core.Models
{
    public class Movie : EntityBase
    {
        public string Name { get; set; }
        public double Rating { get; set; }
        public int AgeGroup { get; set; }
        public bool IsDeleted { get; set; }
    }
}
