```c#
public class Solution // O(N^2)
{
    private int[] parent = new int[201];

    private int findParent(int n)
    {
        if (parent[n] == 0 || parent[n] == n)
        {
            return parent[n] = n;
        }
        return parent[n] = findParent(parent[n]);
    }

    public int solution(int n, int[,] computers)
    {
        for (int i = 0; i < n; i++) // N^2
        {
            for (int j = 0; j < n; j++)
            {
                if (computers[i,j] == 1)
                {
                   parent[findParent(j + 1)] = findParent(i + 1);
                }
            }
        }

        var root = new bool[n + 1];
        for (int i = 1; i <= n; i++)
        {
            var parent = findParent(i);
            if (parent != -1) 
            {
                root[parent] = true;
            }
        }
        
        var answer = 0;
        for (int i=1; i <= n ;i++)
        {
            if (root[i])
            {
                answer++;
            }
        }
        return answer;
    }
}
```



```c#
public class Solution { // O(N)
    public int SumOfUnique(int[] nums) {
        var count = new int[101];
        foreach(int num in nums)
        {
            count[num]++;
        }
        int ans = 0;
        foreach(int num in nums)
        {
            if (count[num] == 1)
            {
                ans += num;
            }
        }
        return ans;
    }
}
```

