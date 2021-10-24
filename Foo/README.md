```c++
class Solution {
public:
    void merge(vector<int>& nums1, int m, vector<int>& nums2, int n) 
    {
        vector<int> list;
        
        for(int i = 0; i < nums1.size(); ++i)
        {
            if(nums1[i] != 0)
                list.push_back(nums1[i]);
            else
            {
                for(int j = i; j < nums1.size(); ++j)
                {
                    if(nums1[j] != 0)
                    {
                        for(int k = i; k < j; ++k)
                            list.push_back(nums1[k]);
                        i = j-1;
                        break;
                    }
                }
            }
        }
        
        for(int i = 0; i < nums2.size(); ++i)
        {
            list.push_back(nums2[i]);
        }
        
        sort(list.begin(),list.end());
        
        if(list.size() < nums1.size())
        {
            for(int i = 0; i <= nums1.size()-list.size(); ++i)
            {
                list.push_back(0);
            }
        }
        
        nums1 = list;
        
    }
};
```
