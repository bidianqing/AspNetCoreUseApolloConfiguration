var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddApollo(builder.Configuration.GetSection("Apollo"));
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapControllers();

app.Run();
