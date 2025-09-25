using System.Text.Json.Serialization;
using FinancialTrack.Domain.Entities.Enums;

namespace FinancialTrack.Application.Features.Category.Queries.GetAllCategories;

public class GetAllCategoriesQueryResponse
{
   public long Id { get; set; }
   public string Name { get; set; }
   public bool IsCustom { get; set; }
   [JsonConverter(typeof(JsonStringEnumConverter))]
   public FinancialRecordType FinancialRecordType { get; set; }
}