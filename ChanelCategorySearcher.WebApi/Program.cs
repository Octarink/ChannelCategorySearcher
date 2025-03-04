using ChanelCategorySearcher.BusinessLogic;
using ChanelCategorySearcher.DAI;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDataAccess();
builder.Services.AddBusinessLogic();
builder.WebHost.ConfigureKestrel(serverOptions =>
                    {
                        serverOptions.ListenAnyIP(5005, listenOptions =>
                        {
                            //listenOptions.UseHttps();
                        });
                    });
builder.WebHost.UseKestrel();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseDefaultFiles();
app.UseStaticFiles();
app.MapControllers();

app.Run();