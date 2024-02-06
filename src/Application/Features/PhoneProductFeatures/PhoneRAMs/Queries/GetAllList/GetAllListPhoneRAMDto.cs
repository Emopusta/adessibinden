using Core.Application.Dtos;

namespace Application.Features.PhoneProductFeatures.PhoneRAMs.Queries.GetAllList;

public class GetAllListPhoneRAMDto : IDto
{
    public int Id { get; set; }
    public string Memory { get; set; }
}