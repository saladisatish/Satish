using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IoTHub.Models;

namespace IoTHub.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewIoTController : ControllerBase
    {    
    [HttpPost]
       [Route("AddDevice")]
       public async Task AddDevice(string deviceId)
       {
                    await NewIoTDevice.AddDeviceAsync(deviceId);
       }
        [HttpGet]
       [Route("GetDevice")]
       public async Task GetDevice(string deviceId)
       {
                    await NewIoTDevice.GetDeviceAsync(deviceId);
       }
        [HttpDelete]
       [Route("RemoveDevice")]
       public async Task RemoveDevice(string deviceId)
       {
                    await NewIoTDevice.RemoveDeviceAsync(deviceId);
       }
       [HttpPut]
       [Route("UpdateDevice")]
      public async Task UpdateDevice(string deviceId)
       {
                    await NewIoTDevice.UpdateDeviceAsync(deviceId);
       }
    }
}