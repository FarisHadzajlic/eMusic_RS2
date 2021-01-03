using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace eMusic.Mobile.Models
{
    public class CreditCard
    {
        [JsonProperty("exp_month")]
        public long? ExpMonth { get; set; }
        [JsonProperty("exp_year")]
        public long? ExpYear { get; set; }
        [JsonProperty("number")]
        public string Number { get; set; }
        [JsonProperty("address_city")]
        public string AddressCity { get; set; }
        [JsonProperty("address_country")]
        public string AddressCountry { get; set; }
        [JsonProperty("address_line1")]
        public string AddressLine1 { get; set; }
        [JsonProperty("address_line2")]
        public string AddressLine2 { get; set; }
        [JsonProperty("address_state")]
        public string AddressState { get; set; }
        [JsonProperty("address_zip")]
        public string AddressZip { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("cvc")]
        public string Cvc { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("metadata")]
        public object MetaData { get; set; }
        [JsonProperty("issuing_card")]
        public string IssuingCardId { get; set; }
    }
}
