https://leetcode.com/problems/stone-game-vii/ 

```c++
class Solution {
public:
    int loop(const vector<int>& stones, vector<vector<int>>& dp, const int start, const int end, const int sum)
    {
        if(start > end) // recursive loop 방지
            return 0;
        if(dp[start][end] != -1) //infinity loop 방지
        {
            return dp[start][end];
        }
        
        int left = sum - stones[start] - loop(stones, dp, start+1, end, sum - stones[start]);
        int right = sum - stones[end] - loop(stones, dp, start, end-1, sum - stones[end]);
        
        dp[start][end] = max(left,right);
       
        return dp[start][end];
    }
    
    int stoneGameVII(vector<int>& stones) 
    {
        int result = 0;
        
        auto sum = accumulate(stones.begin(), stones.end(), 0);
        vector<vector<int>> dp(stones.size(), vector<int>(stones.size(),-1));
        
        result = loop(stones, dp, 0, stones.size()-1, sum);
        
        return result;
    }
};
```
https://leetcode.com/problems/count-binary-substrings/
```c++
class Solution {
public:
    int countBinarySubstrings(string s) 
    {
        int result = 0;
        
        int left = 0, right = 1;
        
        for(int i = 1; i < s.size(); ++i)
        {
            if(s[i] != s[i-1])
            {
                result += min(left,right);
                left = right;
                right = 1;
            }
            else
                right += 1;
        }
        
        return result + min(left,right);
    }
};
```

