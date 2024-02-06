using Core.Application.Dtos;

namespace Application.Features.PhoneProductFeatures.PhoneInternalMemories.Queries.GetAllList;
public class GetAllListPhoneInternalMemoryDto : IDto
{
    public int Id { get; set; }
    public string Capacity { get; set; }
}