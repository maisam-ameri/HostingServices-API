
namespace Shared.DataTransferObjects
{
    public record HostForUpdateDto(string Name, string Description, string Details, IEnumerable<HostForUpdateDto> Plans);
}
