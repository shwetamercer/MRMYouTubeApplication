using MRMMVC.DAL;
using MRMMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MRMMVC.BAL
{
    public class YouTubeRepository : IYouTubeRepository
    {
      

        public YouTubeRepository()
        {
        }

        
        public async Task<List<YouTubeDetail>> GetYouTubeDetailList()
        {
            try
            {
                using (var _dbContext = new YouTubeContext())
                {
                    return await _dbContext.YouTubeDetails.ToListAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task<YouTubeDetail> SaveYouTubeDetail(YouTubeDetail youTubeDetail)
        {
            try
            {
                using (var context = new YouTubeContext())
                {
                    bool exists = await context.YouTubeDetails.AnyAsync(x => x.VideoId == youTubeDetail.VideoId);
                    if (!exists)
                    {
                        context.YouTubeDetails.Add(youTubeDetail);
                        await context.SaveChangesAsync();
                        return youTubeDetail;
                    }
                    else return new YouTubeDetail();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}