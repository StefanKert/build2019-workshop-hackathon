using FluentAssertions;
using PhotoStoreDemo.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Xunit;

namespace PhotoStore.Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("images/flower1.jpg", new[] { "flower" })]
        [InlineData("images/leaf1.jpg", new[] { "leaf" })]
        [InlineData("images/sunset.jpg", new[] { "sunset" })]
        public async Task GetDescriptionForImage_ShouldReturn_ExpectedTags(string path, string[] expectedTags)
        {
            var  sut = new ImageDescriptionService();

            var imageDescription = await sut.GetDescriptionForImageAsync(path);
            imageDescription.Tags.Should().Contain(expectedTags);
        }
    }
}
