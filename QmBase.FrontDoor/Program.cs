using System.Text;

namespace QmBase.FrontDoor;
public class Program
{
    public static void Main()
    {
        using HttpClient client = new();

        // should be filled with real data
        string customDomainName = "domain.qmbase.com";
        string profileName = "qmBase";
        string resourceGroup = "Frontdoor";
        string subscriptionId = "874563874";
        string apiVersion = "1.0";

        string url = $"https://management.azure.com/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.Cdn/profiles/{profileName}/customDomains/{customDomainName}?api-version={apiVersion}";


        string data = "{'properties': {'hostName':'www.someDomain.net','tlsSettings': {'certificateType': 'ManagedCertificate','minimumTlsVersion': 'TLS12'},'azureDnsZone': {'id': ''}}}";
        HttpContent content = new StringContent(data, Encoding.UTF8, "application/json");
        HttpResponseMessage response = client.PutAsync(url, content).Result;

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
        }
        else
        {
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
        }
    }
}