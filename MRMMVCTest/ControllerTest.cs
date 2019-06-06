using Moq;
using MRMMVC.BAL;
using MRMMVC.Controllers.Api;
using MRMMVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace MRMMVCTest
{
    public class ControllerTest
    {
        [Fact]
        public async Task GetAllVideoGetsCorrectResult()
        {
            var expected = new List<YouTubeDetail>(1) {
         new YouTubeDetail() { ID = 1, ThumbnailImage = "ThumbnailImage", VideoId = "VideoId", Title = "Title" }
               };
            Mock<IYouTubeRepository> mockRepository = new Mock<IYouTubeRepository>();
            mockRepository.Setup(x => x.GetYouTubeDetailList()).Returns(() => Task.FromResult(expected));
            var controller = new YouTubeController(mockRepository.Object);

            List<YouTubeDetail> response = await controller.Get();
            Assert.Equal(expected.Count, response.Count);
        }
    }
}
