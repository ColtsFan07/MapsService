using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LuceneSearch
{
    [DataContract]
    public class ServiceRequest
    {
        [DataMember]
        public string zipCode { get; set; }
    }
}