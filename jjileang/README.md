https://programmers.co.kr/learn/courses/30/lessons/43162

```C#
using System;
using System.Collections.Generic;
public class Solution {
    public int solution(int n, int[,] computers) {
        int answer = 0;
        var size = (int)Math.Sqrt(computers.Length);
		var visited = new bool[size];

		for (int i = 0; i < size; i++)
		{
			if (!visited[i])
			{
				answer++;
				var queue = new Queue<int>(i);
				queue.Enqueue(i);
				Bfs(visited, computers, queue);
			}
		}
		return answer;
    }
 	private void Bfs(bool[] visited, int[,] computers , Queue<int> queue)
	{
		while (queue.Count > 0)
		{
			var computer = queue.Dequeue();
			visited[computer] = true;
			for (int j = 0; j < visited.Length; j++)
			{
    			if (computers[computer, j] == 1)
	    		{
					if (!visited[j])
					{
						queue.Enqueue(j);
					}
				}
			}
		}
	}
}
```


https://leetcode.com/problems/sum-of-unique-elements/

```C#
public class Solution {
    public int SumOfUnique(int[] nums)
    {
    	var dict = new Dictionary<int, int>();
    	var sum = 0;
    	for (int i = 0; i < nums.Length; i++)
    	{
    		if (dict.TryGetValue(nums[i], out var value))
    		{
    			if (value != -1)
    			{
    				dict[nums[i]] = -1;
    				sum -= nums[i];
    			}
    		}
    		else
    		{
    			dict.Add(nums[i], 1);
    			sum += nums[i];
    		}
    	}
    	return sum;
    }
}
```