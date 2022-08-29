using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiAuthors.Data.GenericRepository;
using WebApiAuthors.Data.Repositories.Core.Interfaces;
using WebApiAuthors.Domain.Context;
using WebApiAuthors.Entity.Base;
using WebApiAuthors.Entity.Request;
using WebApiAuthors.Entity.Response;

namespace WebApiAuthors.Data.Repositories.Core
{
    public class CommentRepository: GenericRepository<Comment, CommentRequest, CommentResponse>,ICommentRepository
    {
        public CommentRepository(ApplicationDbContext context,IMapper mapper):base(context,mapper)
        {
        }
    }
}
