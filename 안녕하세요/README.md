https://leetcode.com/problems/stone-game/ O(NlogN)

```c++
#include <algorithm>
class Solution {
public:
    bool stoneGame(vector<int>& piles) {
        sort(piles.begin(), piles.end());
        
        int alice = 0;
        int bob = 0;
        for(int i = 0; i < piles.size(); i++) {
            if (i % 2 == 0) {
                bob += piles[i];
            } else {
                alice += piles[i];
            }
        }
        
        return alice > bob;
    }
};
```



https://programmers.co.kr/learn/courses/30/lessons/86491 O(N)

```c#
using System;
public class Solution
{
    public int solution(int[,] sizes)
    {
        int answer = 0;
        int w = 0, h = 0;
        for (int i = 0; i < sizes.GetLength(0); i++)
        {
            var (a, b) = (sizes[i, 0], sizes[i, 1]);
            if (a < b)
            {
                (a, b) = (b, a);
            }
            w = Math.Max(a, w);
            h = Math.Max(b, h);
        }
        answer = w * h;
        return answer;
    }
}
```

