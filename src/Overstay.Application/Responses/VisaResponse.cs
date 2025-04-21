namespace Overstay.Application.Responses;

public class VisaResponse
{
    public Guid Id { get; set; }
    public DateTime ArrivalDate { get; set; }
    public DateTime ExpireDate { get; set; }
    public VisaTypeResponse VisaType { get; set; } = null!;
}
