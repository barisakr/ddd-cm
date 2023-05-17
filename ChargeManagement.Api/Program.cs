using ChargeManagement.Api;
using ChargeManagement.Application;
using ChargeManagement.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddPresentation()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

 

var app = builder.Build();

app.UseExceptionHandler("/error");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
