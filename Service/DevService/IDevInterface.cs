using WebApplication1.Model;

namespace WebApplication1.Service.DevService
{
    public interface IDevInterface
    {
        Task<ServiceResponse<List<DevModel>>> GetDevs();

        Task<ServiceResponse<List<DevModel>>> CreateDev(DevModel newDev);

        Task<ServiceResponse<DevModel>> GetDevById(int id);

        Task<ServiceResponse<List<DevModel>>> UpdateDev(DevModel editDev);

        Task<ServiceResponse<List<DevModel>>> DeleteDev(int id);
    }
}
