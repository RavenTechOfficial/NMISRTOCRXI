using Microsoft.EntityFrameworkCore;
using ServiceLayer.Services.IRepositories;
using InfastructureLayer.Data;
using DomainLayer.Models;
using InfastructureLayer.Repositories;

namespace InfastructureLayer.Repositories
{
	public class PostArticleRepository : Repository<PostArticle>, IPostArticleRepository
	{
		private readonly AppDbContext _context;

		public PostArticleRepository(AppDbContext context) : base(context)
		{
			_context = context;
		}
		public void Update(PostArticle entity)
		{
			_context.Update(entity);
		}
	}
}
