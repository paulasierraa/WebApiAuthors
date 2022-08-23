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

        public GenericResponse<EntityBase> Create(EntityRequest request)
        {
            GenericResponse<EntityBase> response = new GenericResponse<EntityBase>();
            try
            {
               response.Content = this.repository.Create(request);
               response.Status = StatusCode.Ok;
               response.Message = ResponseMessages.SUCCESFUL_CREATE;
            }
            catch (Exception)
            {
                response.Content = null;
                response.Status = StatusCode.InternalServerError;
                response.Message = ResponseMessages.INTERNAL_SERVER_ERROR;
            }
            return response;
        }

        public async Task<GenericResponse<EntityBase>> CreateAsync(EntityRequest request)
        {
            GenericResponse<EntityBase> response = new GenericResponse<EntityBase>();
            try
            {
                response.Content = await this.repository.CreateAsync(request);
                response.Status = StatusCode.Ok;
                response.Message = ResponseMessages.SUCCESFUL_CREATE;
            }
            catch(Exception e)
            {
                response.Message = ResponseMessages.INTERNAL_SERVER_ERROR;
                response.Status = StatusCode.InternalServerError;
                response.Content = null;
            }
            return response;
        }

        public GenericResponse<bool> Delete(EntityRequest request)
        {
            GenericResponse<bool> response = new GenericResponse<bool>();
            try
            {
                this.repository.Delete(request);
                response.Content = true;
                response.Status = StatusCode.Ok;
                response.Message = ResponseMessages.SUCCESFUL_DELETE;
            }
            catch (Exception)
            {
                response.Content = false;
                response.Status = StatusCode.InternalServerError;
                response.Message = ResponseMessages.INTERNAL_SERVER_ERROR;
            }
            return response;
        }

        public GenericResponse<EntityBase> Edit(EntityRequest request)
        {
            GenericResponse<EntityBase> response = new GenericResponse<EntityBase>();
            try
            {
                response.Content = this.repository.Edit(request);
                response.Status = StatusCode.Ok;
                response.Message = ResponseMessages.SUCCESFUL_EDIT;
            }
            catch (Exception)
            {
                response.Content = null;
                response.Status = StatusCode.InternalServerError;
                response.Message = ResponseMessages.INTERNAL_SERVER_ERROR;
            }
            return response;
        }

        public async Task<GenericResponse<EntityBase>> EditAsync(EntityRequest request)
        {
            GenericResponse<EntityBase> response = new GenericResponse<EntityBase>();
            try
            {
                response.Content = await this.repository.EditAsync(request);
                response.Status = StatusCode.Ok;
                response.Message = ResponseMessages.SUCCESFUL_EDIT;
            }
            catch (Exception)
            {
                response.Content = null;
                response.Status = StatusCode.InternalServerError;
                response.Message = ResponseMessages.INTERNAL_SERVER_ERROR;
            }
            return response;
        }

        public async Task<GenericResponse<IEnumerable<EntityBase>>> GetAll()
        {
            GenericResponse<IEnumerable<EntityBase>> response = new GenericResponse<IEnumerable<EntityBase>>();
            try
            {
                var listAux = await this.repository.GetAll();
                response.Content =listAux.ToList();
                response.Status = StatusCode.Ok;
                response.Message = ResponseMessages.SUCCESFUL_GET;
            }
            catch (Exception)
            {
                response.Content = null;
                response.Status = StatusCode.InternalServerError;
                response.Message = ResponseMessages.INTERNAL_SERVER_ERROR;
            }
            return response;
        }
    }
}
