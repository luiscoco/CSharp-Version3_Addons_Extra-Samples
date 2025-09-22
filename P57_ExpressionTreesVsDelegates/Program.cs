using System; using System.Linq.Expressions;
class Program
{
    static void Main()
    {
        // Lambda to delegate
        Func<int,int> f = x => x + 1;
        Console.WriteLine("Delegate: " + f(5));

        // Lambda to expression tree
        Expression<Func<int,int>> e = x => x + 1;
        Console.WriteLine("Expression: " + e);

        // Basic rewrite: replace parameter with constant 10: (x => x + 1) -> (10 + 1)
        var param = e.Parameters[0];
        var replaced = new ReplaceVisitor(param, Expression.Constant(10));
        var body = replaced.Visit(e.Body);
        var newExpr = Expression.Lambda<Func<int>>(body);
        Console.WriteLine("Rewritten result: " + newExpr.Compile()());
    }

    class ReplaceVisitor : ExpressionVisitor
    {
        private readonly ParameterExpression _from;
        private readonly Expression _to;
        public ReplaceVisitor(ParameterExpression from, Expression to){ _from=from; _to=to; }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return node == _from ? _to : base.VisitParameter(node);
        }
    }
}
