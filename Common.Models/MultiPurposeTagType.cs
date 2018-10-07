using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class MultiPurposeTagType
    {
        public int Id { get; set; }
        public string EnumName { get; set; }
        public string Description { get; set; }

        public IEnumerable<MultiPurposeTag> MultiPurposeTags { get; set; }

        public MultiPurposeTagType()
        {
            MultiPurposeTags = new HashSet<MultiPurposeTag>();
        }
    }
}
