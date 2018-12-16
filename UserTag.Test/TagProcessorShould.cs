using System;
using System.Collections.Generic;
using UserTag.Models;
using Xunit;

namespace UserTag.Test
{
    public class TagProcessorShould
    {
        [Fact]
        public void Test1()
        {
            var sut = new TagProcessor();

            var list = new List<UserAnnotations>
            {
                new UserAnnotations
                {
                    UserName = "John",
                    Tags = new List<Tag>
                    {
                        new Tag
                        {
                            Category = "Dogs",
                            StartIndex = 0,
                            EndIndex = 10
                        },
                        new Tag
                        {
                            Category = "Dogs",
                            StartIndex = 0,
                            EndIndex = 10
                        },
                        new Tag
                        {
                            Category = "Cats",
                            StartIndex = 0,
                            EndIndex = 10
                        }
                    }
                },
                new UserAnnotations
                {
                    UserName = "Jane",
                    Tags = new List<Tag>
                    {
                        new Tag
                        {
                            Category = "Dogs",
                            StartIndex = 0,
                            EndIndex = 10
                        },
                        new Tag
                        {
                            Category = "Dogs",
                            StartIndex = 0,
                            EndIndex = 110
                        },
                        new Tag
                        {
                            Category = "Cats",
                            StartIndex = 0,
                            EndIndex = 10
                        }
                    }
                }
            };

            sut.DisambiguateTags(list);
        }
    }
}
