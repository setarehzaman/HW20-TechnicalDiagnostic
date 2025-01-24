using App.Domain.AppService;
using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Contracts.Service;
using App.Domain.Service;
using App.Infrastructure.EFCore;
using App.Infrastructure.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


builder.Services.AddRazorPages()
.AddRazorRuntimeCompilation();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IAdminRepository, AdminRepository>();  
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IAdminAppService , AdminAppService>();

builder.Services.AddScoped<IRequestRepository, RequestRepository>();    
builder.Services.AddScoped<IRequestService, RequestService>();    
builder.Services.AddScoped<IRequestAppService, RequestAppService>();    


builder.Services.AddScoped<IVehicleModelRepository, VehicleModelRepository>();       
builder.Services.AddScoped<IVehicleModelService, VehicleModelService>();    
builder.Services.AddScoped<IVehicleModelAppService, VehicleModelAppService>();    

builder.Services.AddScoped<ILogAppService, LogAppService>();
builder.Services.AddScoped<ILogService, LogService>();
builder.Services.AddScoped<ILogRepository, LogRepository>();


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
