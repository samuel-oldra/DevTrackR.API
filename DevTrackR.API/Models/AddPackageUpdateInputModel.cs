using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTrackR.API.Models
{
    public class AddPackageUpdateInputModel
    {
        public string Status { get; set; }
        public bool Delivered { get; set; }
    }
}