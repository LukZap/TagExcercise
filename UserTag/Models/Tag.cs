using System;

namespace UserTag.Models
{
    public class Tag
    {
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
        public string Category { get; set; }

        public override bool Equals(object value)
        {
            Tag tag = value as Tag;

            return !Object.ReferenceEquals(null, tag)
                && StartIndex == tag.StartIndex
                && EndIndex == tag.EndIndex
                && String.Equals(Category, tag.Category);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                const int HashingBase = (int)2166136261;
                const int HashingMultiplier = 16777619;

                int hash = HashingBase;
                hash = (hash * HashingMultiplier) ^ StartIndex;
                hash = (hash * HashingMultiplier) ^ EndIndex;
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, Category) ? Category.GetHashCode() : 0);
                return hash;
            }
        }
    }
}
