using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using sa_it2030_fa24_fp_team_3_it2030_fa24.Models;
using sa_it2030_fa24_fp_team_3_it2030_fa24.CustomMiddleware;
using Microsoft.AspNetCore.HttpLogging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpLogging(options => {
    options.LoggingFields = HttpLoggingFields.RequestPath;
});

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataContext>(opts => {
    opts.UseSqlServer(
        builder.Configuration["ConnectionStrings:CodeGeassConnection"]);
});


builder.Services.AddScoped<DataContext>();


var app = builder.Build();
//var RouteLogger = app.Services.GetRequiredService<ILoggerFactory>.CreateLogger("Routing");

//app.MapGet("/", () => "Hello World!");
app.UseHttpLogging();
app.UseMiddleware<sa_it2030_fa24_fp_team_3_it2030_fa24.CustomMiddleware.AliasMiddleware>();
app.UseRouting();
app.MapControllerRoute("Default", "{controller=CharactersController}/{action=All}");

SeedData.populate(app);

app.Run();
