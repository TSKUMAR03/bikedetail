using Bike.ADO.Interfaces;
using Bike.ADO.Repository;
using Bike.Domain.Context;
using Bike.Domain.Halder;
using Bike.Domain.InterfaceRepo;
using Bike.Domain.Interfaces;
using Bike.Domain.Repository;
using Bike.Service.ADO.Interface;
using Bike.Service.ADO.Mapping;
using Bike.Service.ADO.Services;
using Bike.Services.Interfaces;
using Bike.Services.Repository;
using Bike.Services.RepositoryService;
using Bike.Services.Services;
using BikeProject.Mapping;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


        builder.Services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("Connect"));
        });

        builder.Services.AddScoped<IBikeRepository, BikeRepository>();

     builder.Services.AddScoped<IRepositoryADO, Repository>();


builder.Services.AddScoped<ISalesRepository,SalesManRepository>(); 

builder.Services.AddAutoMapper(typeof(BikeProfile));

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddAutoMapper(typeof(BikeProfileADO));



builder.Services.AddScoped<IBikeService, BikeServiceImpl>();

builder.Services.AddScoped<ISalesManService,SalesManServiceImpl>();

builder.Services.AddScoped<IBikeServiceADO, BikeServiceImplADO>();

builder.Services.AddControllers();



var _jwtsetting = builder.Configuration.GetSection("JwtSetting");
builder.Services.Configure<JWTSetting>(_jwtsetting);

var authkey = builder.Configuration.GetValue<string>("JwtSetting:SecretKey");

builder.Services.AddAuthentication(item =>
{
    item.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    item.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(item =>
{
    item.RequireHttpsMetadata = true; item.SaveToken = true; item.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authkey)),
        ValidateIssuer = false,
        ValidateAudience = false

    };

});


builder.Services.AddSwaggerGen(c =>
{

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                        {
                            new OpenApiSecurityScheme {
                                Reference = new OpenApiReference {
                                    Type = ReferenceType.SecurityScheme,
                                        Id = "Bearer"
                                }
                            },
                            new string[] {}
                        }
        });
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

app.UseHttpsRedirection();


app.UseAuthentication();


app.UseAuthorization();


app.MapControllers();

app.Run();
