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
    public class ArtistController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IArtistServices _artistServices;
        public ArtistController(IArtistServices artistservice, IMapper mapper1) {
            _artistServices = artistservice;
            _mapper = mapper1;
        }
        [HttpGet]
        public IActionResult Getall()
        {
            return Ok(
            _artistServices.GetallArtist());
        }

        [HttpPost]
        public IActionResult Create(ArtistView data)
        {
            if(_artistServices.AddArtist(data))
                return Ok("Created Successfully");
            return BadRequest();
        }

        [HttpPut]
        public IActionResult UpdateArtist(ArtistView data, int artistid)
        {
            if (_artistServices.UpdateArtist(data, artistid))
                return Ok("Updated Successfully");
            return BadRequest();
        }

        [HttpDelete]
        public IActionResult DeleteArtist(int artistid)
        {
            if (_artistServices.RemoveArtist(artistid))
                return Ok("Deleted");
            return BadRequest();
        }

        [HttpGet("{id}")]
        public IActionResult GetArtistById([FromRoute] int id)
        {
            return Ok(_artistServices.GetArtistsbyID(id));
        }
    }
}
