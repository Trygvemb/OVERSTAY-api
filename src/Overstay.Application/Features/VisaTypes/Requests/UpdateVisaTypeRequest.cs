namespace Overstay.Application.Features.VisaTypes.Requests;

public class UpdateVisaTypeRequest
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool? IsMultipleEntry { get; set; }
}
