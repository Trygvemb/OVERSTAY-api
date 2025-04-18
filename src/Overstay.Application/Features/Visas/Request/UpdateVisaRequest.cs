namespace Overstay.Application.Features.Visas.Request;

public class UpdateVisaRequest
{
    public DateTime ArrivalDate { get; set; }
    public DateTime ExpireDate { get; set; }
    public Guid VisaTypeId { get; set; }
    public Guid UserId { get; set; }
}
