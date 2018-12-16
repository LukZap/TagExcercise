using System;
using System.Collections.Generic;
using System.Linq;
using UserTag.Models;

namespace UserTag
{
    public class TagProcessor
    {
        public List<Tag> DisambiguateTags(List<UserAnnotations> annotations)
        {
            if (annotations == null)
                throw new ArgumentNullException();

            if(annotations.Count <= 0)
                throw new ArgumentException();

            // dictionary for Tag and it's count
            var TagDictionary = new Dictionary<Tag, int>();
            var contributorsCount = annotations.Count;
            var agreementPercentage = 0.5;
            var contributorsCountTreshold = agreementPercentage * contributorsCount;

            foreach (var annotation in annotations)
            {
                // clearing duplicate values for user
                var uniqueTags = annotation.Tags.Distinct().ToList();

                foreach (var tag in uniqueTags)
                {
                    // add or incement value depending if tag exists in dict
                    if(TagDictionary.ContainsKey(tag))
                    {
                        TagDictionary[tag] += 1;
                    }
                    else
                    {
                        TagDictionary.Add(tag, 1);
                    }
                }
            }

            var tagsForExpertList = new List<Tag>();

            foreach (var dictItem in TagDictionary)
            {
                if (dictItem.Value <= contributorsCountTreshold)
                    tagsForExpertList.Add(dictItem.Key);
            }

            return tagsForExpertList;
        }
    }
}
