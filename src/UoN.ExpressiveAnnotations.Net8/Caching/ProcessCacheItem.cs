using System.Collections.Generic;

namespace UoN.ExpressiveAnnotations.Net8.Caching
{
    internal class ProcessCacheItem
    {
        public IDictionary<string, string> FieldsMap { get; set; }
        public IDictionary<string, object> ConstsMap { get; set; }
        public IDictionary<string, object> EnumsMap { get; set; }
        public IEnumerable<string> MethodsList { get; set; }
        public IDictionary<string, string> ParsersMap { get; set; }
    }
}