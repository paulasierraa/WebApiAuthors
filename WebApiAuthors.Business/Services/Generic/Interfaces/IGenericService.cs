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
        Task<GenericResponse<EntityBase>> EditAsync(EntityBase request);
        GenericResponse<EntityBase> Create(EntityRequest request);
        GenericResponse<EntityBase> Edit(EntityBase request);
        public GenericResponse<bool> Delete(EntityRequest request);

        /*Search*/
        Task<GenericResponse<IEnumerable<EntityBase>>> GetAll();
    }
}
