using Imu.Shared;

namespace Imu.Business.Abstraction;

public interface IBusiness
{
    Task CreateCategoriaCatastaleAsync(CategoriaCatastaleInsertDto categoriaCatastaleInsertDto, CancellationToken cancellationToken = default);
    Task CreateImmobileAsync(ImmobileInsertDto immobileInsertDto, CancellationToken cancellationToken = default);
    Task AssociaAnagraficaImmobileAsync(AssociaAnagraficaImmobileDto associaAnagraficaImmobileDto, CancellationToken cancellationToken = default);
}
