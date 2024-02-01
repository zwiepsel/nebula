using System;
using FluentValidation;
using Nebula.Shared.Models;

namespace Nebula.Shared.Validation;

public abstract class ModelValidator<T> : AbstractValidator<T> where T : Model
{
    protected static bool BeGreaterThanToday(DateTime dateTime)
    {
        return DateTime.Now.Date < dateTime.Date;
    }
}