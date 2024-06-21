namespace StarkExplorerLib
{
    public class HttpFunctions
    {
        internal static HttpClient httpClient = new HttpClient();

        static HttpFunctions()
        {
            // Set the base url
            string apikey = Helper.GetEnvVar("INFURA_APIKEY");
            if (string.IsNullOrEmpty(apikey))
            {
                throw new InvalidDataException("Can't find environment variable INFURA_APIKEY");
            }
            httpClient.BaseAddress = new Uri($"https://starknet-sepolia.infura.io/v3/{apikey}");
        }

        /// <summary> Get block by id, async  </summary>
        /// <param name="blockNum"></param>
        /// <returns>Response task encapsulating the block</returns>
        /// <exception cref="HttpRequestException"></exception>
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

        /// <summary> Get the latest block number, async </summary>
        /// <returns>Response task encapsulating the block number</returns>
        /// <exception cref="HttpRequestException"></exception>
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

        internal static async Task<HttpResponseMessage> GetTransaction(string blockNum, string transactionNum)
        {
            string getBlockByNumJson = File.ReadAllText(@"Requests\GetTransaction.json");
            // Insert blockNum into request json
            string jsonWithBlockNum = getBlockByNumJson.Replace("?", blockNum.ToString());
            string jsonWithBlockNumAndTransactionNum = jsonWithBlockNum.Replace("*", transactionNum.ToString());
            HttpResponseMessage response = await httpClient.PostAsync(httpClient.BaseAddress, new StringContent(jsonWithBlockNumAndTransactionNum));
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException();
            }
            return response;

        }
    }
}
