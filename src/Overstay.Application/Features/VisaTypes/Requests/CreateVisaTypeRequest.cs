namespace Overstay.Application.Features.VisaTypes.Requests;

public class CreateVisaTypeRequest
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool IsMultipleEntry { get; set; }
}
