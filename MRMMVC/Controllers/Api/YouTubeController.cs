using MRMMVC.BAL;
using MRMMVC.Models;
using MRMMVC.Utilitis;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;


namespace MRMMVC.Controllers.Api
{
    public class YouTubeController : ApiController
    {
        private readonly IYouTubeRepository _youTubeRepository;

        public YouTubeController(IYouTubeRepository youTubeRepository)
        {
            _youTubeRepository = youTubeRepository;
        }

        // GET api/<controller>
        public async Task<List<YouTubeDetail>> Get()
        {
            try
            {
                return await _youTubeRepository.GetYouTubeDetailList() ;
            }
            catch (WebException ex) when ((ex.Response as HttpWebResponse)?.StatusCode == HttpStatusCode.InternalServerError)
            {
                Logger.Error("YouTubeController-GetMethod " + ex.Response+ "" + ex.Message);
                return null;
            }
           
        }

        // POST api/<controller>
        public async Task<List<YouTubeDetail>> PostAsync([FromBody]List<YouTubeDetail> youTubeDetailList)
        {
            try
            {
                if (youTubeDetailList != null)
                {
                    List<YouTubeDetail> listDeatils = new List<YouTubeDetail>();
                    foreach (var youTubeDetail in youTubeDetailList)
                    {
                        YouTubeDetail youTubeDeatilResult = await _youTubeRepository.SaveYouTubeDetail(youTubeDetail);
                        listDeatils.Add(youTubeDeatilResult);
                    }

                    return listDeatils;
                }
                else throw new NullParameterException(string.Format("The YouTubeList is null"));
            }
            catch (WebException ex) when ((ex.Response as HttpWebResponse)?.StatusCode == HttpStatusCode.InternalServerError)
            {
                Logger.Error("YouTubeController-PostAsync " + ex.Response + "" + ex.Message);
                return null;
            }
        }
    }

    public class NullParameterException : Exception
    {
        public NullParameterException(string message)
           : base(message)
        {
        }
    }
}