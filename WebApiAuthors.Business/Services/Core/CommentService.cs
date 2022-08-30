using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiAuthors.Business.Services.Core.Interface;
using WebApiAuthors.Business.Services.Generic;
using WebApiAuthors.Data.Repositories.Core.Interfaces;
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
    }
}
