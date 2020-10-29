using CRUD.Application.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace CRUD.Application.Interfaces
{
    public interface IAddressService
    {
        Task<ViaCepModel> GetAddressByCep(string cep);
    }
}
