using Newtonsoft.Json;

namespace StarkExplorerLib.Artefacts
{
    public enum TypeEnum { DeployAccount, Invoke };


    public class Transaction : Artefact
    {
        [JsonProperty("calldata", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Calldata { get; set; }

        [JsonProperty("max_fee")]
        public string MaxFee { get; set; }

        [JsonProperty("nonce")]
        public string Nonce { get; set; }

        [JsonProperty("sender_address", NullValueHandling = NullValueHandling.Ignore)]
        public string SenderAddress { get; set; }

        [JsonProperty("signature")]
        public string[] Signature { get; set; }

        [JsonProperty("transaction_hash")]
        public string TransactionHash { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("class_hash", NullValueHandling = NullValueHandling.Ignore)]
        public string ClassHash { get; set; }

        [JsonProperty("constructor_calldata", NullValueHandling = NullValueHandling.Ignore)]
        public string[] ConstructorCalldata { get; set; }

        [JsonProperty("contract_address_salt", NullValueHandling = NullValueHandling.Ignore)]
        public string ContractAddressSalt { get; set; }
    }
}
