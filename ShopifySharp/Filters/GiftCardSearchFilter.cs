using Newtonsoft.Json;

namespace ShopifySharp.Filters
{
    public class GiftCardSearchFilter : ListFilter
    {
        /// <summary>
        /// The field and direction to order results by.
        /// Default: `disabled_at DESC`
        /// </summary>
        [JsonProperty("order")]
        public string Order { get; set; }
        
        /// <summary>
        /// The text to search for.
        /// </summary>
        [JsonProperty("query")]
        public string Query { get; set; }
        
        /// <summary>
        /// Show only certain fields, specified by a comma-separated list of field names.
        /// </summary>
        [JsonProperty("fields")]
        public string Fields { get; set; }
    }
}