using Anagrafiche.Shared;
using Imu.Business.Abstraction;
using Imu.Repository.Abstraction;
using Imu.Shared;
using Microsoft.Extensions.Logging;

namespace Imu.Business;

public class Business(IRepository repository, Anagrafiche.ClientHttp.Abstraction.IClientHttp clientHttp, ILogger<Business> logger) : IBusiness
{
    public async Task AssociaAnagraficaImmobileAsync(AssociaAnagraficaImmobileDto associaAnagraficaImmobileDto, CancellationToken cancellationToken = default)
    {
        SoggettoDto? soggetto = await clientHttp.ReadSoggettoAsync(associaAnagraficaImmobileDto.IdAnagrafica, cancellationToken);

        if (soggetto is null)
            throw new Exception($"soggetto id {associaAnagraficaImmobileDto.IdAnagrafica} non trovato");

        await repository.AssociaAnagraficaImmobileAsync(associaAnagraficaImmobileDto, cancellationToken);

        await repository.SaveChangesAsync(cancellationToken);
    }

    public async Task CreateCategoriaCatastaleAsync(CategoriaCatastaleInsertDto categoriaCatastaleInsertDto, CancellationToken cancellationToken = default)
    {
        await repository.CreateCategoriaCatastale(categoriaCatastaleInsertDto, cancellationToken);

        await repository.SaveChangesAsync(cancellationToken);
    }

    public async Task CreateImmobileAsync(ImmobileInsertDto immobileInsertDto, CancellationToken cancellationToken = default)
    {
        await repository.CreateImmobile(immobileInsertDto, cancellationToken);

        await repository.SaveChangesAsync(cancellationToken);
    }
}
