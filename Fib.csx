using System.Numerics;
//BigInteger Fib(BigInteger n)
//{
//    if (n == 1 || n == 2)
//        return 1;
//    return Fib(n - 1) + Fib(n - 2);
//}

//BigInteger Fib(int n, Dictionary<int, BigInteger>? memo = null)
//{
//    if (n == 1 || n == 2)
//        return 1;
//    if (memo is null)
//        memo = new();
//    if (memo.ContainsKey(n))
//        return memo[n];
//    var val = Fib(n - 1, memo) + Fib(n - 2, memo);
//    memo[n] = val;
//    return val;
//}

//BigInteger Fib(int n)
//{
//    var table = new BigInteger[n + 1];
//    table[0] = 0;
//    table[1] = 1;
//    for (int i = 2; i <= n; i++)
//    {
//        table[i] = table[i - 1] + table[i - 2];
//    }
//    return table[n];
//}

BigInteger Fib(int n)
{
    BigInteger a = 1, b = 1;
    for (int i = 2; i <= n; i++)
    {
        (a, b) = (a + b, a);
    }
    return a;
}