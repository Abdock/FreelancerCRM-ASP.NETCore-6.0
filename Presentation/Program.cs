using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Persistence.Context;
using Presentation.Extensions;
using Presentation.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowsAll", policyBuilder =>
    {
        policyBuilder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingAttribute>())
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        options.SerializerSettings.DateFormatString = "dd-MM-yyyy";
        options.SerializerSettings.Formatting = Formatting.Indented;
    });
builder.Services.AddMediatR(Assembly.Load(nameof(Application)));
builder.Services.AddAutoMapper(expression => expression.AddMaps(nameof(Persistence), nameof(Application)));
builder.Services.AddUnitOfWork();
builder.Services.AddUriService();
builder.Services.AddPaginationService();
builder.Services.AddDbContext<CrmContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerOpenApi();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseCors("AllowsAll");

app.UseAuthorization();

app.MapControllers();

app.Run();