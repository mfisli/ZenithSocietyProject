using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenithDataLib.Models // try just ZenithDataLib
{
    public class Event
    {
        public int EventId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string CreatedBy { get; set; }

        public int ActivityId { get; set; }        // Activity or int type? 
        public DateTime CreationDate { get; set; }
        public bool IsActive { get; set; }
    }
}
