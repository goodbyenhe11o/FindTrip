﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using System.Linq.Expressions;

namespace FindTrip_Web.common
{
    public abstract class AbstractPatchValidator<T> : AbstractValidator<T>
        where T : IPatchState<T>
    {
        public void WhenBound<TProperty>(
            Expression<Func<T, TProperty>> propertyExpression,
            Action<IRuleBuilderInitial<T, TProperty>> action)
        {
            When(x => x.IsBound(propertyExpression), () => action(RuleFor(propertyExpression)));
        }
    }
}