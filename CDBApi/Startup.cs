using System.Web.Http;
using System.Web.Http.Cors;
using Owin;
using Swashbuckle.Application;
using Unity;
using Unity.Lifetime;
using CDBApi.Infrastructure;
using CDBApi.Services;

public class Startup
{
    public void Configuration(IAppBuilder app)
    {
        HttpConfiguration config = new HttpConfiguration();

        // Configuração de CORS
        var cors = new EnableCorsAttribute("*", "*", "*");
        config.EnableCors(cors);

        // Configuração de Rotas
        config.MapHttpAttributeRoutes();
        config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
        );

        // Configuração de Formatação JSON
        config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        config.Formatters.Remove(config.Formatters.XmlFormatter);

        // Configuração do Swagger
        config.EnableSwagger(c => c.SingleApiVersion("v1", "CDB API"))
              .EnableSwaggerUi();

        // Configuração do Unity
        var container = new UnityContainer();
        container.RegisterType<ICdbCalculator, CdbCalculator>(new HierarchicalLifetimeManager());
        config.DependencyResolver = new UnityResolver(container);

        // Configuração do OWIN
        app.UseWebApi(config);
    }
}