
namespace Shared.DataTransferObjects
{
    public record HostForCreationDto(string Name,string Description, string Details,IEnumerable<PlanForCreationDto> Plans);
}
