https://leetcode.com/problems/maximum-subarray/
```c++

class Solution {
public:
    int maxSubArray(vector<int>& nums) 
    {
        int result = nums[0];
        
        int temp = nums[0];
        for(int i = 1; i < nums.size(); ++i)
        {
            temp = max(temp+nums[i], nums[i]);
            result = max(temp, result);
        }
        
        return result;
    }
};
```

https://leetcode.com/problems/stone-game-vii/
```c++

```
