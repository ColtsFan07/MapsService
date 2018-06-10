using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LuceneSearch
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<Place> GetPlaces(string zipCode);
    }

    [DataContract]
    public class Place
    {
        [DataMember]
        public string nelat { get; set; }

        [DataMember]
        public string nelng { get; set; }

        [DataMember]
        public string swlat { get; set; }

        [DataMember]
        public string swlng { get; set; }

        [DataMember]
        public string place_id { get; set; }
    }
}
