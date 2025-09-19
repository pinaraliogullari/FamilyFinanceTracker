using FinancialTrack.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace FinancialTrack.Application.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    DbSet<T>Table{get;}
}