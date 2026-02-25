using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EvoMovies.Api.Infrastructure.Persistence.Configurations.Convertors;

internal sealed class DateOnlyConverter() : ValueConverter<DateOnly, DateTime>(
    domainValue => domainValue.ToDateTime(TimeOnly.MinValue).ToUniversalTime(), 
    dbValue => DateOnly.FromDateTime(dbValue.ToLocalTime()));