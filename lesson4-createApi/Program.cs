using lesson4_createApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<DataContext>();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(opt=>opt.AddPolicy("MyPolice",policy=> { policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); })); 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("MyPolice");
app.UseAuthorization();

app.MapControllers();

app.Run();
