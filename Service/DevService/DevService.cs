using Microsoft.EntityFrameworkCore;
using WebApplication1.DataContext;
using WebApplication1.Model;
using WebApplication1.DataContext;

namespace WebApplication1.Service.DevService
{
    public class DevService : IDevInterface
    {
        private readonly ApplicationDbContext _context;
        public DevService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<DevModel>>> CreateDev(DevModel newDev)
        {
            ServiceResponse<List<DevModel>> serviceResponse = new ServiceResponse<List<DevModel>>();

            try
            {
                if(newDev == null) {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informe os dados necessários para cadastrar um novo Desenvolvedor";
                    serviceResponse.Sucesso = false;
                }


                _context.Add(newDev);
                await _context.SaveChangesAsync();



            } catch (Exception ex) {
            
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<DevModel>>> DeleteDev(int id)
        {
           ServiceResponse<List<DevModel>> serviceResponse = new ServiceResponse<List<DevModel>>();


            try
            {
                DevModel desenvolvedor = _context.Desenvolvedores.FirstOrDefault(x => x.Id == id) ;

                if(desenvolvedor != null)
                {
                    _context.Remove(desenvolvedor);
                    serviceResponse.Dados = null;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    serviceResponse.Mensagem = "Usuário não encontrado";
                    serviceResponse.Sucesso = false;
                }


            } catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<DevModel>> GetDevById(int id)
        {
            ServiceResponse<DevModel> serviceResponse = new ServiceResponse<DevModel>();

            try
            {                
                DevModel dev = _context.Desenvolvedores.FirstOrDefault(x => x.Id == id);

                

                if (dev != null)
                {
                    serviceResponse.Dados = dev;
                    serviceResponse.Mensagem = $" Desenvolvedor encontrado com a chave {dev.Id} ";
                } else
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Não encontramos nenhum desenvolvedor com esta chave";
                    serviceResponse.Sucesso = false;
                }





            } catch (Exception ex)
            {

            }

            return serviceResponse;



        }

        public async Task<ServiceResponse<List<DevModel>>> GetDevs()
        {
            ServiceResponse<List<DevModel>> serviceResponse = new ServiceResponse<List<DevModel>>();

            try {

                serviceResponse.Dados = _context.Desenvolvedores.ToList();


                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado foi encontrado";
                } else if (serviceResponse.Dados.Count > 0) {
                    serviceResponse.Mensagem = "Dados encontrados com sucesso";
                }

                


            } catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<List<DevModel>>> UpdateDev(DevModel editDev)
        {
            ServiceResponse<List<DevModel>> serviceResponse = new ServiceResponse<List<DevModel>>();

            try
            {
                DevModel dev = _context.Desenvolvedores.AsNoTracking().FirstOrDefault(x => x.Id == editDev.Id);

                if( dev == null )
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Não existe nenhum dev com esse Id";
                    serviceResponse.Sucesso = false;
                }

                dev.DataAlteracao = DateTime.Now.ToLocalTime();

                _context.Desenvolvedores.Update(editDev);
                await _context.SaveChangesAsync();


                serviceResponse.Dados = _context.Desenvolvedores.ToList();


            } catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }
    }
}
