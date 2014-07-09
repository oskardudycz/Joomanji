﻿using Shared.Core.Validation;
using System;
using System.Collections.Generic;

namespace FluentValidation
{
    public static class ValidationExtensions
    {
        public static CollectionValidatorExtensions.ICollectionValidatorRuleBuilder<T, TCollectionElement>
            SetCollectionValidator<T, TCollectionElement>(
            this IRuleBuilder<T, IEnumerable<TCollectionElement>> ruleBuilder)
        {
            return ruleBuilder.SetCollectionValidator(new NestedComponentValidator<TCollectionElement>());
        }

        public static IRuleBuilderOptions<T, TProperty> UseNestedValidator<T, TProperty>(
            this IRuleBuilder<T, TProperty> ruleBuilder)
        {
            #pragma warning disable 612,618
            return ruleBuilder.SetValidator(ValidationEngine.GetValidator<TProperty>());
            #pragma warning restore 612,618
        }

        public static IRuleBuilderOptions<T, TProperty> MustNot<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, Func<TProperty, bool> predicate)
        {
            return ruleBuilder.SetValidator(new MustNotValidator<TProperty>(predicate));
        }
    }
}
