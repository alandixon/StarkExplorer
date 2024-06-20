using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StarkExplorerLib.Artefacts;
using System.IO;
using System.Net.Http.Json;
using System.Runtime.Serialization;
using System.Text;

namespace StarkExplorerLib.Infura
{
    public class SendRequestInfura : SendRequest
    {
        /// <summary> Get the last Block </summary>
        /// <returns>Block</returns>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="SerializationException"></exception>
        public static Block GetLastBlock()
        {
            Task<HttpResponseMessage> task = HttpFunctions.GetLastBlockNum();
            Stream jsonStream = task.Result.Content.ReadAsStream();
            string json;
            JsonLastBlockNum? jsonLastBlockNum = null;
            using (StreamReader streamReader = new StreamReader(jsonStream))
            {
                json = streamReader.ReadToEnd() ??
                    throw new NullReferenceException("GetLastBlock() returned null or empty json string");
            }
            jsonLastBlockNum = JsonConvert.DeserializeObject<JsonLastBlockNum>(json) ??
                throw new SerializationException($"GetLastBlock couldn't deserialize json string");
            int blockNum = Int32.Parse(jsonLastBlockNum.result.ToString());
            Block block = GetBlockByNum(blockNum);

            return block;
        }

        /// <summary> Get Block by BlockNum </summary>
        /// <param name="blockNum"></param>
        /// <returns>Block</returns>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="SerializationException"></exception>
        public static Block GetBlockByNum(int blockNum)
        {
            Task<HttpResponseMessage> task = HttpFunctions.GetBlockByNum(blockNum);
            Stream jsonStream = task.Result.Content.ReadAsStream();
            string? json;
            JsonBlock? jsonBlock = null;
            using (StreamReader streamReader = new StreamReader(jsonStream))
            {
                json = streamReader.ReadToEnd() ??
                    throw new NullReferenceException($"GetBlockByNum() for id={blockNum} returned null or empty json string");
            }

            jsonBlock = JsonConvert.DeserializeObject<JsonBlock>(json) ??
                throw new SerializationException($"GetBlockByNum() for id={blockNum} couldn't deserialize json string");
            return jsonBlock.Block;
        }
    }

}

