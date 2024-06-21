using Newtonsoft.Json;

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
