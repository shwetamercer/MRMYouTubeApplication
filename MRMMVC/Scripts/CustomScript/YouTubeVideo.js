$(document).ready(function () {

    var key = "AIzaSyDMeEiz-EL2Bg3Qb7-LkevvvCDkh60DGfk";
    var playlistId = 'UUE_M8A5yxnLfW0KghEeajjw';
    var URL = 'https://www.googleapis.com/youtube/v3/playlistItems';
    sum = 0;

   

    $.get("api/youtube",
        function (data) {
             displayResult(data);
    });



   
   

    function loadVideos(nextPageToken) {
        var pageoptions = {
            part: 'snippet',
            key: key,
            maxResults: 50,
            playlistId: playlistId,
            pageToken: nextPageToken
        };
      
        $.getJSON(URL, pageoptions, function (data) {
            resultsLoop(data);
              
        });
    }

    
   
  
  
    function resultsLoop(data) {
        var youTubeList = [];
        total = data.pageInfo.totalResults;
        nextPageToken = data.nextPageToken;
        $.each(data.items, function (i, item) {
            var thumb = item.snippet.thumbnails.medium.url;
            var title = item.snippet.title;
            var vid = item.snippet.resourceId.videoId;
           var  youTubeDetail = {
                thumbnailImage: thumb,
                title: title,
                videoId: vid
            };
            youTubeList.push(youTubeDetail);
            sum++;
            if (sum === (total - 1)) {
                sum = 0;
                return;
            }
        });

        $.ajax(
            {
                url: "api/youtube",
                type: "POST",
                data: { '': youTubeList } ,
                success: function (result) {
                    if (sum < (total - 1) && typeof nextPageToken !== 'undefined') {
                        loadVideos(nextPageToken);
                    }
                },
                error: function () { alert("Error"); }
            });
    }
   
    function displayResult(data) {
        $.each(data, function (i, item) {
            $('main').append(`
							<article class="item" data-key="${item.VideoId}">
								<img src="${item.ThumbnailImage}" alt="" class="thumb">
                                        <p>${item.Title}</p>
								<div class="details">
                                <a href="https://www.youtube.com/embed/${item.VideoId}" target="blank" style="cursor:pointer">${item.Title}</a>
								</div>
							</article>
						`);
        });
    }

    
    $('#btnRefresh').on('click', function () {
        loadVideos("");
    });

});