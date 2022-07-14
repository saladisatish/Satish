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
    public class IoTDeviceController : ControllerBase
    {
       [HttpPut]
       [Route("UpdateReportedDeviceProperty")]
       public async Task UpdateReportedDeviceProperty(string deviceName,ReportProperties reportedProperties)
       {
        await IoTDeviceProperties.UpdateReportedProperties(deviceName,reportedProperties);
       }
       [HttpPut]
       [Route("UpdatDesiredProperty")]
       public async Task UpdatDesiredProperty(string deviceName)
       {
        await IoTDeviceProperties.UpdateDesiredProperties(deviceName);
       }
       [HttpPut]
       [Route("UpdateTags")]
       public async Task UpdateTags(string deviceName)
       {
        await IoTDeviceProperties.AddTagsAndQuery(deviceName);
       }
       [HttpPost]
       [Route("SendDeviceToCloudMessagesAsync")]
       public async Task SendDeviceToCloudMessageAsync(string deviceName)
       {
        await Telemetry.SendDeviceToCloudMessageAsync(deviceName);
       }
    }
}