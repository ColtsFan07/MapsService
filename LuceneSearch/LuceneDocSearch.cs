using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuceneSearch
{
    public class LuceneDocSearch
    {
        static Analyzer GetAnalyzer()
        {
            return new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);
        }

        static Query GetQuery(string zip)
        {
            using (var analyzer = GetAnalyzer())
            {
                var parser = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, "ZIP_CD", analyzer);

                return parser.Parse(zip);
            }
        }

        static Directory GetDirectory()
        {
            return new SimpleFSDirectory(new System.IO.DirectoryInfo(@"C:\Users\parha\Documents\Indexes"));
        }

        static Sort GetSort()
        {
            var fields = new[] 
            {
                //new SortField("ID", SortField.STRING),
                SortField.FIELD_SCORE
            };

            return new Sort(fields); // sort by brand, then by score 
        }

        static Filter GetFilter()
        {
            return NumericRangeFilter.NewIntRange("ID", 1, 50, true, false); // [2; 5) range 
        } 

        public List<Place> Search(string zip)
        {
            using (var directory = GetDirectory())
            using (var searcher = new IndexSearcher(directory))
            {
                var query = GetQuery(zip);
                var sort = GetSort();
                var filter = GetFilter();
                var docs = searcher.Search(query, null, 30, sort);
                //count = docs.TotalHits;

                var places = new List<Place>();

                foreach (var scoreDoc in docs.ScoreDocs)
                {
                    var doc = searcher.Doc(scoreDoc.Doc);
                    var place = new Place
                    {
                        nelat = doc.Get("NELAT"),
                        nelng = doc.Get("NELON"),
                        swlat = doc.Get("SWLAT"),
                        swlng = doc.Get("SWLON"),
                        place_id = doc.Get("PLC_ID")
                    };

                    places.Add(place);
                }

                return places;
            }
        }
    }
}