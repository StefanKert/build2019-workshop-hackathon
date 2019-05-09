using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoStore.Models
{
    public class PhotoDescription
    {
        public string Description { get; set; }
        public IList<string> Tags { get; set; }
    }
}
