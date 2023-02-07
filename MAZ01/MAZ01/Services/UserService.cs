using MAZ01.Dtos;
using MAZ01.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MAZ01.Services;

public class UserService
{
    private readonly JwtStoreService jwtStoreService;

    public APIResult APIResult { get; set; } = new();
    public LoginResponseDto LoginResponseDto { get; set; } = new();

    public UserService(JwtStoreService jwtStoreService)
    {
        this.jwtStoreService = jwtStoreService;
    }

    public async Task LoginAsync(string account, string password)
    {
        try
        {
            APIResult = new();
            HttpClient client = new HttpClient();

            LoginRequestDto loginRequestDto = new LoginRequestDto()
            {
                Account = account,
                Password = password,
            };
            jwtStoreService.Delete();
            var responseMessage = await client
                .PostAsJsonAsync<LoginRequestDto>(MagicValue.LoginApiEndpoint,
                loginRequestDto);
            APIResult = await responseMessage.Content.ReadFromJsonAsync<APIResult>();
            if (responseMessage.IsSuccessStatusCode)
            {
                if (APIResult.Status == true)
                {
                    LoginResponseDto = JsonConvert
                        .DeserializeObject<LoginResponseDto>(
                        APIResult.Payload.ToString());
                    jwtStoreService.SetJwt(LoginResponseDto);
                    await jwtStoreService.WriteAsync();
                }
            }
        }
        catch (Exception ex)
        {
            APIResult.Status = false;
            APIResult.Message = ex.Message;
        }
    }

    public bool Logout()
    {
        return jwtStoreService.Delete();
    }

    public async Task RefreshTokenAsync()
    {
        try
        {
            APIResult = new();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",
                jwtStoreService.JwtStore.LoginResponseDto.RefreshToken);
            var responseMessage = await client
                .GetAsync(MagicValue.RefreshTokenApiEndpoint);
            APIResult = await responseMessage.Content
               .ReadFromJsonAsync<APIResult>();
            if (responseMessage.IsSuccessStatusCode)
            {
                if (APIResult.Status == true)
                {
                    LoginResponseDto = JsonConvert
                        .DeserializeObject<LoginResponseDto>(
                        APIResult.Payload.ToString());
                    jwtStoreService.SetJwt(LoginResponseDto);
                    await jwtStoreService.WriteAsync();
                }
            }
        }
        catch (Exception ex)
        {
            APIResult.Status = false;
            APIResult.Message = ex.Message;
        }
    }
}
