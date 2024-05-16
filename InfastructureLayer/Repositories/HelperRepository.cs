﻿using Microsoft.EntityFrameworkCore;
using ServiceLayer.Services.IRepositories;
using InfastructureLayer.Data;
using DomainLayer.Models;
using InfastructureLayer.Repositories;

namespace InfastructureLayer.Repositories
{
	public class HelperRepository : Repository<Helper>, IHelperRepository
	{
		private readonly AppDbContext _context;

		public HelperRepository(AppDbContext context) : base(context)
		{
			_context = context;
		}
		public void Update(Helper entity)
		{
			_context.Update(entity);
		}
	}
}
