using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenithDataLib.Models
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }

        public List<Event> Events { get; set; }
    }
}
