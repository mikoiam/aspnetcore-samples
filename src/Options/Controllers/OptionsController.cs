using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Options.Models;

namespace Options.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionsController : ControllerBase
    {
        private readonly Guid _controllerInstance = Guid.NewGuid();
        private readonly IOptions<MyOptions> _myOptions;
        private readonly IOptionsSnapshot<MyOptions> _myOptionsSnapshot;
        private readonly IOptionsMonitor<MyOptions> _myOptionsMonitor;

        public OptionsController(
            IOptions<MyOptions> myOptions,
            IOptionsSnapshot<MyOptions> myOptionsSnapshot,
            IOptionsMonitor<MyOptions> myOptionsMonitor)
        {
            _myOptions = myOptions;
            _myOptionsSnapshot = myOptionsSnapshot;
            _myOptionsMonitor = myOptionsMonitor;
        }

        // GET api/options
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                ControllerInstance = _controllerInstance,
                CurrentTime = DateTime.Now.ToLongTimeString(),
                Options1 = GetMyOptionsResult(_myOptions.Value),
                Options2 = GetMyOptionsResult(_myOptions.Value),
                OptionsSnapshot1 = GetMyOptionsResult(_myOptionsSnapshot.Value),
                OptionsSnapshot2 = GetMyOptionsResult(_myOptionsSnapshot.Value),
                OptionsMonitor1 = GetMyOptionsResult(_myOptionsMonitor.CurrentValue),
                OptionsMonitor2 = GetMyOptionsResult(_myOptionsMonitor.CurrentValue)
            });
        }

        private MyOptionsResult GetMyOptionsResult(MyOptions myOptions)
        {
            return new MyOptionsResult
            {
                OptionString = myOptions.StringOption,
                OptionTime = myOptions.DateTimeOption.ToLongTimeString(),
                OptionNumber = myOptions.NumberOption
            };
        }
    }
}
