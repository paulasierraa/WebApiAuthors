using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiAuthors.Business.Services.Interfaces;
using WebApiAuthors.Data.Repositories.Core.Interfaces;
using WebApiAuthors.Entity.Base;
using WebApiAuthors.Entity.Request;
using WebApiAuthors.Entity.Response;

namespace WebApiAuthors.Business.Services.Core.Interface
{
    public interface ICommentService : IGenericService<Comment, CommentRequest, CommentResponse, ICommentRepository>
    {
    }
}
