using EMI.AppStart;
using EMI.Authentication;
using EMI.Authentication.Authorization;
using EMI.Domain.Entity;
using EMI.Middlewares.GlobalExceptionMiddleware;
using EMI.Middlewares.RequestLoggingMiddleware;
using EMI.Repository.EFC;
using EMI.Transversal.Mapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


IConfiguration configuration = builder.Configuration;
builder.Services.AddSingleton<IConfiguration>(configuration);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region DB Connection and properties
builder.Services.AddDbContext<EmiDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EMIDB"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
});

builder.Services.AddDbContext<LogDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EMIDB"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
#endregion

#region Manage Dependency injection
builder.Services.AddDependencies(configuration);
#endregion


#region Swagger with authorization token
builder.Services.AddSwaggerGen(c =>
{
    var jwtSecurityScheme = new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Scheme = "bearer",
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Description = "Put Only your JWT Bearer token on textbox below!",
        Reference = new Microsoft.OpenApi.Models.OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme
        }
    };

    c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                {
                    {
                        jwtSecurityScheme, Array.Empty<String>()
                    }
                });
});
#endregion

# region Adding Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});
#endregion

#region Adding Authorization 
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RolePolicy", policy =>
           policy.Requirements.Add(new AuthorizeRoleRequirement()));
});
#endregion

#region Adding Automapper
var profileAssembly = typeof(MappingProfile).Assembly;
builder.Services.AddAutoMapper(profileAssembly);
#endregion

#region Configuring HandleException error models
builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errorDetails = context.ConstructErrorMessages();
        return new BadRequestObjectResult(errorDetails);
    };
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseExceptionMiddleware();

app.UseMiddleware<RequestLoggingMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
