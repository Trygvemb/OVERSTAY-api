namespace Overstay.Application.Features.VisaTypes.Responses;

public class VisaTypeResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool IsMultipleEntry { get; set; }
}
