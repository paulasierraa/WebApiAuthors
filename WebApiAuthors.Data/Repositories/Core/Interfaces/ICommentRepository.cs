using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiAuthors.Data.Repositories.IGenericRepository;
using WebApiAuthors.Entity.Base;
using WebApiAuthors.Entity.Request;
using WebApiAuthors.Entity.Response;

namespace WebApiAuthors.Data.Repositories.Core.Interfaces
{
    public interface ICommentRepository:IGenericRepository<Comment,CommentRequest,CommentResponse>
    {
        Task<List<CommentResponse>> GetCommentByBook(int idBook);
    }
}
