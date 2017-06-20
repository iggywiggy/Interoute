using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.ModelBinding;
using System.Web.Http.Tracing;
using InterouteWebAPI.Infastructure;
using InterouteWebAPI.Interfaces;
using ExceptionLogger = InterouteWebAPI.Infastructure.ExceptionLogger;

namespace InterouteWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var provider = new StringParameterBinderProvider(new StringParameterBinder(), typeof(string));

            config.Services.Insert(typeof(ModelBinderProvider), 0, provider);
            config.Services.Replace(typeof(ITraceWriter), new LogWriter(WebContainerManager.Get<ILogManager>()));
            config.Services.Add(typeof(IExceptionLogger), new ExceptionLogger(WebContainerManager.Get<ILogManager>()));

            config.BindParameter(typeof(string), new StringParameterBinder());


            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new
                {
                    id = RouteParameter.Optional
                });
        }
    }
}