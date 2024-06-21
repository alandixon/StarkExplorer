using Newtonsoft.Json;
using StarkExplorerLib.Artefacts;
using System.Runtime.Serialization;

namespace StarkExplorerLib.Infura
{
    public class SendRequestInfura : SendRequest
    {

        /// <summary> Get a block </summary>
        /// <param name="blockNumValue">If empty, get the latest block</param>
        /// <returns>Specified block</returns>
        /// <exception cref="ArgumentException"></exception>
        public static Block GetBlock(string blockNumValue)
        {
            if (string.IsNullOrEmpty(blockNumValue))
            {
                // No blockNum provided: get the latest block
                return GetLastBlock();
            }
            else
            {
                // Try to read the blockNum
                int blockNum;
                if (!Int32.TryParse(blockNumValue, out blockNum))
                {
                    throw new ArgumentException($"Couldn't parse block number to an integer: {blockNumValue}");
                }
                return GetBlockByNum(blockNum);
            }
        }


        /// <summary> Get the last Block </summary>
        /// <returns>Block</returns>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="SerializationException"></exception>
        private static Block GetLastBlock()
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
        private static Block GetBlockByNum(int blockNum)
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

