# 70. Climbing Stairs
https://leetcode.com/problems/climbing-stairs/

```python
class Solution:
    def climbStairs(self, n: int) -> int:
        
        if n < 3:
            return n
        
        dp = [0 for i in range(n+1)]
        
        dp[1] = 1
        dp[2] = 2
        
        for i in range(3, n+1):
            # f(n) = f(n-1) + f(n-2)
            dp[i] = dp[i-1] + dp[i-2]
        
        return dp[n]
```

# 모의고사
https://programmers.co.kr/learn/courses/30/lessons/42840

```python
def solution(answers):
    
    correct = [0, 0, 0]
    no1 = [1, 2, 3, 4, 5]
    no2 = [2, 1, 2, 3, 2, 4, 2, 5]
    no3 = [3, 3, 1, 1, 2, 2, 4, 4, 5, 5]

    for i in range(len(answers)):
        if answers[i] == no1[i % 5]:
            correct[0] += 1
        if answers[i] == no2[i % 8]:
            correct[1] += 1
        if answers[i] == no3[i % 10]:
            correct[2] += 1
    
    print(correct)
    
    max_count = 0
    
    for c in correct:
        if max_count < c:
            max_count = c
    
    print(max_count)
    
    answer = []
    
    for i in range(len(correct)):
        if max_count == correct[i]:
            answer.append(i+1)
    
    return answer
```
