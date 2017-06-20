using System;
using System.Web.Configuration;
using System.Web.Http;
using InterouteWebAPI.Interfaces;

namespace InterouteWebAPI.Controllers
{
    public class LoggerController : ApiController
    {
        private readonly ICommandWithResult<string> _command;

        public LoggerController(ICommandWithResult<string> command)
        {
            _command = command ?? throw new ArgumentNullException(nameof(command));
        }

        [HttpGet]
        public IHttpActionResult GetLogFileContents()
        {
            _command.Execute(new object[] {WebConfigurationManager.AppSettings["LogFile"]});
            return Ok(_command.Result);
        }
    }
}