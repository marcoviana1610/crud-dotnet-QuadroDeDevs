using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;
using WebApplication1.Service.DevService;

namespace WebApplication1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DevController : ControllerBase
    {


        private readonly IDevInterface _devInterface;
        public DevController(IDevInterface devInterface)
        {
            _devInterface = devInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<DevModel>>>> GetDevs()
        {
            return Ok(await _devInterface.GetDevs());
        }

        [HttpGet("getbyid")]
        public async Task<ActionResult<ServiceResponse<DevModel>>> GetDevById(int id) 
        {
            return Ok( await _devInterface.GetDevById(id));
        }


        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<DevModel>>>> CreateDev(DevModel newDev)
        {
            return Ok(await _devInterface.CreateDev(newDev));
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<DevModel>>> DeleteDev(int id)
        {
            return Ok(await _devInterface.DeleteDev(id));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<DevModel>>> UpdateDev(DevModel editDev)
        {
            return Ok(await _devInterface.UpdateDev(editDev));
        }
    }
}



