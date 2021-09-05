https://leetcode.com/problems/search-in-rotated-sorted-array/
https://leetcode.com/problems/3sum/
```c++
class Solution {
public:
    int search(vector<int>& nums, int target) 
    {
        
        for(int i = 0; i < nums.size(); ++i)
        {
            const int num = nums[i];
            if(num == target)
                return i;
        }
        
        return -1;
    }
};
```

```c++
class Solution {
public:
    vector<vector<int>> threeSum(vector<int>& nums) {
        vector<vector<int>> result;

        sort(nums.begin(),nums.end());
        
        const int index = findPositiveIndex(nums);
        
        if(index == -1)
        {
            int count = 0;
            for(int i = 0; i < nums.size(); ++i)
            {
                if(nums[i] == 0)
                    count += 1;
            }
            
            if(count >= 3)
                return vector<vector<int>>{{0,0,0}};
            
            return result;
        }
        
        for(int i = 0; i < index; ++i)
        {
            if(i > 0 && nums[i] == nums[i-1])
                continue;
            
            const int num = nums[i];
            
            int left = i + 1;
            int right = nums.size() - 1;
            
            while(left < right)
            {
                const int temp = num + nums[left] + nums[right];
                
                if(temp > 0)
                    right -= 1;
                else if(temp < 0)
                    left += 1;
                else // 0
                {
                    result.push_back(vector<int>{num, nums[left], nums[right]});
                    ++left; --right;
                    while(nums[left] == nums[left-1] && left < right)
                        left += 1;
                    while(nums[right] == nums[right+1] && left < right)
                        right -= 1;
                }
                
            }
        }
        
        return result; 
    }
    
    int findPositiveIndex(vector<int>& nums)
    {
        for(int i = 0; i < nums.size(); ++i)
        {
            if(nums[i] > 0)
                return i;
        }
        return -1;
    }
};
```
