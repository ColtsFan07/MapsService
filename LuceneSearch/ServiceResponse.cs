using System.Runtime.Serialization;

namespace LuceneSearch
{
    [DataContract]
    public class ServiceResponse
    {
        [DataMember]
        public string lat { get; set; }

        [DataMember]
        public string lng { get; set; }

        [DataMember]
        public string place_id { get; set; }
    }
}