using SeriesAPI.Data;
using SeriesAPI.Entities;
using SeriesAPI.Repositories;
using SeriesAPI.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDbContext<APIContext>();
//builder.Services.AddScoped<Repository<Serie>>();

var app = builder.Build();

app.Logger.LogInformation("The app started");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () =>
{
    throw new InvalidOperationException("Oops, the '/' route has thrown an exception.");
});

app.MapGet("v1/series", (APIContext context) => {
    IRepository<Serie> repository = new Repository<Serie>(context);

    var series = repository.GetAll();
    var teste = Results.Ok(series);
    return Results.Ok(series);
});

app.MapPost("v1/series", (APIContext context, Serie serie) => {
    IRepository<Serie> repository = new Repository<Serie>(context);

    repository.Insert(serie);
    return Results.Created($"v1/series/{serie.Id}", serie);
});

app.MapPut("v1/series{id}", (int id, APIContext context, Serie s) => {
    IRepository<Serie> repository = new Repository<Serie>(context);

    var serie = repository.GetById(id);
    if (serie is null) return Results.NotFound();
    serie.Update(s);
    repository.Update(serie);
    return Results.Ok(serie);
});

app.MapDelete("v1/series{id}", (int id, APIContext context) => {
    IRepository<Serie> repository = new Repository<Serie>(context);

    var serie = repository.GetById(id);
    if (serie is null) return Results.NotFound();
    repository.Delete(serie);
    return Results.NoContent();
});

app.Run();

