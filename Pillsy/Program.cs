
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Pillsy.Helpers;
using Repository;
using Repository.Interfaces;
using Service;
using Service.Interfaces;
using System.Text;
using System.Text.Json.Serialization;

namespace Pillsy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(options =>
                            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
            builder.Services.AddControllersWithViews(options =>
            {
                options.Conventions.Add(new LowercaseControllerModelConvention());
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
#if DEBUG
            builder.Configuration.AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true);
#else
            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
#endif

            builder.Services.AddSwaggerGen(option =>
            {
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                        new string[] {}
                    }
                });
            });
            builder.Services.AddMvc()
                    .AddNewtonsoftJson(
                            options => { options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; }
            );

            //Add DI for repo and service
            //builder.Services.AddTransient<IDoctorRepository, DoctorRepository>();
            //builder.Services.AddTransient<IDoctorService, DoctorService>();
            builder.Services.AddTransient<IAccountRepository, AccountRepository>();
            builder.Services.AddTransient<IAccountService, AccountService>();
            builder.Services.AddTransient<IPatientRepository, PatientRepository>();
            builder.Services.AddTransient<IPatientService, PatientService>();
            builder.Services.AddTransient<IPillRepository, PillRepository>();
            builder.Services.AddTransient<IPillService, PillService>();
            builder.Services.AddTransient<IPrescriptionRepository, PrescriptionRepository>();
            builder.Services.AddTransient<IPrescriptionService, PrescriptionService>();

            //




            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        //you can configure your custom policy
                        builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            });
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pillsy API", Version = "v1" });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Configure method
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pillsy API V1");
                c.RoutePrefix = string.Empty; // Set the root path for Swagger UI
            });


            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.MapControllers();
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.Run();
        }
    }
}