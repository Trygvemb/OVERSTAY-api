namespace Overstay.Application.Responses;

public class VisaTypeResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int? DurationInDays { get; set; }
    public bool? IsMultipleEntry { get; set; }
}
