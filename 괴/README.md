https://leetcode.com/problems/minimum-add-to-make-parentheses-valid/

Minimum Add to Make Parentheses Valid

```c# => Accepted

public class Solution {
    public int MinAddToMakeValid(string s) {
        
        var count = s.Length;
        
        for (int i = 0; i < count; i++)
        {
            s = s.Replace("()","");
        }
        
        return s.Length;
    }
}
```

시간복잡도 : O(n)

https://leetcode.com/problems/container-with-most-water/

Container With Most Water

```c# => Time Limit Exceeded
public class Solution {
    public int MaxArea(int[] height) {
        
        var max = 0;
        
        for (int i=0; i<height.Length; i++)
        {
            var result = 0;
            var start = height[i];
            
            for (int j=0; j<height.Length; j++)
            {
                var end = height[j];
                
                if (i < j)
                {
                    var depth = j - i;
                    
                    if (start >= end)
                    {
                        result = depth * end;
                    }else
                    {
                        result = depth * start;
                    }
                    
                    if (max < result)
                    {
                        max = result;
                    }
                }
            }
        }
        
        return max;
    }
}
```

시간복잡도 : O(n^2)