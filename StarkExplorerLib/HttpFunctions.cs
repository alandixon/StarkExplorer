using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Text.Json;
using System.Net.Http;

namespace StarkExplorerLib
{
    public class HttpFunctions
    {
        internal static HttpClient httpClient = new HttpClient();

        static HttpFunctions()
        {
            httpClient.BaseAddress = new Uri("https://starknet-sepolia.infura.io/v3/" + Helper.GetEnvVar("INFURA_APIKEY"));
            // httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");
        }

        public async static Task<HttpResponseMessage> GetBlockByNum(int blockNum)
        {
            string getBlockByNumJson = File.ReadAllText(@"Requests\GetBlockByNum.json");
            // Insert blockNum into request json
            string jsonWithBlockNum = getBlockByNumJson.Replace("?", blockNum.ToString());
            HttpResponseMessage response = await httpClient.PostAsync(httpClient.BaseAddress, new StringContent(jsonWithBlockNum));
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException();
            }
            return response;
        }

        public async static Task<HttpResponseMessage> GetLastBlockNum()
        {
            string getLastBlockNumJson =File.ReadAllText(@"Requests\GetLastBlockNum.json");
            HttpResponseMessage response = await httpClient.PostAsync(httpClient.BaseAddress, new StringContent(getLastBlockNumJson));
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException();
            }
            return response;
        }

    }
}
