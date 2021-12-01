using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Recipe.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Recipe.WebApi.Installers
{
    public class SwaggerInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration Configuration)
        {
                services.AddSwaggerGen(c =>
            {
                //c.DocumentFilter<JsonPatchDocumentFilter>();

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Recipe Handy Book - Toshiba Version",
                    Version = "v1",
                    Description = "An API used for Recipes",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Christian Eklund",
                        Email = "chekazure@gmail.com",
                        Url = new Uri("https://example.com/Contact"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Admin owner and power user for API",
                        Url = new Uri("https://example.com/license")
                    }
                });

                c.AddSecurityDefinition("bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'bearer' [space] and then your valid token in the text input below."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "bearer"
                            }
                        },
                        new List<string>() {}
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            }).AddSwaggerGenNewtonsoftSupport();
        }
        
    }
}
