https://leetcode.com/problems/3sum
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
        //소거 과정
        
        for(int i = 0; i < index; ++i)
        {
            if(i > 0 && nums[i] == nums[i-1])
                continue;
            
            const int num = nums[i];
            
            int left = i + 1; //0 +1 
            int right = nums.size() - 1; // right 
            //two pointer
            while(left < right)
            {
                const int temp = num + nums[left] + nums[right];
                
                if(temp > 0)
                    right -= 1; // -1
                else if(temp < 0)
                    left += 1; // +1
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
