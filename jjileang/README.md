11. Container With Most Water
https://leetcode.com/problems/container-with-most-water/
```C#
public class Solution
{
	public int MaxArea(int[] height)
	{
		var max = 0;
		var start = 0;
		var last = height.Length - 1;
		while (last > start)
		{
			var gap = last - start;
			var rect = gap * Math.Min(height[start], height[last]);
			if (max < rect)
			{
				max = rect;
			}
			if (height[start] < height[last])
			{
				start++;
			}
			else
			{
				last--;
			}
		}
		return max;
	}
}
```
N

---
921. Minimum Add to Make Parentheses Valid
https://leetcode.com/problems/minimum-add-to-make-parentheses-valid/
```C#
public class Solution
{
	public int MinAddToMakeValid(string s)
	{
		var stack = new Stack<char>();
		for (int i = 0; i < s.Length; i++)
		{
			if (stack.Count == 0)
			{
				stack.Push(s[i]);
			}
			else
			{
				var peek = stack.Peek();
				if (peek == '(' && s[i] == ')')
				{
					stack.Pop();
				}
				else
				{
					stack.Push(s[i]);
				}
			}
		}
		return stack.Count;
	}
}
```
N