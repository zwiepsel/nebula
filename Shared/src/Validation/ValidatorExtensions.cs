using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using FluentValidation;
using FluentValidation.Internal;
using FluentValidation.Validators;
using Nebula.Shared.Constants;
using Nebula.Shared.Extensions;

namespace Nebula.Shared.Validation;

public static class ValidatorExtensions
{
    public static IRuleBuilderOptions<T, TProperty> IsRequired<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder,
        string fieldName)
    {
        var ruleBuilderOptions = ruleBuilder.SetValidator(new NotEmptyValidator<T, TProperty>());
        ruleBuilderOptions.WithMessage($"{fieldName} is required.");

        return ruleBuilderOptions;
    }

    public static IRuleBuilderOptions<T, string> IsEmailAddress<T>(this IRuleBuilder<T, string> ruleBuilder,
        string fieldName)
    {
        var ruleBuilderOptions = ruleBuilder.SetValidator(new AspNetCoreCompatibleEmailValidator<T>());
        ruleBuilderOptions.WithMessage($"{fieldName} is not a valid email address.");

        return ruleBuilderOptions;
    }

    public static IRuleBuilderOptions<T, string> IsAlphaNumeric<T>(this IRuleBuilder<T, string> ruleBuilder,
        string fieldName)
    {
        var ruleBuilderOptions = ruleBuilder.SetValidator(new RegularExpressionValidator<T>(@"^[a-zA-Z0-9]*$"));
        ruleBuilderOptions.WithMessage($"{fieldName} must only contain alpha numeric characters (a-z, A-Z and 0-9).");

        return ruleBuilderOptions;
    }

    public static IRuleBuilderOptions<T, string?> IsMinimumLength<T>(this IRuleBuilder<T, string?> ruleBuilder,
        int minimumLength,
        string fieldName)
    {
        var ruleBuilderOptions = ruleBuilder.SetValidator(new MinimumLengthValidator<T>(minimumLength));
        ruleBuilderOptions.WithMessage(fieldName + " must be at least {MinLength} characters. You entered {TotalLength} characters.");

        return ruleBuilderOptions;
    }

    public static IRuleBuilderOptions<T, string> IsMaximumLength<T>(this IRuleBuilder<T, string> ruleBuilder,
        int maximumLength,
        string fieldName)
    {
        var ruleBuilderOptions = ruleBuilder.SetValidator(new MaximumLengthValidator<T>(maximumLength));
        ruleBuilderOptions.WithMessage(fieldName + " must be {MaxLength} characters or fewer. You entered {TotalLength} characters.");

        return ruleBuilderOptions;
    }

    public static IRuleBuilderOptions<T, TProperty> IsInRange<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder,
        TProperty minimumLength,
        TProperty maximumLength,
        string fieldName) where TProperty : IComparable<TProperty>, IComparable
    {
        var ruleBuilderOptions =
            ruleBuilder.SetValidator(RangeValidatorFactory.CreateInclusiveBetween<T, TProperty>(minimumLength, maximumLength));
        ruleBuilderOptions.WithMessage(fieldName + " must be between {From} and {To}.");

        return ruleBuilderOptions;
    }

    public static IRuleBuilderOptions<T, TProperty> IsEqual<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder,
        Expression<Func<T, TProperty>> expression,
        string originalName,
        string compareName,
        IEqualityComparer<TProperty>? comparer = null)
    {
        var member = expression.GetMember();
        var func = AccessorCache<T>.GetCachedAccessor(member, expression);
        var name = GetDisplayName(member, expression);

        var ruleBuilderOptions = ruleBuilder.SetValidator(new EqualValidator<T, TProperty>(func, member, name, comparer));
        ruleBuilderOptions.WithMessage($"{originalName} and {compareName} do not match.");

        return ruleBuilderOptions;
    }

    public static IRuleBuilderOptions<T, string?> IsValidPassword<T>(this IRuleBuilder<T, string?> ruleBuilder, string fieldName)
    {
        var ruleBuilderOptions = ruleBuilder.SetValidator(new MinimumLengthValidator<T>(PasswordRequirements.MinimumLength));
        ruleBuilderOptions.WithMessage(fieldName + " must be at least {MinLength} characters. You entered {TotalLength} characters.");

        return ruleBuilderOptions;
    }

    private static string? GetDisplayName<T, TProperty>(MemberInfo? member, Expression<Func<T, TProperty>> expression)
    {
        return ValidatorOptions.Global.DisplayNameResolver(typeof(T), member, expression) ?? member?.Name.SplitPascalCase();
    }
}