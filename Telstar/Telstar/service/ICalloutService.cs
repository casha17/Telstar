using Telstar.DTOs;
using Telstar.Models;

namespace Telstar.service
{
    public interface ICalloutService
    {
        Task<List<EdgeResponseDTO>> calloutEITC(Shipment shipment);
        Task<List<EdgeResponseDTO>> calloutOA(Shipment shipment);
    }
}
