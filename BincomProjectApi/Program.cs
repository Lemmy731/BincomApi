using BincomProjectApi.Extension;
using BincomProjectApi.Model.Entities;
using BincomProjectApi.Repository.Data;
using BincomProjectApi.Repository.Implementation;
using BincomProjectApi.Repository.Interface;
using BincomProjectApi.Service.Implementation;
using BincomProjectApi.Service.Interface;
using BincomProjectApi.Service.JWT.Implementation;
using BincomProjectApi.Service.JWT.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<User, IdentityRole>()
       .AddEntityFrameworkStores<AppDbContext>()
       .AddDefaultTokenProviders();
builder.Services.Configure<IdentityOptions>(x =>
{
    x.User.RequireUniqueEmail = true;
}
);
builder.Services.AddCustomSwagger();
builder.Services.RegisterJwtServices(builder.Configuration);
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IRegisterService, RegisterService>();
builder.Services.AddScoped<IRegisterRepository, RegisterRepository>();
builder.Services.AddScoped<IGallaryRepository, GallaryRepository>();
builder.Services.AddScoped<IGallaryService, GallaryService>();
builder.Services.AddScoped<ICurriculumService, CurriculumService>();
builder.Services.AddScoped<ICurriculumRepository, CurriculumRepository>();
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
builder.Services.AddScoped<ITaxService, TaxService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
