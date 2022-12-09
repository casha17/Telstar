using Newtonsoft.Json;
using System.Globalization;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text.Json.Serialization;
using Telstar.DTOs;
using Telstar.Models;
using static Humanizer.In;

namespace Telstar.service
{
    public class CalloutService : ICalloutService
    {
        public Task<List<EdgeResponseDTO>> calloutEITC(Shipment shipment)
        {
            EITCRequestDto requestDto = new EITCRequestDto()
            {
                name = "Oceanic Airlines",
                weight = 50,
                type = "Live Animals",
                timestamp = "05/01/2008",
                recommended = false
            };
            return this.edgesCallout(Company.EITC.uri, requestDto);
        }

        public Task<List<EdgeResponseDTO>> calloutOA(Shipment shipment)
        {
            OARequestDTO requestDto = new OARequestDTO()
            {
                depth = 12,
                height= 12,
                width= 12,
                weight = 12,
                type = "Regular"
            };
            return this.edgesCallout(Company.OA.uri, requestDto);
        }

        private async Task<List<EdgeResponseDTO>> edgesCallout(Uri uri, RequestDto shipment)
        {
            HttpClient client = new HttpClient();
            String serialized = JsonConvert.SerializeObject(shipment);
            String serialized1 = "{\"weight\": 12,\"height\": 12,\"width\": 12,\"depth\": 12,\"type\": \"Regular\"}";
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
            requestMessage.Content = new StringContent(serialized);
            requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.SendAsync(requestMessage);
            String responseBody = await response.Content.ReadAsStringAsync();
            var returnVal = JsonConvert.DeserializeObject<List<EdgeResponseDTO>>(responseBody);
            return returnVal;
        }
    }
}
