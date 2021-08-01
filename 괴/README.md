3. Longest Substring Without Repeating Characters
https://leetcode.com/problems/longest-substring-without-repeating-characters/

```python3
class Solution:
    def lengthOfLongestSubstring(self, s: str) -> int:
        
        max_count = 0
        current_count = 0
        buffer = ""
        
        for i in range(len(s)):
            
            # 최초 문자열 할당 및 처리
            current_count = 1
            buffer = s[i]
            
            for j in range(i+1, len(s)):
                
                # 버퍼 문자열에 대상 문자열이 존재하지 않음
                if buffer.find(s[j]) == -1:
                    current_count += 1
                    buffer = buffer + s[j]
                # 버퍼 문자열에 대상 문자열이 존재함
                else:
                    break
            
            if max_count < current_count:
                max_count = current_count
        
        return max_count
```
시간복잡도 : O(n²)
Runtime: 688 ms
Memory Usage: 14.4 MB