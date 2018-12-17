using System;
using System.Collections.Generic;
using UserTag.Models;
using Xunit;

namespace UserTag.Test.TagProcessorTests
{
    public class DisambiguateTagsShould
    {
        [Fact]
        public void ReturnOddTag()
        {
            // Arrange
            var sut = new TagProcessor();

            var listAnnotations = new List<UserAnnotations>
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
                            Category = "Cats",
                            StartIndex = 22,
                            EndIndex = 25
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
                            Category = "Cats",
                            StartIndex = 22,
                            EndIndex = 25
                        },
                        new Tag
                        {
                            Category = "Food",
                            StartIndex = 45,
                            EndIndex = 60
                        },
                    }
                }
            };

            // Act
            var tagsForExpertList = sut.DisambiguateTags(listAnnotations);

            //Assert
            Assert.Single(tagsForExpertList, x => x.Category == "Food");
        }

        [Fact]
        public void ReturnNoTagsWhenGetAnnotationsFromOneUser()
        {
            // Arrange
            var sut = new TagProcessor();

            var listAnnotations = new List<UserAnnotations>
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
                            Category = "Cats",
                            StartIndex = 22,
                            EndIndex = 25
                        }
                    }
                }                
            };

            // Act
            var tagsForExpertList = sut.DisambiguateTags(listAnnotations);

            //Assert
            Assert.Empty(tagsForExpertList);
        }

        [Fact]
        public void IgnoreDuplicateTagValuesForUser()
        {
            // Arrange
            var sut = new TagProcessor();

            var listAnnotations = new List<UserAnnotations>
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
                            Category = "Cats",
                            StartIndex = 22,
                            EndIndex = 25
                        },
                        new Tag
                        {
                            Category = "Cats",
                            StartIndex = 22,
                            EndIndex = 25
                        },
                    }
                }
            };

            // Act
            var tagsForExpertList = sut.DisambiguateTags(listAnnotations);

            //Assert
            Assert.Single(tagsForExpertList, x => x.Category == "Cats");
        }


        [Fact]
        public void ReturnBothTagsWhenDraw()
        {
            // Arrange
            var sut = new TagProcessor();

            var listAnnotations = new List<UserAnnotations>
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
                            StartIndex = 10,
                            EndIndex = 20
                        }
                    }
                }
            };

            // Act
            var tagsForExpertList = sut.DisambiguateTags(listAnnotations);

            //Assert
            Assert.Equal(2, tagsForExpertList.Count);
        }

        [Fact]
        public void ReturnNoTagsWhenAllUsersAgree()
        {
            // Arrange
            var sut = new TagProcessor();

            var listAnnotations = new List<UserAnnotations>
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
                            Category = "Cats",
                            StartIndex = 22,
                            EndIndex = 25
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
                            Category = "Cats",
                            StartIndex = 22,
                            EndIndex = 25
                        }
                    }
                }
            };

            // Act
            var tagsForExpertList = sut.DisambiguateTags(listAnnotations);

            //Assert
            Assert.Empty(tagsForExpertList);
        }


        [Fact]
        public void ThrowExceptionWithNullArgument()
        {
            // Arrange
            var sut = new TagProcessor();

            List<UserAnnotations> listAnnotations = null;
            
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => sut.DisambiguateTags(listAnnotations));
        }

        [Fact]
        public void ThrowExceptionWithEmptyListArgument()
        {
            // Arrange
            var sut = new TagProcessor();

            var listAnnotations = new List<UserAnnotations>();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => sut.DisambiguateTags(listAnnotations));
        }
    }
}
