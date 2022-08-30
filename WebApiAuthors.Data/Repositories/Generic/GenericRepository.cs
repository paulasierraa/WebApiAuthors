using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApiAuthors.Data.Repositories.IGenericRepository;
using WebApiAuthors.Domain.Context;

namespace WebApiAuthors.Data.GenericRepository
{
    public class GenericRepository<EntityBase, EntityRequest, EntityResponse>
         : IGenericRepository<EntityBase, EntityRequest, EntityResponse>
            where EntityBase : class
            where EntityRequest : class
            where EntityResponse : class
    {
        private ApplicationDbContext context;
        private IMapper mapper;
        private DbSet<EntityBase> dbSet;

        public GenericRepository(ApplicationDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            dbSet = this.context.Set<EntityBase>();
        }

        public EntityBase Create(EntityRequest request)
        {
            EntityBase dataToCreate = mapper.Map<EntityBase>(request);
            this.dbSet.Add(dataToCreate);
            this.context.SaveChanges();
            return dataToCreate;
        }

        public async Task<EntityBase> CreateAsync(EntityRequest request)
        {
            EntityBase dataToCreate = mapper.Map<EntityBase>(request);
            await this.dbSet.AddAsync(dataToCreate);
            await this.context.SaveChangesAsync();
            return dataToCreate;
        }

        public EntityBase CreateMultiple(IEnumerable<EntityRequest> request)
        {
            throw new NotImplementedException();
        }

        public Task<EntityBase> CreateMultipleAsync(IEnumerable<EntityRequest> request)
        {
            throw new NotImplementedException();
        }

        public void Delete(EntityRequest request)
        {
            EntityBase dataToDelete = mapper.Map<EntityBase>(request);
            this.dbSet.Remove(dataToDelete);
            this.context.SaveChanges();
        }

        public EntityBase Edit(EntityBase request)
        {
            this.dbSet.Update(request);
            this.context.SaveChanges();
            return request;
        }

        public async Task<EntityBase> EditAsync(EntityBase request)
        {
            this.dbSet.Update(request);
            await this.context.SaveChangesAsync();
            return request;
        }

        public async Task<IEnumerable<EntityBase>> GetAll()
        {
            return await this.dbSet.ToListAsync();
        }

        public IQueryable<EntityBase> Search(Expression<Func<EntityBase,bool>> predicate)
        {
            return this.dbSet.Where(predicate);
        }
    }
}
