```c++
class Solution {
public:
    static bool compare(const vector<int>& a, const vector<int>& b)
    {
        if(a[0] < b[0])
            return true;
        return false;
    }
    
    vector<vector<int>> merge(vector<vector<int>>& intervals) 
    {      
        vector<vector<int>> list;
        
        sort(intervals.begin(),intervals.end(),compare);
        
        list.push_back(intervals[0]);        
        for(int i = 1; i < intervals.size(); ++i)
        {
            auto pair = intervals[i];
            auto temp = list[list.size()-1];
            if(temp[1] < pair[0])
            {
                list.push_back(pair);
            }
            else
            {
                list[list.size()-1][1] = max(temp[1], pair[1]);
            }
        }
        
        return list;
    }
};
```
