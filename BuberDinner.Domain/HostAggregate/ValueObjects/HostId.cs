﻿using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.HostAggregate.ValueObjects;
public sealed class HostId : ValueObject
{
    public Guid Value { get; }

    private HostId(Guid value)
    {
        Value = value;
    }

    public static HostId CreateUnique() => new(Guid.NewGuid());

    public static HostId Create(Guid hostId) => new(hostId);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}