using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApiAuthors.Data.Repositories.IGenericRepository;
using WebApiAuthors.Domain.Entity.Response;

namespace WebApiAuthors.Business.Services.Interfaces
{
    public interface IGenericService<EntityBase,EntityRequest,EntityResponse,TRepository>
        where EntityRequest:class
        where EntityBase:class
        where EntityResponse:class
        where TRepository: IGenericRepository<EntityBase,EntityRequest,EntityResponse>
    {
        TRepository Repository { get; set; }
        Task<GenericResponse<EntityBase>> CreateAsync(EntityRequest request);
        Task<EntityBase> EditAsync(IEnumerable<EntityRequest> request);
        EntityBase Create(EntityRequest request);
        EntityBase Edit(IEnumerable<EntityRequest> request);
        public void Delete(EntityRequest request);

        /*Search*/
        Task<IEnumerable<EntityBase>> GetAll();
    }
}
