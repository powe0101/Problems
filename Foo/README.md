https://leetcode.com/problems/string-compression/submissions/
```c++
class Solution {
public:
    int compress(vector<char>& chars) 
    {
        if(chars.size() == 1)
            return 1;
        if(chars.size() == 2)
        {
            if(chars[0] == chars[1])
                chars[1] = '2';
            return 2;
        }
        
        vector<char> list;
        string str = "";
        int count = 1;
        
        for(int i = 0; i < chars.size()-1; ++i)
        {
            if(chars[i] != chars[i+1]){
                str += chars[i];
                if(count > 1)
                {
                    str += to_string(count);
                    count = 1;
                }
            }
            else
                count += 1;
        }
        str += chars[chars.size()-1];
        if(count > 1)
        {
            str += to_string(count);
            count = 1;
        }
        
        chars = vector<char>(str.begin(),str.end());
        return str.size();
    }
};
```
https://leetcode.com/problems/maximum-number-of-groups-entering-a-competition/
```c++
class Solution {
public:
    int maximumGroups(vector<int>& grades) 
    {
        int result = 0;
        
        return (-0.5 + sqrt(0.5 + 2*grades.size())); 
    }
};
class Solution {
public:
    int maximumGroups(vector<int>& grades) 
    {
        int total = 0;
        int k = 0;
        
        const int n = grades.size();
        
        while(total <= n)
        {
            total += ++k;
        }
        
        return k-1;
    }
};

class Solution {
public:
    int maximumGroups(vector<int>& grades) 
    {
        int result = 0;

        long long size = grades.size();
        long long count = 1;
        while(size > 0)
        {
            size -= count;
            count += 1;
            if(size >= 0)
                result += 1;
        }
        
        return result;
    }
};
```

