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
using GST_API.Middlewares;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

var builder = WebApplication.CreateBuilder(args);


var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

var configuration = builder.Configuration
.SetBasePath(System.IO.Directory.GetCurrentDirectory())
.AddJsonFile($"appsettings.json", optional: false)
.AddJsonFile($"appsettings.{env}.json", optional: true)
.AddEnvironmentVariables()
.Build();

EncryptionUtils.isProduction = (env == "Production");

if (configuration == null)
{
    throw new Exception("unable to find configuration");
}
var connectionString = configuration.GetConnectionString("Default");
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(connectionString,
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

builder.Services.AddHttpContextAccessor();

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


string baseLogPath = builder.Environment.ContentRootPath + "\\Logs" ;

if (!Directory.Exists(baseLogPath))
{
    Console.WriteLine("Directory does not exists");
    Directory.CreateDirectory(baseLogPath);
}

Log.Logger = new LoggerConfiguration()
    .WriteTo.File(baseLogPath + "\\ApiLogs-.log", rollingInterval: RollingInterval.Day).CreateLogger();

builder.Logging.AddSerilog(Log.Logger);

builder.Services.Configure<ApiBehaviorOptions>(options
    => options.SuppressModelStateInvalidFilter = true);


builder.Services.AddExceptionHandler<ValidationExceptionHandler>();
builder.Services.AddExceptionHandler<ExceptionHandler>();
builder.Services.AddProblemDetails();



var app = builder.Build();

app.UseExceptionHandler();

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

ApplyMigration();

app.Run();



void ApplyMigration()
{
    Log.Information("Environment fetched >>>>>> "+env);
    if (!EncryptionUtils.isProduction)
    {
        return;
    }
    using (var scope = app.Services.CreateScope())
    {
        var _Db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        if (_Db != null)
        {
            Log.Information("Using Connection String >>>> " + connectionString);
            if (_Db.Database.GetPendingMigrations().Any())
            {
                _Db.Database.Migrate();
            }
        }
    }
}