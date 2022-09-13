using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiAuthors.Business.Services.Core.Interface;
using WebApiAuthors.Business.Services.Generic;
using WebApiAuthors.Data.Repositories.Core.Interfaces;
using WebApiAuthors.Domain.Entity.Enums;
using WebApiAuthors.Domain.Entity.Response;
using WebApiAuthors.Entity.Base;
using WebApiAuthors.Entity.Request;
using WebApiAuthors.Entity.Response;

namespace WebApiAuthors.Business.Services.Core
{
    public class CommentService : GenericService<Comment, CommentRequest, CommentResponse, ICommentRepository>,ICommentService
    {
        public CommentService(ICommentRepository repository,IMapper mapper):base(mapper,repository)
        {

        }

        public async Task<GenericResponse<List<CommentResponse>>> GetCommentByBook(int idBook)
        {
            GenericResponse<List<CommentResponse>> response = new GenericResponse<List<CommentResponse>>();
            try
            {
                response.Content = await this.repository.GetCommentByBook(idBook);
                response.Status = StatusCode.Ok;
                response.Message = ResponseMessages.SUCCESFUL_GET;
            }
            catch(Exception e)
            {
                response.Content = null;
                response.Status = StatusCode.InternalServerError;
                response.Message = ResponseMessages.INTERNAL_SERVER_ERROR;
            }
            return response;
        }
    }
}
