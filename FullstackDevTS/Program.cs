using FullstackDevTS.Config;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager config = builder.Configuration; //Builder.Configuraiton to Access appsettings.json

var serviceRegistration = new ServiceRegistration();

serviceRegistration.OnLoad(builder.Services,config); //Service to Initialize Database

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseForwardedHeaders();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();