using Newtonsoft.Json.Linq;
using StarkExplorerLib.Artefacts;
using System.IO;
using System.Text;

namespace StarkExplorerLib.Infura
{
    public class SendRequestInfura : SendRequest
    {
        public static Block GetLastBlock()
        {
            Task<HttpResponseMessage> task = HttpFunctions.GetLastBlockNum();
            Stream jsonStream = task.Result.Content.ReadAsStream();
            string json;
            using (StreamReader streamReader = new StreamReader(jsonStream))
            {
                json = streamReader.ReadToEnd();
            }
            JObject jObject = JObject.Parse(json);
            int blockNum = Int32.Parse(jObject.SelectToken("result").ToString());

            Block block = GetBlockByNum(blockNum);

            return block;
        }

        public static Block GetBlockByNum(int blockNum)
        {
            Task<HttpResponseMessage> task = HttpFunctions.GetBlockByNum(blockNum);
            Stream jsonStream = task.Result.Content.ReadAsStream();
            string json;
            using (StreamReader streamReader = new StreamReader(jsonStream))
            {
                json = streamReader.ReadToEnd();
            }
            JObject jObject = JObject.Parse(json);
            string blockHash = jObject.SelectToken("result.block_hash").ToString();
            string status = jObject.SelectToken("result.status").ToString();
            string timestamp = jObject.SelectToken("result.timestamp").ToString();
            int transactionCount = jObject.SelectToken("result.transactions").Count();

            // ToDo: Deserialise the Block here

            return new Block();
        }
    }

}

