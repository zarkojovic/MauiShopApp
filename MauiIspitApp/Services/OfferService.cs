using System.Text.Json;
using MauiIspitApp.Constants;
using MauiIspitApp.Models;

namespace MauiIspitApp.Services;

public class OfferService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public OfferService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async ValueTask<IEnumerable<Offer>> GetOffersAsync()
    {
        var httpClient = _httpClientFactory.CreateClient(AppConstants.HttpClientName);

        var response = await httpClient.GetAsync("masters/offers");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            if (!string.IsNullOrEmpty(content))
            {
                return JsonSerializer.Deserialize<IEnumerable<Offer>>(content);
            }
        }

        return Enumerable.Empty<Offer>();
    }
}