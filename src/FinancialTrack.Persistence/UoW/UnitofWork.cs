using FinancialTrack.Application.Repositories.CategoryRepository;
using FinancialTrack.Application.Repositories.FinancialRecordRepository;
using FinancialTrack.Application.Repositories.RoleRepository;
using FinancialTrack.Application.Repositories.UserRepository;
using FinancialTrack.Application.UoW;
using FinancialTrack.Persistence.Context;
using FinancialTrack.Persistence.Repositories.CategoryRepositories;
using FinancialTrack.Persistence.Repositories.FinancialRecordRepositories;
using FinancialTrack.Persistence.Repositories.RoleRepositories;
using FinancialTrack.Persistence.Repositories.UserRepositories;

namespace FinancialTrack.Persistence.UoW;

public class UnitofWork : IUnitofWork
{
    private readonly FinancialTrackDbContext _dbContext;

    public UnitofWork(FinancialTrackDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    private IUserReadRepository? _userReadRepository;
    private IUserWriteRepository? _userWriteRepository;
    private IRoleReadRepository? _roleReadRepository;
    private IRoleWriteRepository? _roleWriteRepository;
    private ICategoryReadRepository? _categoryReadRepository;
    private ICategoryWriteRepository? _categoryWriteRepository;
    private IFinancialRecordReadRepository? _financialRecordReadRepository;
    private IFinancialRecordWriteRepository? _financialRecordWriteRepository;
    

    public IUserReadRepository UserRead => _userReadRepository ??= new UserReadRepository(_dbContext);
    public IUserWriteRepository UserWrite => _userWriteRepository ??= new UserWriteRepository(_dbContext);
    public IRoleReadRepository RoleRead => _roleReadRepository ??= new RoleReadRepository(_dbContext);
    public IRoleWriteRepository RoleWrite => _roleWriteRepository ??= new RoleWriteRepository(_dbContext);
    public ICategoryReadRepository CategoryRead => _categoryReadRepository ??= new CategoryReadRepository(_dbContext);

    public ICategoryWriteRepository CategoryWrite =>
        _categoryWriteRepository ??= new CategoryWriteRepository(_dbContext);

    public IFinancialRecordReadRepository FinancialRecordRead =>
        _financialRecordReadRepository ??= new FinancialRecordReadRepository(_dbContext);

    public IFinancialRecordWriteRepository FinancialRecordWrite =>
        _financialRecordWriteRepository ??= new FinancialRecordWriteRepository(_dbContext);

    public async Task<int> SaveChangesAsync()
        => await _dbContext.SaveChangesAsync();

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}