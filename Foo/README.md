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

