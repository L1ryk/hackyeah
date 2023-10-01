using System.Linq.Expressions;

namespace WebAPI.Helpers;

public static class ExpressionHelper
{
    public static Expression<Func<T, bool>> OrElse<T>( this Expression<Func<T, bool>> left,
        Expression<Func<T, bool>> right ) =>
        combine( left, right, ExpressionType.OrElse );

    private static Expression<Func<T, bool>> combine<T>( Expression<Func<T, bool>> left,
        Expression<Func<T, bool>> right,
        ExpressionType type )
    {
        if ( left is null ) return right;
        if ( right is null ) return left;

        bool constValue = type != ExpressionType.AndAlso;
        if ( ( left.Body as ConstantExpression )?.Value is bool leftValue )
            return leftValue == constValue ? left : right;
        if ( ( right.Body as ConstantExpression )?.Value is bool rightValue )
            return rightValue == constValue ? right : left;

        return Expression.Lambda<Func<T, bool>>( Expression.MakeBinary( type,
                left.Body,
                right.invoke( left.Parameters[ 0 ] ) ),
            left.Parameters );
    }

    private static Expression invoke<T, TResult>( this Expression<Func<T, TResult>> source, Expression arg )
    {
        Guard.IsNotNull( source );
        Guard.IsNotNull( arg );

        return source.Body.replaceParameter( source.Parameters[ 0 ], arg );
    }

    private static Expression replaceParameter( this Expression source,
        ParameterExpression parameter,
        Expression value )
    {
        return new ParameterReplacer { Parameter = parameter, Value = value }.Visit( source );
    }

    sealed class ParameterReplacer : ExpressionVisitor
    {
        public ParameterExpression Parameter;
        public Expression Value;

        protected override Expression VisitParameter( ParameterExpression node )
        {
            Guard.IsNotNull( node );
            return node == Parameter ? Value : node;
        }
    }
}