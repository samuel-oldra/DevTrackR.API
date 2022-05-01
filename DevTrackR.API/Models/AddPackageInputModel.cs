using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTrackR.API.Models
{
    public class AddPackageInputModel
    {
        public string Title { get; set; }
        public decimal Weight { get; set; }
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
    }
}