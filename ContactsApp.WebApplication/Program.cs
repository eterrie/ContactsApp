using ContactsApp.Data;
using ContactsApp.Data.Repository;
using ContactsApp.Data.UnitOfWorkPattern;
using ContactsApp.Infrastructure.Repository;
using ContactsApp.Infrastructure.Services;
using ContactsApp.Infrastructure.Transaction;
using ContactsApp.WebApplication.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>(options => options.GetNpgSqlOptions(builder.Configuration));

builder.Services.AddScoped<ValidationService>();
builder.Services.AddScoped<CounteragentsService>();
builder.Services.AddScoped<ContactsService>();

builder.Services.AddScoped<ICounteragentsRepository, CounteragentsRepository>();
builder.Services.AddScoped<IContactsRepository, ContactsRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddRazorPages();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();

app.Run();
