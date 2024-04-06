using MakersSolutions.Application.Contracts;
using MakersSolutions.Application.Repositories;
using MakersSolutions.Core.Entities;
using MakersSolutions.DataAccess.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakersSolutions.DataAccess.Repositories
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(DataContext context) : base(context)
        {
            
        }
    }
}
