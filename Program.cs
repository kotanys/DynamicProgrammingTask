int[] A = File.ReadAllText("input.txt")
        .Trim().Split(' ')
        .Select(int.Parse).ToArray();

int[] ML = new int[A.Length];
int[] MR = new int[A.Length];
int[] NL = new int[A.Length];
int[] NR = new int[A.Length];
Array.Fill(NL, -1);
Array.Fill(NR, -1);
ML[0] = MR[0] = 1;

GetL(A, ML, NL);
GetL(A.Reverse().ToArray(), MR, NR);

int mx = 0;
int mxi = -1;
for (int i = 0; i < A.Length; i++)
{
    if (mx < ML[i] + MR[^(i+1)] - 1)
    {
        mx = ML[i] + MR[^(i+1)] - 1;
        mxi = i;
    }
}

List<int> OUT = [];
int ptr = mxi;
while (ptr != -1)
{
    OUT.Insert(0, A[ptr]);
    ptr = NL[ptr];
}

ptr = NR[^(mxi+1)];
while (ptr != -1)
{
    OUT.Add(A[^(ptr+1)]);
    ptr = NR[ptr];
}

foreach (var item in OUT)
{
    Console.Write(item);
    Console.Write(' ');
}

static void GetL(int[] A, int[] L, int[] N)
{
    for (int k = 1; k < A.Length; k++)
    {
        int mj = -1;
        for (int i = 0; i < k; i++)
        {
            if (A[k] > A[i] && (mj == -1 || L[i] > L[mj]))
            {
                mj = i;
                N[k] = i;
            }
        }
        if (mj == -1)
            L[k] = 1;
        else 
            L[k] = L[mj] + 1;
    }
}