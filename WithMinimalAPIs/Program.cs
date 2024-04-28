using WithMinimallAPIs.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
UserEndpoints.AddServices(builder.Services);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

UserEndpoints.DefineEndpoints(app);

Console.WriteLine(@"---
--- Startomg WithMinimalAPIs
---");

app.Run();
