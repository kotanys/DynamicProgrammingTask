from itertools import combinations

A = "ABCDETG"
all = []
for i in range(1, len(A) + 1):
    for p in combinations(A, r=i):
        all.append("".join(p))
print(*all)
print(len(all))