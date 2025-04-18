namespace Overstay.Application.Features.Visas.Request;

public class CreateVisaRequest
{
    public DateTime ArrivalDate { get; set; }
    public DateTime ExpireDate { get; set; }
    public Guid VisaTypeId { get; set; }
}
