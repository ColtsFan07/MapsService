using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LuceneSearch
{
    public class Service1 : IService1
    {
        public List<Place> GetPlaces(string zipCode)
        {
            return new LuceneDocSearch().Search(zipCode);
        }
    }
}
