using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebApiAuthors.Data.Repositories.IGenericRepository
{
    public interface IGenericRepository<EntityBase,EntityRequest,EntityResponse>
        where EntityBase:class
        where EntityRequest:class
        where EntityResponse:class
    {
        Task<EntityBase> CreateAsync(EntityRequest request);
        Task<EntityBase> CreateMultipleAsync(IEnumerable<EntityRequest> request);
        Task<EntityBase> EditAsync(IEnumerable<EntityRequest> request);

        EntityBase Create(EntityRequest request);
        EntityBase CreateMultiple(IEnumerable<EntityRequest> request);
        EntityBase Edit(IEnumerable<EntityRequest> request);
        public void Delete(EntityRequest request);

        /*Search*/
        public IQueryable<EntityBase> Search(Expression<Func<EntityBase, bool>> predicate);
        Task<IEnumerable<EntityBase>> GetAll();

    }
}
