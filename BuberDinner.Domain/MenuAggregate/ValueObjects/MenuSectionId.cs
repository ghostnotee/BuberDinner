﻿using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.ValueObjects;
public class MenuSectionId : ValueObject
{
    public Guid Value { get; }

    private MenuSectionId(Guid value)
    {
        Value = value;
    }

    public static MenuSectionId CreateUnique() => new(Guid.NewGuid());
    public static MenuSectionId Create(Guid menuSectionId) => new(menuSectionId);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}