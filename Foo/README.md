```c++
class Solution {
public:
    int maxUniqueSplit(string s) 
    {
        unordered_set<string> list;

        int result = recursiveSplit(s, list);
        return result;
    }
    
    int recursiveSplit(string s,unordered_set<string>& list)
    {
        int result = 0;
        
        for(int i = 1; i <= s.size(); ++i)
        {
            string temp = s.substr(0,i);
            
            if(list.find(temp) == list.end())
            {
                list.insert(temp);
                result = max(result, recursiveSplit(s.substr(i), list) + 1);
                list.erase(temp);
            }
        }
        
        return result;
    }
};
```
