using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using LeituraTabelasAzure;
using Newtonsoft.Json;

public class AzurePricesFetcher
{
    private static readonly HttpClient httpClient = new HttpClient();

    public async Task<pricesData> FetchPricesAsync(string url)
    {
        pricesData opricesData = new pricesData();
        try
        {
            var response = await httpClient.GetStringAsync(url);
//           var pricesData = JsonConvert.DeserializeObject<pricesData>(response);
            opricesData = JsonConvert.DeserializeObject<pricesData>(response);
            return opricesData;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao buscar preços: {ex.Message}");
        }
        return opricesData;
    }
}