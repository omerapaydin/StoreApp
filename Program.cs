using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StoreApp.Data.Abstract;
using StoreApp.Data.Concrete;
using StoreApp.Data.Concrete.EfCore;
using StoreApp.Entity;
using StoreApp.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<Cart>();
builder.Services.AddScoped<IEmailSender, SmtpEmailSender>(i =>
    new SmtpEmailSender(
        builder.Configuration["EmailSender:Host"],
        builder.Configuration.GetValue<int>("EmailSender:Port"),
        builder.Configuration.GetValue<bool>("EmailSender:EnableSSL"),
        builder.Configuration["EmailSender:Username"],
        builder.Configuration["EmailSender:Password"]
    ));

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


builder.Services.AddDbContext<IdentityContext>(options => {
    options.UseSqlite(builder.Configuration.GetConnectionString("sql_connection"));
});

builder.Services.AddIdentity<ApplicationUser,IdentityRole>().AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>( options =>{
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;  
    options.User.RequireUniqueEmail = true;  
     options.SignIn.RequireConfirmedEmail = true;
}
);

builder.Services.AddScoped<IPostRepository,EfPostRepository>();
builder.Services.AddScoped<ICommentRepository,EfCommentRepository>();
builder.Services.AddScoped<Cart>();
builder.Services.AddScoped<IOrderRepository,EfOrderRepository>();
builder.Services.AddScoped<ICategoryRepository,EfCategoryRepository>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();



builder.Services.ConfigureApplicationCookie(options =>{
    options.LoginPath = "/Account/Login"; 

    //  options.SlidingExpiration = true;
    // options.ExpireTimeSpan = TimeSpan.FromDays(30);      // 30 gün boyunca hesap açık kalır
});


var app = builder.Build();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();


app.MapControllerRoute(
    name : "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"

);

app.MapRazorPages();

app.Run();
