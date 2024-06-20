using Newtonsoft.Json;

namespace StarkExplorerLib.Artefacts
{
    public class Block : Artefact
    {
        [JsonProperty("block_hash")]
        public string BlockHash { get; set; }

        [JsonProperty("block_number")]
        public long BlockNumber { get; set; }

        [JsonProperty("l1_gas_price")]
        public L1GasPrice L1GasPrice { get; set; }

        [JsonProperty("new_root")]
        public string NewRoot { get; set; }

        [JsonProperty("parent_hash")]
        public string ParentHash { get; set; }

        [JsonProperty("sequencer_address")]
        public string SequencerAddress { get; set; }

        [JsonProperty("starknet_version")]
        public string StarknetVersion { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("transactions")]
        public Transaction[] Transactions { get; set; }
    }




















}
