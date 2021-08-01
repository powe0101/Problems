Unique Paths

```python3
class Solution:
    def uniquePaths(self, m: int, n: int) -> int:
        return round(self.factorial(m+n-2) / (self.factorial(m-1) * self.factorial(n-1)))
    
    def factorial(self, n) -> int:
        num = 1
        while n >= 1:
            num = num * n
            n = n - 1
        return num

```
Longest Substring Without Repeating Characters

```c++
class Solution {
public:
    int allUnique(char *str) 
    {
        int i, j;
        char *p = str;
        int l = strlen(str);

        for(i = 0; i < l - 1; i++) {
            for(j = i + 1; j < l; j++) {
                if(p[i] == p[j]) return 0; 
            }
        }
        
        return 1; 
    }

    int lengthOfLongestSubstring(string s) 
    {
        int result = 0;
        
        set<char> list;
        
        for(int i = 0, j = 0; i < s.size();)
        {
            if(i < j)
                break;
            if(list.find(s[i]) == list.end())
            {
                list.insert(s[i]);
                i += 1;
                result = max(result, i - j);
            }
            else
            {
                list.erase(s[j]);
                j += 1;
            }
        }
        
        return result;
    }
};
```
