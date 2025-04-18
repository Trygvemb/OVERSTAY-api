namespace Overstay.Application.Features.Visas.Response;

public class VisaResponse
{
    public Guid Id { get; set; }
    public DateTime ArrivalDate { get; set; }
    public DateTime ExpireDate { get; set; }
    public VisaType VisaType { get; set; } = null!;
}
