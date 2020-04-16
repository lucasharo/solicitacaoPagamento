using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.Swagger.Model;
using Dados;
using Negocio;
using Entidades;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net.Http;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace API
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();

            Util.Configuration = Configuration;
        }

        public IConfigurationRoot Configuration { get; }
        public ILoggerFactory loggerFactory;

        public void ConfigureServices(IServiceCollection services)
        {
            DadosContext.ConnectionString = Configuration.GetConnectionString("DadosConnection");
            DadosAldInfoContext.ConnectionString = Configuration.GetConnectionString("DadosAldInfoConnection");

            services.AddTransient<DadosContext>();
            services.AddTransient<DadosAldInfoContext>();
            services.AddTransient(typeof(GenericNegocio<>));

            services.AddTransient<UsuarioNegocio>();

            services.AddTransient<SolicitacaoPagamentoNegocio>();
            services.AddTransient<AprovacaoNegocio>();
            services.AddTransient<ProdutivoNegocio>();
            services.AddTransient<NaoProdutivoNegocio>();
            services.AddTransient<AdiantamentoNegocio>();
            services.AddTransient<CarPurchaseNegocio>();
            services.AddTransient<FornecedorNegocio>();
            services.AddTransient<CrepCodeNegocio>();

            services.AddSingleton<Resposta>();

            services.AddSingleton<Solicitacao_Pagamento>();
            services.AddSingleton<Solicitacao_Pagamento_Detalhe>();
            services.AddSingleton<Documento_Fiscal>();
            services.AddSingleton<Diretoria>();
            services.AddSingleton<Forma_Pagamento>();
            services.AddSingleton<Tipo_Solicitacao_Pagamento>();
            services.AddSingleton<Fila_Solicitacao_Pagamento>();
            services.AddSingleton<Categoria_NF>();
            services.AddSingleton<ALD_ETL_Crep_Code>();
            services.AddSingleton<ALD_ETL_Agreement>();
            services.AddSingleton<ALD_ETL_Agreement_Item>();
            services.AddSingleton<ALD_ETL_Invoice>();
            services.AddSingleton<Controle_NF>();
            services.AddSingleton<ALD_ETL_Fornecedores>();
            services.AddSingleton<Blacklist_Fornecedor>();

            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddCors(options =>
            {
                options.AddPolicy("default", policy =>
                {
                    policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });

            services.AddMvcCore()
                .AddAuthorization(options =>
                {
                    options.AddPolicy("ALDLogin", policy =>
                    {
                        policy.RequireAssertion(context =>
                        {
                            if (((AuthorizationFilterContext)context.Resource).HttpContext.Request.Headers.TryGetValue(HeaderNames.Authorization, out var token))
                            {
                                token = token.ToString().Replace("Bearer ", "");

                                var client = new HttpClient();
                                client.SetBearerToken(token.ToString().Trim());

                                var response = client.GetAsync($"{Configuration.GetValue<string>("Aplicacoes")}api/Usuario/ValidaSessao").Result;

                                if (!response.IsSuccessStatusCode)
                                {
                                    return false;
                                }
                                else
                                {
                                    return (bool)JsonConvert.DeserializeObject<dynamic>(response.Content.ReadAsStringAsync().Result).status.Value;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        });
                    });

                })
                .AddJsonFormatters();

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddSwaggerGen();

            services.ConfigureSwaggerGen(options =>
            {
                options.SingleApiVersion(new Info
                {
                    Version = "v1",
                    Title = "SolicitacaoPagamento",
                    Description = "Solicitação de Pagamento",
                });

                options.DescribeAllEnumsAsStrings();

                options.DescribeStringEnumsInCamelCase();
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddFile(Configuration.GetValue<string>("DiretorioLogs") + "ERROR-{Date}.txt", LogLevel.Error);
            loggerFactory.AddFile(Configuration.GetValue<string>("DiretorioLogs") + "WARNING-{Date}.txt", LogLevel.Warning);
            loggerFactory.AddFile(Configuration.GetValue<string>("DiretorioLogs") + "INFO-{Date}.txt");

            app.UseCors("default");

            app.UseIdentityServerAuthentication(new IdentityServerAuthenticationOptions
            {
                Authority = Configuration.GetValue<string>("Autenticacao"),
                ApiName = "api1",
                RequireHttpsMetadata = false
            });

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUi();
        }
    }
}
