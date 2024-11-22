using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Tour
    {
        public Guid TourID { get; set; }
        public string TourName { get; set; }
        public string Description { get; set; }

    }


}
