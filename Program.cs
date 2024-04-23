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
    if (mx < ML[i] + MR[i] - 1)
    {
        mx = ML[i] + MR[i] - 1;
        mxi = i;
    }
}

List<int> output = [];
int ptr = mxi;
while (ptr != -1)
{
    output.Insert(0, A[ptr]);
    ptr = NL[ptr];
}

ptr = NR[mxi];
while (ptr != -1)
{
    output.Add(A[^(ptr+1)]);
    ptr = NR[ptr];
}

foreach (var item in output)
{
    Console.Write(item);
    Console.Write(' ');
}

static void GetL(int[] A, int[] L, int[] N)
{
    for (int i = 1; i < A.Length; i++)
    {
        int mj = -1;
        for (int j = 0; j < i; j++)
        {
            if (A[i] > A[j] && (mj == -1 || L[j] > L[mj]))
            {
                mj = j;
                N[i] = j;
            }
        }
        if (mj == -1)
            L[i] = 1;
        else 
            L[i] = L[mj] + 1;
    }
}