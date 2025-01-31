using App.Domain.AppService;
using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Entities;
using App.Domain.Service;
using App.Infrastructure.EFCore;
using App.Infrastructure.EFCore.Repositories;
using Framework;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


builder.Services.AddRazorPages()
.AddRazorRuntimeCompilation();

#region Configuration
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));
#endregion

#region Register Services
builder.Services.AddScoped<IUserRepository, UserRepository>();  
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserAppService , UserAppService>();

builder.Services.AddScoped<IRequestRepository, RequestRepository>();    
builder.Services.AddScoped<IRequestService, RequestService>();    
builder.Services.AddScoped<IRequestAppService, RequestAppService>();    


builder.Services.AddScoped<IVehicleModelRepository, VehicleModelRepository>();       
builder.Services.AddScoped<IVehicleModelService, VehicleModelService>();    
builder.Services.AddScoped<IVehicleModelAppService, VehicleModelAppService>();    

builder.Services.AddScoped<ILogAppService, LogAppService>();
builder.Services.AddScoped<ILogService, LogService>();
builder.Services.AddScoped<ILogRepository, LogRepository>();
#endregion


builder.Services.AddIdentity<User, IdentityRole<int>>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
})
    .AddRoles<IdentityRole<int>>()
    .AddErrorDescriber<PersianIdentityErrorDescriber>()
    .AddEntityFrameworkStores<AppDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapRazorPages();

app.Run();
