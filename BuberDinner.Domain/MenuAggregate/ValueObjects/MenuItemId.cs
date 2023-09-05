﻿using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.ValueObjects;

public sealed class MenuItemId : ValueObject
{
    public Guid Value { get; }

    private MenuItemId(Guid value)
    {
        Value = value;
    }
    public static MenuItemId CreateUnique() => new(Guid.NewGuid());
    public static MenuItemId Create(Guid menuItemId) => new(menuItemId);
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    private MenuItemId() { }
}