using CarInfo.Registrar;
using CarInfo.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.AddServices();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlerMiddleware>();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();

app.Run();