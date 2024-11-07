using Microsoft.EntityFrameworkCore;
using SharedUtilities.Middleware;
using TeamService.Persistence;
using TeamService.Services;
using TeamService.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TeamDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddHttpClient<IParticipantsServiceClient, ParticipantsServiceClient>(client => 
{
    var baseUrl = builder.Configuration["ParticipantsService:BaseURL"];
    client.BaseAddress = new Uri(baseUrl ?? string.Empty);
});

// Add services to the container.
builder.Services.AddScoped<ITeamsService,TeamsService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
