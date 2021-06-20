```c#
public class Solution { // O(N)
    public int MinAddToMakeValid(string s) {
        int answer = 0;
        int top = 0;
        foreach(var ch in s)
        {
            if (ch == ')') top--;
            else {
                if (top < 0) {
                    answer += Math.Abs(top);
                    top = 0;
                }
                top++;
            }
        }
        answer += Math.Abs(top);
        return answer;
    }
}
```

```C#
public class Solution { // O(N)
    public int MaxArea(int[] height) {
        var left = 0;
        var right = height.Length - 1;
        var answer = 0;
        while(left < right)
        {
            var minHeight = Math.Min(height[left], height[right]);
            answer = Math.Max(answer, (right - left) * minHeight);
            if (height[left] < height[right])
            {
                left++;
            } else {
                right--;
            }
        }
        return answer;
    }
}
```

