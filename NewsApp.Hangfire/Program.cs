using Hangfire;
using NewsApp.Hangfire;

var builder = WebApplication.CreateBuilder(args);

#region ConfigureService

builder.Services.AddControllers();

builder.Services.AddHangfire();

builder.Services.AddScoped();

#endregion

var app = builder.Build();

#region Configure

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHangfireDashboard();
    endpoints.MapGet("/", context =>
    {
        return Task.Run(() => context.Response.Redirect("/hangfire"));
    });
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
#endregion
app.Run();
