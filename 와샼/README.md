
https://school.programmers.co.kr/learn/courses/30/lessons/77484?language=python3

```python3
def solution(lottos, win_nums):
    answer = []
    max = 0
    min = 0
    
    for i in lottos:
        if i in win_nums:
            min += 1
        if i == 0:
            max += 1
    
    #3항 연산자로 해결
    answer.append(6 if 7 - min - max >= 6 else 7 - min - max)
    answer.append(6 if 7 - min >= 6 else 7 - min)
    
    return answer
```

https://leetcode.com/problems/strong-password-checker-ii/

```python3
class Solution:
    def strongPasswordCheckerII(self, password: str) -> bool:
        lowercase = 'abcdefghijklmnopqrstuvwxyz'
        uppercase = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'
        digitcase = '0123456789'
        specialcase = '!@#$%^&*()-+'
        
        lower = False
        upper = False
        digit = False
        special = False
        
        if len(password) < 8:
            return False
        
        for i in range(1, len(password)):
            if password[i-1] == password[i]:
                return False
            
        for i in password:
            if lowercase.__contains__(i):
                lower = True
            if uppercase.__contains__(i):
                upper = True
            if digitcase.__contains__(i):
                digit = True
            if specialcase.__contains__(i):
                special = True
                
        return lower and upper and digit and special
        
```
