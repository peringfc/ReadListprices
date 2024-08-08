
namespace LeituraTabelasAzure
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://prices.azure.com/api/retail/prices?api-version=2023-01-01-preview&$skip=1000";
            var priceFetcher = new AzurePricesFetcher();
            pricesData prices = await priceFetcher.FetchPricesAsync(url);

            Console.WriteLine($"-----------------------------------------------");
            Console.WriteLine($"{prices.NextPageLink}");

            string oLink = prices.NextPageLink;

            Boolean x = true; 

            while (x)
            {
                pricesData oprices = await priceFetcher.FetchPricesAsync(oLink);

                Console.WriteLine($"-----------------------------------------------");
                Console.WriteLine($"{oprices.NextPageLink}");
                Console.WriteLine($"-----------------------------------------------");
                oLink = oprices.NextPageLink;

                if (!oLink.Contains("https://prices.azure.com:443/api/retail/prices"))
                {
                    x = false;
                }
            }

            Console.ReadLine();

            //    foreach (var price in prices.Items)
            //    {
            //        try
            //        {

            //            Console.WriteLine($"-----------------------------------------------");
            //            Console.WriteLine($"currencyCode........: {price.currencyCode} ");
            //            Console.WriteLine($"tierMinimumUnits....: {price.tierMinimumUnits} ");
            //            Console.WriteLine($"retailPrice.........: {price.retailPrice} ");
            //            Console.WriteLine($"unitPrice...........: {price.unitPrice} ");
            //            Console.WriteLine($"armRegionName.......: {price.armRegionName} ");
            //            Console.WriteLine($"location............: {price.location} ");
            //            Console.WriteLine($"effectiveStartDate..: {price.effectiveStartDate} ");
            //            Console.WriteLine($"meterId.............: {price.meterId} ");
            //            Console.WriteLine($"meterName...........: {price.meterName} ");
            //            Console.WriteLine($"productId...........: {price.productId} ");
            //            Console.WriteLine($"skuId...............: {price.skuId} ");
            //            Console.WriteLine($"productName.........: {price.productName} ");
            //            Console.WriteLine($"skuName.............: {price.skuName} ");
            //            Console.WriteLine($"serviceName.........: {price.serviceName} ");
            //            Console.WriteLine($"serviceId...........: {price.serviceId} ");
            //            Console.WriteLine($"serviceFamily.......: {price.serviceFamily} ");
            //            Console.WriteLine($"unitOfMeasure.......: {price.unitOfMeasure} ");
            //            Console.WriteLine($"isPrimaryMeterRegion: {price.isPrimaryMeterRegion} ");
            //            Console.WriteLine($"armSkuName..........: {price.armSkuName} ");
            //        }
            //        catch (Exception ex)
            //        {
            //            Console.WriteLine("Erro:" + ex.Message.ToString());
            //        }

            //    }
            //}
        }
    }
}