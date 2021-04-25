using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetPropertiesController : ControllerBase
    {
        private readonly PropertyService _propertyService;

        public GetPropertiesController(PropertyService propertyService)
        {
            this._propertyService = propertyService;
        }

        [HttpGet("{id}")]
        public ActionResult<List<Property>> GetTodoItem(long id)
        {
            List<Property> propertys = _propertyService.getPropertisByOwnerId(id);

            if (propertys == null)
            {
                return NotFound();
            }

            return propertys;
        }

    }
}
