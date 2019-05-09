using System.Collections.Generic;

namespace PhotoStoreDemo.Models
{
    public class PhotoDescription
    {
        public string Description { get; set; }
        public IList<string> Tags{ get; set; }
    }
}