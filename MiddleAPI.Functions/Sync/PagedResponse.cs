using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Sync.Entity
{
    [DataContract]
    public class PagedResponse<T> where T : class
    {
        [DataMember]
        public int PageSize { get; set; }
        [DataMember]
        public int PageIndex { get; set; }

        [DataMember]
        public int Total { get; set; }
        [DataMember]
        public IEnumerable<T> Results { get; set; }
    }
}
