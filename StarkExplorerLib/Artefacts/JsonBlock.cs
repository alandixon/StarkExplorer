using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarkExplorerLib.Artefacts
{
    internal class JsonBlock
    {
        [JsonProperty("jsonrpc")]
        public string Jsonrpc { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("result")]
        public Block Block { get; set; }
    }

    public partial class L1GasPrice
    {
        [JsonProperty("price_in_wei")]
        public string PriceInWei { get; set; }
    }
}
