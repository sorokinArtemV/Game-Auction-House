using ItemsService.ItemServiceCore.Entities.ItemTypes;
using MediatR;

namespace ItemsService.ItemsServiceApplication.Armors.Queries.GetAllArmors;

public class GetAllArmorsQueryHandler : IRequestHandler<GetAllArmorsQuery, IEnumerable<Armor>>
{
    public Task<IEnumerable<Armor>> Handle(GetAllArmorsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}