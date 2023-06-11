using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using webapi_project.Models;
using webapi_project.Models.DTO;
using webapi_project.Repository.IRepository;

namespace webapi_project.Controllers
{
    [Route("api/NationalPark")]
    [ApiController]
    public class NationalParkController : ControllerBase
    {
        private readonly InationalParkRepository _nationalParkRepository;
        private readonly IMapper _mapper;
        public NationalParkController(InationalParkRepository nationalParkRepository,IMapper mapper)
        {
            _nationalParkRepository = nationalParkRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetNationalParks() { 
            var NationalParklistdto = _nationalParkRepository.GetNationalParks().ToList().Select(_mapper.Map<NationalPark,NationalParkDTO>);
            return Ok(NationalParklistdto);
        }
        [HttpGet("{NationalParkid:int}"/*, Name = "GetNationalPark*/)]
        public IActionResult GetNationalPark(int nationalParkId)
        {
            var nattionalpark = _nationalParkRepository.GetNationalPark(nationalParkId);
            if(nattionalpark == null) return NotFound();
            var nationalparkdto = _mapper.Map<NationalParkDTO>(nattionalpark);
            return Ok(nationalparkdto); //200 (Status code for success)
        }
        [HttpPost]
        public IActionResult CreateNationalPark([FromBody] NationalParkDTO nationalParkDTO)
        {
            if (nationalParkDTO == null) return BadRequest(ModelState);
            if (_nationalParkRepository.NationalParkExists(nationalParkDTO.Name))
                {
                ModelState.AddModelError("", "National Park in Db");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var nationalPark = _mapper.Map<NationalParkDTO,NationalPark>(nationalParkDTO);

            if (!_nationalParkRepository.CreateNationalPark(nationalPark))
            {
                ModelState.AddModelError("", $"Semthing Went Wrong while saving data :{nationalPark.Name}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok();
           // return CreatedAtRoute("GetNationalPark", new { nationalParkId=nationalPark.Id },nationalPark);
        }
        [HttpPut]
        public IActionResult UpdateNationalPark([FromBody] NationalParkDTO nationalParkDTO)
        {
            if (nationalParkDTO == null) return BadRequest(ModelState);
            if (!ModelState.IsValid) return BadRequest();
            var nationalpark = _mapper.Map<NationalPark>(nationalParkDTO);
            if(!_nationalParkRepository.UpdateNationalPark(nationalpark))
            {
                ModelState.AddModelError("", $"Something went wrong while save data :{nationalpark.Name}" );
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return NoContent();
        }
        [HttpDelete("{NationalParkid:int}")]
        public IActionResult DeleteNationPark(int nationalParkId)
        {
            if(! _nationalParkRepository.NationalParkExist(nationalParkId))
                return NotFound();
            var nationalPark = _nationalParkRepository.GetNationalPark(nationalParkId);
            if(nationalPark == null) return NotFound();
            if (!_nationalParkRepository.DeleteNationalPark(nationalPark))
            {
                ModelState.AddModelError("", $"Something went wrong while delete data:{nationalPark.Id}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok();
        }
    }
}
