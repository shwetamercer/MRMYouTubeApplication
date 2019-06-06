using MRMMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRMMVC.DAL
{
    public class YouTubeInitializer
    {
        protected  void Seed(YouTubeContext context)
        {
            
            List<YouTubeDetail> youTubeDetailList = new List<YouTubeDetail>
            {
                new YouTubeDetail{Title="Seeding Title Video",ThumbnailImage="ImageName",VideoId="xyztbb" }
                
            };

            youTubeDetailList.ForEach(s => context.YouTubeDetails.Add(s));
            context.SaveChanges();
        }
    }
}