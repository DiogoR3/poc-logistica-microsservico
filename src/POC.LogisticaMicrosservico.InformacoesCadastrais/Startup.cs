using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using POC.LogisticaMicrosservico.Repositorios;
using POC.LogisticaMicrosservico.Repository.Entidades;
using System;
using System.Text;

namespace POC.LogisticaMicrosservico.InformacoesCadastrais
{
    public class Startup
    {
        public const string ChavePrivada = "paldf718113b48e197ggnhpghh2b708e";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "POC.LogisticaMicrosservico.InformacoesCadastrais", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Scheme = "bearer",
                    Description = "Por favor insira o token JWT"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            // Autenticacao JWT
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.SaveToken = true;
                x.RequireHttpsMetadata = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(ChavePrivada)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };

            });

            services.AddAuthorization(x =>
            {
                x.AddPolicy(nameof(TipoUsuario.Administrador), x => x.RequireClaim("Administrador"));
                x.AddPolicy(nameof(TipoUsuario.Colaborador), x => x.RequireClaim("Colaborador"));
                x.AddPolicy(nameof(TipoUsuario.Cliente), x => x.RequireClaim("Cliente"));
                x.AddPolicy(nameof(TipoUsuario.Fornecedor), x => x.RequireClaim("Fornecedor"));
            });


            // DbContext
            services.AddDbContext<LogisticaDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ArmazenamentoRepository>();
            services.AddScoped<AtendimentoRepository>();
            services.AddScoped<CidadeRepository>();
            services.AddScoped<EnderecoRepository>();
            services.AddScoped<EstadoRepository>();
            services.AddScoped<HistoricoLoginRepository>();
            services.AddScoped<HistoricoMercadoriaRepository>();
            services.AddScoped<MercadoriaRepository>();
            services.AddScoped<UsuarioRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "POC.LogisticaMicrosservico.InformacoesCadastrais v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
