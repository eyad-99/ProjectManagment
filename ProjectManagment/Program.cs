using Microsoft.AspNetCore.Identity;
using ProjectManagment.context;
using Microsoft.EntityFrameworkCore;
using ProjectManagment.repositories.interfaces;
using ProjectManagment.repositories.concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using ProjectManagment.service;
using ProjectManagment.configs;
using System.Configuration;
using ProjectManagment.context.entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();




builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    

    options.SignIn.RequireConfirmedEmail = true;

});


//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//       .AddCookie(options =>
//       {
//           options.Events = new CookieAuthenticationEvents
//           {
//               OnSignedIn = async context =>
//               {
//                   var user = await context.HttpContext.RequestServices
//                       .GetRequiredService<UserManager<IdentityUser>>()
//                       .GetUserAsync(context.Principal);

//                   var claims = new List<Claim>
//                   {
//                        new Claim(ClaimTypes.Name, user.UserName),
//                   };

//                   // Add other claims as needed
//                   var roles = await context.HttpContext.RequestServices
//                       .GetRequiredService<UserManager<IdentityUser>>()
//                       .GetRolesAsync(user);

//                   foreach (var role in roles)
//                   {
//                       claims.Add(new Claim(ClaimTypes.Role, role));
//                   }

//                   var appIdentity = new ClaimsIdentity(claims);
//                   context?.Principal?.AddIdentity(appIdentity);
//               },
//           };
//       });
builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = "/login";
    config.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Set it to your desired duration
    config.SlidingExpiration = true; // Extend the expiration time with each request
});
builder.Services.AddScoped<IAccountRepository, AccountRepository> ();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.Configure<SMTPConfigModel>(builder.Configuration.GetSection("SMTPConfig"));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Signup}/{id?}");

app.Run();
