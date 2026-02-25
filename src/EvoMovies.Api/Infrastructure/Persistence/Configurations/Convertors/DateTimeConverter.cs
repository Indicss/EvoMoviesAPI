using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EvoMovies.Api.Infrastructure.Persistence.Configurations.Convertors;

internal sealed class DateTimeConverter() : ValueConverter<DateTime, DateTime>(
    domainValue => domainValue.ToUniversalTime(), 
    dbValue => dbValue.ToLocalTime());