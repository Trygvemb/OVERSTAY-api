using Mapster;
using Overstay.Application.Features.Users.Commands;
using Overstay.Application.Features.VisaTypes.Commands;
using Overstay.Domain.Entities;

namespace Overstay.Application.Commons.Configurations;

public static class MappingConfigurations
{
    public static void Configure()
    {
        TypeAdapterConfig.GlobalSettings.Default.IgnoreNullValues(true);

        TypeAdapterConfig<UpdateVisaTypeCommand, VisaType>
            .NewConfig()
            .IgnoreNullValues(true)
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest, src => src.Item);
    }
}
