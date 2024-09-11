
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Web_Api_JWT.Mappers;
using Web_Api_JWT.Models;
using Web_Api_JWT.Repo.Abstract;
using Web_Api_JWT.Repo.Concrete;
using Web_Api_JWT.Service;

namespace Web_Api_JWT
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConn")
            ));
            builder.Services.AddAutoMapper(typeof(AutoMappers));
            builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddHttpContextAccessor();
            // Learn more about configurig Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(x =>
                {
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = true,//uygulamada belirtilen sitelerin denetlenip/denetlenmemesi
                        ValidateIssuer = true,//yazýlan adresin denetimi.
                        ValidateLifetime = true,//yaþam süresi olacak mý ?
                        ValidIssuers = new string[] { builder.Configuration["JWT:Issuer"] },
                        ValidAudiences = new string[] { builder.Configuration["JWT:Audience"] },
                        ValidateIssuerSigningKey = true,//token bizde mi kontrolü?
                        ClockSkew = TimeSpan.FromMinutes(30),//token üzerine ek zaman
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))


                    };



                });

            //swagger üzerindeki token kontrolu için config--farklý yazýmlarýd da var 

            builder.Services.AddSwaggerGen(

                opt =>
                {
                    opt.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                    {
                        Description = " insert jwt token",
                        In=ParameterLocation.Header,
                        Name="Authorization",
                        Type=SecuritySchemeType.ApiKey
                    });
                    opt.OperationFilter<SecurityRequirementsOperationFilter>();
                });
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
