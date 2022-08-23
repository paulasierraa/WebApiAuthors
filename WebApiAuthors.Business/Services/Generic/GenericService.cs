using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiAuthors.Business.Services.Interfaces;
using WebApiAuthors.Data.Repositories.IGenericRepository;
using WebApiAuthors.Domain.Entity.Enums;
using WebApiAuthors.Domain.Entity.Response;

namespace WebApiAuthors.Business.Services.Generic
{
    public class GenericService<EntityBase, EntityRequest, EntityResponse, TRepository>
        : IGenericService<EntityBase, EntityRequest, EntityResponse, TRepository>
        where EntityRequest : class
        where EntityBase : class
        where EntityResponse : class
        where TRepository : IGenericRepository<EntityBase, EntityRequest, EntityResponse>
    {
        private readonly IMapper mapper;
        private readonly IGenericRepository<EntityBase, EntityRequest, EntityResponse> repository;

        public TRepository Repository { get; set; }
        public GenericService(IMapper mapper,IGenericRepository<EntityBase,EntityRequest,EntityResponse> repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public EntityBase Create(EntityRequest request)
        {
            try
            {
               return  this.repository.Create(request);
            }
            catch (Exception)
            {

                throw;
            }
            
            throw new NotImplementedException();
        }

        public async Task<GenericResponse<EntityBase>> CreateAsync(EntityRequest request)
        {
            GenericResponse<EntityBase> response = new GenericResponse<EntityBase>();
            try
            {
                response.Content = await this.repository.CreateAsync(request);
                response.Status = StatusCode.Ok;
                response.Message = "Datos creados con éxito";
            }
            catch(Exception e)
            {
                response.Message = "Error en la creación";
                response.Status = StatusCode.InternalServerError;
            }
            return response;
        }

        public void Delete(EntityRequest request)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            throw new NotImplementedException();
        }

        public EntityBase Edit(IEnumerable<EntityRequest> request)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            throw new NotImplementedException();
        }

        public Task<EntityBase> EditAsync(IEnumerable<EntityRequest> request)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EntityBase>> GetAll()
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            throw new NotImplementedException();
        }
    }
}
