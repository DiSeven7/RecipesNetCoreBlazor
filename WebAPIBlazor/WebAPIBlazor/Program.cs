using WebAPIBlazor.Components;
using WebAPIBlazor.Components.Extensions;
using WebAPIBlazor.Components.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddHttpClient<IUsuarioService, UsuarioService>(client =>

    client.BaseAddress = new Uri($"{builder.Configuration.GetSection("UriApi").Value}/Usuarios/")
);

builder.Services.AddHttpClient<IRecetaService, RecetaService>(client =>
    client.BaseAddress = new Uri($"{builder.Configuration.GetSection("UriApi").Value}/Recetas/")
);

builder.Services.AddSingleton(builder.Configuration);

builder.Services.AddSingleton<ObjectTransporter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(WebAPIBlazor.Client._Imports).Assembly);

app.Run();
