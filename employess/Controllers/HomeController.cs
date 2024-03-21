using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using employess.Models;

namespace employess.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly string endpoint = "https://rc-vault-fap-live-1.azurewebsites.net/api/gettimeentries?code={key}";

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<string> GetAllEmployees()
    {
        string responseBody = "";

        using(HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                responseBody = await response.Content.ReadAsStringAsync();
            }
            else
            {
                responseBody = "Greska pri preuzimanju podataka. Status code: " + response.StatusCode;
            }
        }

        return responseBody;
    }



}

