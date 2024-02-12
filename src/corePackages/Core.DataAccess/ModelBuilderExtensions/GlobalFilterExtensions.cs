using Core.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.DataAccess.ModelBuilderExtensions;

public static class GlobalFilterExtensions
{
    public static ModelBuilder AddGlobalFilterWithExpression<TEntity>(this ModelBuilder modelBuilder, Expression<Func<TEntity, bool>> expression)
    {
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            if (entity.ClrType.IsAssignableTo(typeof(Entity)))
            {
                var parameter = Expression.Parameter(entity.ClrType);
                var body = ReplacingExpressionVisitor.Replace(expression.Parameters.First(), parameter, expression.Body); // ef
                //var body = expression.ReplaceParameters(parameter); // automapper
                //var body = expression.Body.Replace(expression.Parameters.First(), parameter); // automapper
                var lambdaExpression = Expression.Lambda(body, parameter);

                entity.SetQueryFilter(lambdaExpression);
            }
        }
        return modelBuilder;
    }
}
