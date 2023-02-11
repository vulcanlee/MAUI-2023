using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region 進行 Microsoft OAhtu 身分驗證的服務註冊
// https://learn.microsoft.com/zh-tw/aspnet/core/security/authentication/social/microsoft-logins?view=aspnetcore-7.0
IConfiguration Configuration = builder.Configuration;

builder.Services.AddAuthentication(o =>
{
    o.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
    .AddCookie()
    .AddMicrosoftAccount(ms =>
    {
        ms.ClientId = Configuration["Authentication:Microsoft:ClientId"];
        ms.ClientSecret = Configuration["Authentication:Microsoft:ClientSecret"];
        ms.SaveTokens = true;
    });
#endregion

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
