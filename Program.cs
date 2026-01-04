var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Habilitar el uso de archivos estáticos desde wwwroot
app.Use(async(context, next) => // Middleware para redirigir la raíz a index.html
{
   if (context.Request.Path == "/")
   {
     context.Response.Redirect("/index.html"); // Redirigir a index.html
   }  else
    {
        await next(); // Continuar con el siguiente middleware
    }
});

app.MapControllers();

app.Run();