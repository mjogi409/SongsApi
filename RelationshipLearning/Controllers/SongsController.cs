using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RelationshipLearning.Models;
using RelationshipLearning.Services;
using RelationshipLearning.ViewModels;

namespace RelationshipLearning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ISongService _songService;

        public SongsController(ISongService songService)
        {
            _songService = songService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_songService.GetallSongs());
        }
        [HttpPost]
        public IActionResult Create(SongsView songs)
        {

            return Ok(_songService.AddSong(songs));
        }

        [HttpPut("{id}")]  
        public IActionResult Update(SongsView songs, [FromRoute]int id)
        {
            return Ok(_songService.UpdateSong(songs,id));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            return Ok(_songService.RemoveSongs(id));
        }
        [HttpGet("{id}")]
        public IActionResult Update([FromRoute] int id)
        {
            return Ok(_songService.GetSongsbyID(id));
        }

    }
}
