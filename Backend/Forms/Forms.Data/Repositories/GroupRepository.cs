﻿using Forms.Core;
using Common.Data;
using Microsoft.EntityFrameworkCore;

namespace Forms.Data
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public GroupRepository(FormDbContext context) : base(context)
        {
        }
    }
}