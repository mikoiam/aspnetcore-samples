using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Options
{
    public class ConfigureMyOptions : IConfigureOptions<MyOptions>
    {
        private readonly Random _rnd = new Random();

        public void Configure(MyOptions options)
        {
            options.StringOption = "from_configure";
            options.DateTimeOption = DateTime.Now;
            options.NumberOption = _rnd.Next();
        }
    }
}
