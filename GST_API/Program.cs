using GST_API_DAL;
using Serilog;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GST_API_DAL.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using GST_API.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using GST_API.Filters;
using GST_API_Library.Services;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
if (configuration == null)
{
    throw new Exception("unable to find configuration");
}
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(configuration.GetConnectionString("Default"),
    builder =>
    {
        builder.EnableRetryOnFailure(10, TimeSpan.FromSeconds(60), null);
    }));

var baseProjectPath = configuration.GetValue<string>(WebHostDefaults.ContentRootKey);
if (string.IsNullOrEmpty(baseProjectPath))
{
    GSTNConstants.base_path = "";
}
else
{
    GSTNConstants.base_path = baseProjectPath.Substring(0, baseProjectPath.LastIndexOf('\\'));
}

builder.Services.AddRepositories();
builder.Services.AddServices();

builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(builder =>
    {
        builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

builder.Services.AddIdentityCore<User>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.User.RequireUniqueEmail = true;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
}).AddRoles<IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

builder.Services.AddAuthentication(options=>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ClockSkew = TimeSpan.Zero,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = configuration["Jwt:Issuer"],
        ValidAudience = configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
    };
});


builder.Services.AddAutoMapper(typeof(Program).Assembly);


builder.Services.AddControllers(config =>
{
    config.Filters.Add(new ControllerActionFilter());
});

//10Jan2025 --NULL Handling
builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "GST API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

var logger = new LoggerConfiguration()
    .WriteTo.File(builder.Environment.ContentRootPath + "Logs" + "\\ApiLogs-.log", rollingInterval: RollingInterval.Day).CreateLogger();

builder.Logging.AddSerilog(logger);

builder.Services.Configure<ApiBehaviorOptions>(options
    => options.SuppressModelStateInvalidFilter = true);

var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//app.UseHttpsRedirection();
//}

app.UseAuthentication();

app.UseAuthorization();

app.UseDbTransaction();

app.UseCors();

app.MapControllers();

app.Run();