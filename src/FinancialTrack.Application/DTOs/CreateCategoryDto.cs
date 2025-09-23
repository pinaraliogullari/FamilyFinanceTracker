using FinancialTrack.Domain.Entities.Enums;

namespace FinancialTrack.Application.DTOs;

public class CreateCategoryDto
{
    public string Name { get; set; }
    public FinancialRecordType FinancialRecordType { get; set; }
}