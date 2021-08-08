https://programmers.co.kr/learn/courses/30/lessons/42895

N으로 표현

```python
def solution(N, number):

    if N == number:
        return 1
    
    dp = [[]]
    
    for i in range(1, 9):

        case = []

        case.append(int(str(N) * i))

        for j in range(1, i):
            for op1 in dp[j]:
                for op2 in dp[i - j]:
                    case.append(op1 + op2)
                    case.append(op1 * op2)
                    case.append(op1 - op2)
                    if op2 != 0:
                        case.append(op1 // op2)

            if number in case:
                return i
                    
        dp.append(list(set(case)))

    return -1
```