using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Options
{
    public class MyOptions
    {
        public MyOptions()
        {
            StringOption = "from_constructor";
            DateTimeOption = DateTime.Now;
            NumberOption = 0;
        }

        public string StringOption { get; set; }
        public DateTime DateTimeOption { get; set; }
        public int NumberOption { get; set; }
    }
}
