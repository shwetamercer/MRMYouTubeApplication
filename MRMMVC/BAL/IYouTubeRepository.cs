using System.Collections.Generic;
using System.Threading.Tasks;
using MRMMVC.Models;

namespace MRMMVC.BAL
{
    public interface IYouTubeRepository
    {
        Task<List<YouTubeDetail>> GetYouTubeDetailList();
        Task<YouTubeDetail> SaveYouTubeDetail(YouTubeDetail youTubeDetail);
    }
}