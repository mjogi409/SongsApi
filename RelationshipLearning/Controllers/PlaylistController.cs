using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RelationshipLearning.Models;
using RelationshipLearning.Services;
using RelationshipLearning.ViewModels;

namespace RelationshipLearning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly IPlaylistService _playlistService;

        public PlaylistController(IPlaylistService playlistService)
        {
            _playlistService = playlistService;
        }

        [HttpGet]
        public IActionResult GetAllPlaylist()
        {
            return Ok(_playlistService.GetallPlaylist());
        }
        [HttpPost]
        public IActionResult CreatePlaylist(PlaylistView playlist)
        {
            return Ok(_playlistService.CreatePlaylist(playlist));
        }
        [HttpPut("{playlistid}")]
        public IActionResult UpdatePlaylist(PlaylistView playlist, [FromRoute] int playlistid)
        {
            return Ok(_playlistService.UpdatePlaylist(playlist,playlistid));
        }
        [HttpDelete("{playlistid}")]
        public IActionResult DeletePlaylist([FromRoute]int playlistid) {
            return Ok(_playlistService.DeletePlaylist(playlistid));
        }

    }
}
