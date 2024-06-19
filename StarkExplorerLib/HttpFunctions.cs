using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Text.Json;

namespace StarkExplorerLib
{
    public class HttpFunctions
    {
        internal static HttpClient httpClient = new HttpClient();

        static HttpFunctions()
        {
            httpClient.BaseAddress = new Uri("https://starknet-sepolia.infura.io/v3/" + Helper.GetEnvVar("INFURA_APIKEY"));
            httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");
        }

        public async static string GetBlockByNum(int blockNum)
        {
            var response = await httpClient.PostAsJsonAsync("Create", json);
        }

        public async static string GetLastBlockNum()
        {
            var response = await httpClient.PostAsJsonAsync("Create", json);
        }

    }
}
