using GoodVibe.Models.PropertyModels;
using GoodVibe.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GoodVibe.Controllers
{
    [Route("api/PropertyApi")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IProperties _properties;
        public PropertyController(IProperties properties)
        {
            _properties = properties;
        }

        [HttpGet("AllProperty")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PropertyView>> GetAllProperty()
        {
            var model = await _properties.GetAllProperty();
            return Ok(model);
        }

        [HttpGet("{id:int}", Name = "GetPropertyById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PropertyView>> GetById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var model = await _properties.GetById(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpGet("GetByCity")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PropertyView>> GetByCity(string city)
        {
            if (city == null)
            {
                return BadRequest();
            }
            var model = await _properties.GetByCity(city);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpGet("GetBystate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PropertyView>> GetByState(string state)
        {
            if (state == null)
            {
                return BadRequest();
            }
            var model = await _properties.GetByState(state);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }
        
        [HttpGet("GetByPinCode")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PropertyView>> GetByPinCode(int pinCode)
        {
            if (pinCode == 0)
            {
                return BadRequest();
            }
            var model = await _properties.GetByPinCode(pinCode);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpPost("AddProperty")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PropertyAdd>> AddProperty([FromBody] PropertyAdd propertyAdd)
        {
            var AddProperty = await _properties.AddProperty(propertyAdd);
            if(AddProperty != null)
            {
                return BadRequest("Failed to add property");
            }
            return Ok(AddProperty);

            //return createdatroute("getbyid", new { id = propertyadd.id }, propertyadd);
        }

        [HttpPut("{id:int}", Name = "UpdateProperty")]
        public async Task<ActionResult<PropertyUpdate>>  UpdateProperty(int id, [FromBody] PropertyUpdate propertyUpdate)
        {
            var AddProperty = await _properties.UpdateProperty(propertyUpdate);

            if (propertyUpdate == null || id != propertyUpdate.Id)
            {
                return BadRequest();
            }
            return Ok(AddProperty);
        }
    }
}
