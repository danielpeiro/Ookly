﻿using Ookly.Core.Entities;
using Ookly.Core.Interfaces;

namespace Ookly.Infrastructure.EntityFramework.Repositories;

public class FilterRepository(ApplicationContext context) : ApplicationRepository<Filter>(context), IFilterRepository
{
}