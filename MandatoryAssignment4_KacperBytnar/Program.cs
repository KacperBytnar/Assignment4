var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string allowAllPolicy = "AllowAll";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAll",
                              policy =>
                              {
                                  policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                              });
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("swagger/v1/swagger.json", "FootballPlayers");
    c.RoutePrefix = String.Empty;
});

app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();


app.Run();
