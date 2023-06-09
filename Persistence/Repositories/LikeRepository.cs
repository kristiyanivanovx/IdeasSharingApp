﻿using Application.Contracts.Persistence;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
	public class LikeRepository : BaseRepository<Like>, ILikeRepository
	{
		public LikeRepository(IdeasSharingDbContext dbContext) : base(dbContext)
		{
		}
	}
}
