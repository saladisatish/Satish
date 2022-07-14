using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using Microsoft.Azure.Devices;
using IoTHub.Models;
using Microsoft.Azure.Devices.Shared;

namespace IoTHub.Models
{
    public class Telemetry
    {
       static string connectionString ="HostName=NxTIoTTraining.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=RlHaCMxWGXDfNA+0BPe7b8WPjOnS+7B7EUAfBQSMOzg=";
       static RegistryManager registryManager= RegistryManager.CreateFromConnectionString(connectionString);
       static DeviceClient Client=null;
       static string DeviceConnectionString="HostName=NxTIoTTraining.azure-devices.net;DeviceId=sgk;SharedAccessKey=PW/jVwX7SagMRxFVZSoXy3Eb/lWlHlkOxduiSWozfJo=";
    
       public static async Task SendDeviceToCloudMessageAsync(string deviceName)
     {
         try
        {
                Client = DeviceClient.CreateFromConnectionString(DeviceConnectionString,Microsoft.Azure.Devices.Client.TransportType.Mqtt);
                var device= await registryManager.GetTwinAsync(deviceName);
                ReportProperties properties= new ReportProperties();
                TwinCollection reportedProperties;
                reportedProperties=device.Properties.Reported;
                while (true)
                {
                    var telemetryDataPoint = new
                    {
                        temperature=reportedProperties["temperature"],
                        pressure=reportedProperties["pressure"],
                        supplyVoltageLevel=reportedProperties["supplyVoltageLevel"],
                        fullScale=reportedProperties["fullScale"],
                        frequency=reportedProperties["frequency"],
                        accuracy=reportedProperties["accuracy"],
                        resolution=reportedProperties["resolution"],
                        drift=reportedProperties["drift"],
                        sensorType=reportedProperties["sensorType"],
                    };
                    string messageString = "";
                    messageString= JsonConvert.SerializeObject(telemetryDataPoint);
                    var message= new Microsoft.Azure.Devices.Client.Message(Encoding.ASCII.GetBytes(messageString));
                    await Client.SendEventAsync(message);
                    Console.WriteLine("{0}> Sending message: {1}", DateTime.Now,messageString);
                    await Task.Delay(1000 * 10);
                }
                
            }
                catch (Exception ex)
            {
            
                throw ex;
            }
        }
      
    }
}