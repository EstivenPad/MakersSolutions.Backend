using MakersSolutions.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakersSolutions.Application.Services.Client
{
    public interface IClienteService
    {
        Task<List<ClientDto>> GetAllClient();
        Task<ClientDto> GetClient(int id);
        Task AddClient(ClientDto client);
        Task UpdateClient(ClientDto client);
        Task DeleteClient(int id);

    }
}
