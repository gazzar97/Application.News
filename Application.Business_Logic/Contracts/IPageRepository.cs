using Application.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Business_Logic.Contracts
{
    public interface IPageRepository
    {
        Task<IEnumerable<Page>> GetAll();
    }
}
