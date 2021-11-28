```c++
#include <bits/stdc++.h>

using namespace std;

pair<int,int> pop_front(queue<pair<int,int>>& list)
{
    auto temp = list.front(); 
    list.pop();
    return temp;
}

bool isPuddles(const unsigned& x, const unsigned& y, const vector<vector<int>>& puddles)
{
    for(int i = 0; i < puddles.size(); ++i)
    {
        if(x == puddles[i][0] && y == puddles[i][1])
            return true;
    }
    
    return false;
}

int solution(int m, int n, vector<vector<int>> puddles) {
    const int div = 1000000007;

    auto answer = 0;
    
    queue<pair<int, int>> list;
    list.push(make_pair(1,1)); // start position x = 1, y = 1
    
    while(list.empty() == false)
    {
        const auto size = list.size();
        
        for(int i = 0; i < size; ++i)
        {
            const auto pos = pop_front(list);
            
            if(pos.first == m && pos.second == n) // end position
            {
                answer += 1;
                continue; 
            }
            
            if(pos.first+1 <= m && isPuddles(pos.first+1, pos.second, puddles) == false) // x+1 and not puddle
                list.push(make_pair(pos.first+1, pos.second));
            if(pos.second+1 <= n && isPuddles(pos.first, pos.second+1, puddles) == false) // y+1 and not puddle
                list.push(make_pair(pos.first, pos.second+1));
        }
    }
    
    return answer % div;
}
```

```c++
class Solution {
public:
    struct parentheses{
        int open;
        int close;
        string str;
        
        parentheses(int o, int c, string s)
        {
            open = o;
            close = c;
            str = s;
        }
        
    };
    
    parentheses pop_front(queue<parentheses>& list)
    {
        auto temp = list.front();
        list.pop();
        
        return temp;
    }
    
    vector<string> generateParenthesis(int n) 
    {
        vector<string> result;
        
        queue<parentheses> list;
        list.push(parentheses(1,0,"("));
        while(list.empty() == false)
        {
            int size = list.size();
            
            for(int i = 0; i < size; ++i)
            {
                auto temp = pop_front(list);
                
                if(temp.str.size() == n*2){
                    result.push_back(temp.str);
                    continue;
                }
                
                if(temp.open < n)
                    list.push(parentheses(temp.open+1, temp.close, temp.str + '('));
                if(temp.close < temp.open)
                    list.push(parentheses(temp.open, temp.close+1, temp.str + ')'));
            }
        }

        list = queue<parentheses>();
        return result;
    }
};
```
