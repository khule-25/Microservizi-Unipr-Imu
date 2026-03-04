using AutoMapper;
using Imu.Repository.Abstraction;
using Microsoft.Extensions.Logging;
using Utility.Kafka.MessageHandlers;

namespace Imu.Business.Kafka.MessageHandlers;

public abstract class AbstractMessageHandler<TMessageDTO>(ILogger<AbstractMessageHandler<TMessageDTO>> logger, IRepository repository, IMapper mapper)
    : AbstractOperationMessageHandler<TMessageDTO, IRepository>(logger, mapper)
    where TMessageDTO : class, new() {

    /// <summary>
    /// Insert del record partendo dal <paramref name="messageDto"/>
    /// </summary>
    /// <param name="messageDto">Dto del record da inserire</param>
    protected override async Task InsertAsync(TMessageDTO messageDto, CancellationToken cancellationToken = default) {
        Logger.LogInformation("Insert del DTO {messageDTOType}...", MessageDtoType);
        await InsertDtoAsync(messageDto);
        await repository.SaveChangesAsync();
        Logger.LogInformation("Insert del DTO {messageDTOType} completata!", MessageDtoType);
    }

    /// <summary>
    /// Update del record partendo dal <paramref name="messageDto"/>
    /// </summary>
    /// <param name="messageDto">Dto del record da aggiornare</param>
    protected override async Task UpdateAsync(TMessageDTO messageDto, CancellationToken cancellationToken = default) {
        Logger.LogInformation("Update del DTO {messageDTOType}...", MessageDtoType);
        await UpdateDtoAsync(messageDto);
        await repository.SaveChangesAsync();
        Logger.LogInformation("Update del DTO {messageDTOType} completata", MessageDtoType);
    }

    /// <summary>
    /// Delete del record partendo dal <paramref name="messageDto"/>
    /// </summary>
    /// <param name="messageDto">Dto del record da eliminare</param>
    protected override async Task DeleteAsync(TMessageDTO messageDto, CancellationToken cancellationToken = default) {
        Logger.LogInformation("Delete del DTO {messageDTOType}...", MessageDtoType);
        await DeleteDtoAsync(messageDto);
        await repository.SaveChangesAsync();
        Logger.LogInformation("Delete del DTO {messageDTOType} completata", MessageDtoType);
    }

    /// <summary>
    /// Insert del record partendo dal <paramref name="messageDto"/>
    /// </summary>
    /// <param name="messageDto">Dto del record da inserire</param>
    protected abstract Task InsertDtoAsync(TMessageDTO messageDto, CancellationToken cancellationToken = default);

    /// <summary>
    /// Update del record partendo dal <paramref name="messageDto"/>
    /// </summary>
    /// <param name="messageDto">Dto del record da aggiornare</param>
    protected abstract Task UpdateDtoAsync(TMessageDTO messageDto, CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete del record partendo dal <paramref name="messageDto"/>
    /// </summary>
    /// <param name="messageDto">Dto del record da eliminare</param>
    protected abstract Task DeleteDtoAsync(TMessageDTO messageDto, CancellationToken cancellationToken = default);
}

public abstract class AbstractMessageHandler<TMessageDTO, TDomainDTO>(ILogger<AbstractMessageHandler<TMessageDTO, TDomainDTO>> logger, IRepository repository, IMapper map)
    : AbstractOperationMessageHandler<TMessageDTO, TDomainDTO>(logger, map)
    where TMessageDTO : class, new()
    where TDomainDTO : class, new() {

    /// <summary>
    /// Insert del record partendo dal <paramref name="domainDto"/>
    /// </summary>
    /// <param name="domainDto">Dto del record da inserire</param>
    protected override async Task InsertAsync(TDomainDTO domainDto, CancellationToken cancellationToken = default) {
        Logger.LogInformation("Insert del DTO {domainDTOType}...", DomainDtoType);
        await InsertDtoAsync(domainDto, cancellationToken);
        await repository.SaveChangesAsync();
        Logger.LogInformation("Insert del DTO {domainDTOType} completata!", DomainDtoType);
    }

    /// <summary>
    /// Update del record partendo dal <paramref name="domainDto"/>
    /// </summary>
    /// <param name="domainDto">Dto del record da aggiornare</param>
    protected override async Task UpdateAsync(TDomainDTO domainDto, CancellationToken cancellationToken = default) {
        Logger.LogInformation("Update del DTO {domainDTOType}...", DomainDtoType);
        await UpdateDtoAsync(domainDto, cancellationToken);
        await repository.SaveChangesAsync();
        Logger.LogInformation("Update del DTO {domainDTOType} completata", DomainDtoType);
    }

    /// <summary>
    /// Delete del record partendo dal <paramref name="domainDto"/>
    /// </summary>
    /// <param name="domainDto">Dto del record da eliminare</param>
    protected override async Task DeleteAsync(TDomainDTO domainDto, CancellationToken cancellationToken = default) {
        Logger.LogInformation("Delete del DTO {domainDTOType}...", DomainDtoType);
        await DeleteDtoAsync(domainDto, cancellationToken);
        await repository.SaveChangesAsync();
        Logger.LogInformation("Delete del DTO {domainDTOType} completata", DomainDtoType);
    }

    /// <summary>
    /// Insert del record partendo dal <paramref name="domainDto"/>
    /// </summary>
    /// <param name="domainDto">Dto del record da inserire</param>
    protected abstract Task InsertDtoAsync(TDomainDTO domainDto, CancellationToken cancellationToken = default);

    /// <summary>
    /// Update del record partendo dal <paramref name="domainDto"/>
    /// </summary>
    /// <param name="domainDto">Dto del record da aggiornare</param>
    protected abstract Task UpdateDtoAsync(TDomainDTO domainDto, CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete del record partendo dal <paramref name="domainDto"/>
    /// </summary>
    /// <param name="domainDto">Dto del record da eliminare</param>
    protected abstract Task DeleteDtoAsync(TDomainDTO domainDto, CancellationToken cancellationToken = default);
}
