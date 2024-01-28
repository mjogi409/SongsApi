using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RelationshipLearning;
using RelationshipLearning.Container;
using RelationshipLearning.Helper;
using RelationshipLearning.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options=> { 
    
    options.SerializerSettings.ReferenceLoopHandling  = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IArtistServices, ArtistService>();
builder.Services.AddScoped<ISongService, SongsService>();
builder.Services.AddScoped<IPlaylistService, PlaylistService>();

//inmemory db
builder.Services.AddDbContext<MydbContext>(options =>
{
    options.UseInMemoryDatabase("Songsdb");
});

//AutoMapper
builder.Services.AddAutoMapper(typeof(Program));


var app = builder.Build();

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
