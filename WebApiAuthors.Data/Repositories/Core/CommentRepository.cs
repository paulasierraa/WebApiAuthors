using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiAuthors.Data.GenericRepository;
using WebApiAuthors.Data.Repositories.Core.Interfaces;
using WebApiAuthors.Data.Context;
using WebApiAuthors.Entity.Base;
using WebApiAuthors.Entity.Request;
using WebApiAuthors.Entity.Response;
using Microsoft.EntityFrameworkCore;
using WebApiAuthors.DTOS;

namespace WebApiAuthors.Data.Repositories.Core
{
    public class CommentRepository: GenericRepository<Comment, CommentRequest, CommentResponse>,ICommentRepository
    {
        public CommentRepository(ApplicationDbContext context,IMapper mapper):base(context,mapper)
        {
        }
        public async Task<List<CommentResponse>> GetCommentByBook(int idBook)
        {
            var result = await this.dbSet
                        .Where(x => x.BookId == idBook)
                        .Include(x=> (x.Book))
                        .ToListAsync();
            return this.mapper.Map<List<CommentResponse>>(result);
        }
    }
}
