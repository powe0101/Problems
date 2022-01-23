https://leetcode.com/problems/diagonal-traverse/
```c++
class Solution {
public:
    vector<int> findDiagonalOrder(vector<vector<int>>& mat) 
    {
        vector<int> result;
        
        bool isFlag = true;
        int i = 0; int j = 0;
        
        for(int k = 0; k < mat.size() * mat[0].size();)
        {
            if (isFlag == true)//짝수
            {
                for(; i >= 0 && j < mat.size(); --i, ++j)
                {
                    result.push_back(mat[i][j]);
                    ++k;
                }
                
                if(i < 0 && j <= mat.size()-1)
                    i = 0;
                if(j == mat.size())
                    i = i+2, --j;
            }
            else
            {
                for(; j >= 0 && i < mat.size(); ++i, --j)
                {
                    result.push_back(mat[i][j]);
                    ++k;
                }
                
                if (j < 0 && i <= mat.size()-1)
                    j = 0;
                if(i == mat.size())
                    j = j+2, --i;
            }
            isFlag ^= true;
        }
        return result;
    }
};
```
https://leetcode.com/problems/plus-one/
```c++
class Solution {
public:
    vector<int> plusOne(vector<int>& digits) {
        
        digits[digits.size()-1] += 1;
        for(int i = digits.size() - 1; i >= 0; --i)
        {
            if(digits[i] > 9)
            {
                digits[i] %= 10;
                if(i == 0)
                    digits.insert(digits.begin(), 1);
                else
                    digits[i-1] += 1;
            }
            else
                break;
        }
        return digits;
    }
};
https://leetcode.com/problems/third-maximum-number/
```c++
class Solution {
public:
    int thirdMax(vector<int>& nums) {
        
        sort(nums.begin(), nums.end(),greater<int>());
        
        nums.erase(unique(nums.begin(),nums.end()),nums.end());
        if(nums.size() < 3)
            return nums[0];
        
        return nums[2];
    }
};
```
