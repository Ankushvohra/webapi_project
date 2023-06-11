using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi_project.Models.DTO;
using webapi_project.Models;
using webapi_project.Repository.IRepository;
using webapi_project.Repository;

namespace webapi_project.Controllers
{
    [Route("api/Trail")]
    [ApiController]
    public class TrailController : ControllerBase
    {
        private readonly Itrail _itrail;
        private readonly IMapper _mapper;
        public TrailController(Itrail itrail,IMapper mapper)
        {
            _itrail = itrail;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Gettrail() {
            var gettraildto = _itrail.Getrails().ToList().Select(_mapper.Map<trail, TrailDTO>);
            return Ok(gettraildto);
        }
        [HttpGet("{trailid:int}")]
        public IActionResult Gettrail(int trailId)
        {
            var trailid = _itrail.GetTrail(trailId);
            if (trailid == null) return NotFound();
            var traildto= _mapper.Map<TrailDTO>(trailid);
            return Ok(trailId); //200 (Status code for success)
        }
        [HttpPost]
        public IActionResult Creattrail([FromBody] TrailDTO traildto)
        {
            if (traildto == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            if (_itrail.trailExists(traildto.Name))
            {
                ModelState.AddModelError("", $"Trail in Db : {traildto.Name}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var trail = _mapper.Map<trail>(traildto);
            if (!_itrail.Createtrail(trail))
            {
                ModelState.AddModelError("", $"Something went wrong while save trail : {trail.Name}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return CreatedAtRoute("GetTrail",new {trailid = trail.Id},trail);
        }
        [HttpPut]
        public IActionResult UpdateTrail([FromBody] TrailDTO traildto)
        {
            if(traildto == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            var trail = _mapper.Map<trail>(traildto);
            if (!_itrail.Updatetrail(trail))
            {
                ModelState.AddModelError("", $"Something went wrong while save trail : {trail.Name}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return NoContent();
        }
        [HttpDelete]
        public IActionResult DeleteTrail(int trailid)
        {
            if (!_itrail.trailExist(trailid) ) return NotFound();
            var trail = _itrail.GetTrail(trailid);
            if(trail == null) return NotFound();
            if (!_itrail.Deletetrail(trail))
            {
                ModelState.AddModelError("", $"Something went wrong whole delete trial :{trail.Id}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok();
        }
    }
}
