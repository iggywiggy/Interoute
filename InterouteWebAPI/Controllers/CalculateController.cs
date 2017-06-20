using System;
using System.Web.Http;
using InterouteWebAPI.Common;
using InterouteWebAPI.Interfaces;
using log4net;

namespace InterouteWebAPI.Controllers
{
    public class CalculateController : ApiController
    {
        private readonly ICommandWithResult<long> _commander;
        private readonly ILog _log;

        public CalculateController(ICommandWithResult<long> commander, ILogManager logManager)
        {
            _commander = commander ?? throw new ArgumentNullException(nameof(commander));
            _log = logManager?.GetLog(typeof(CalculateController)) ??
                   throw new ArgumentNullException(nameof(logManager));
        }

        [HttpPost]
        public IHttpActionResult AddTwoIntegers(string integerOne,
            string integerTwo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Utils.ConvertStringToInt(integerOne, out long valueOne);
            Utils.ConvertStringToInt(integerTwo, out long valueTwo);

            _commander.Execute(new object[] {valueOne, valueTwo});

            _log.Info(
                $"DateTime: {DateTime.Now}, ValueOne: {valueOne}, ValueTwo: {valueTwo}, Result: {_commander.Result}");

            return Ok(_commander.Result);
        }
    }
}