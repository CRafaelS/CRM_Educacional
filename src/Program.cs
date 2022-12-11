using educacional.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CrmEducacionalContext>(options =>
    options.UseSqlServer(@"
                Server=127.0.0.1;
                Database=crm_educacional_db;
                User=SA;
                Password=Password12!;
                TrustServerCertificate=true;
            "));

builder.Services.AddScoped<CandidatoRepository>();
builder.Services.AddScoped<CursoRepository>();
builder.Services.AddScoped<MatriculaRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
