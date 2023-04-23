using Microsoft.Extensions.Configuration;
using Persistence.EFCore.Context;
using Microsoft.EntityFrameworkCore;
using Persistence.EFCore.Extensions;
using Application.Extensions;
using RestApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

{
    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddApplicationServices();
    builder.Services.AddPersistenceServices(builder.Configuration);
    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("ServerConnection"));
    });

}



{

    var app = builder.Build();

    app.UseSeed();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(options=>{
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "RestApi v1");
            options.RoutePrefix = string.Empty;
        });
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
