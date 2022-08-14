https://leetcode.com/problems/remove-all-occurrences-of-a-substring/submissions/
```c++
class Solution {
public:
    string alphabets="abcdefghijklmnopqrstuvwxyz";

    void initialize(map<char,unsigned int> & tables,const string & pattern)
    {
        
        for(int i = 0; i < alphabets.size(); ++i)
        {
            const char ch = alphabets[i];
            tables[ch] = pattern.size();
        }
        
    }
    
    void makeTable(map<char,unsigned int> & tables, const string & pattern)
    {
        //last index is pattern's length
        for(int i = pattern.size()-2; i >=0; --i)
        {
            const char ch = pattern[i];
            const int value = pattern.size() - i - 1;
            
            if(tables[ch] > value){
                tables[ch] = value;
            }
        }
    }
    
    int findString(map<char, unsigned int>& tables, const string& pattern, const string& str)
    {
        unsigned int offset = 0;
    
        const auto patternLastIndex = pattern.size() - 1;
    
        vector<unsigned int> matches;
    
        while (offset <= str.size())
        {
            auto currentIndex = patternLastIndex;
            if (currentIndex + offset > str.size())
                break;
    
            while (pattern[currentIndex] == str[currentIndex + offset])
            {
                if (currentIndex == 0)
                {
                    return offset;
                }
                currentIndex--;
            }
    
            const char rightMostChar = str[patternLastIndex + offset];
            if (tables.find(rightMostChar) != tables.end())
            {
                offset += tables[rightMostChar];
            }
            else
            {
                offset += pattern.size();
            }
        }
    
        return -1;
    }
    string removeOccurrences(string s, string part) 
    {
        map<char,unsigned int> tables;
        
        initialize(tables, part);
        makeTable(tables, part);
        
        while(true)
        {
            auto offset = findString(tables,part, s);
            if(offset == -1)
                break;
            s.erase(offset, part.size());
        }
        
        return s;
    }
};
```

https://school.programmers.co.kr/learn/courses/30/lessons/12952?language=cpp
```c++
#include <bits/stdc++.h>

using namespace std;

int solution(int n) 
{
    int answer = 0;
    
    queue<pair<int,int>> list;
    
    list.push(0,0);
    
    while(list.size() > 0)
    {
        int size = list.size();
        
        for(int i = 0; i < size; ++i)
        {
            auto current = list.front(); list.pop();
            
            if()
        }
    }
    
    return answer;
}
```
