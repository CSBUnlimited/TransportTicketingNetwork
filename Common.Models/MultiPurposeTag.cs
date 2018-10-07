namespace Common.Models
{
    public class MultiPurposeTag
    {
        public int Id { get; set; }

        public int MultiPurposeTagTypeId { get; set; }
        public MultiPurposeTagType MultiPurposeTagType { get; set; }

        public int EnumValue { get; set; }
        public string EnumValueName { get; set; }
        public string Description { get; set; }
    }
}
