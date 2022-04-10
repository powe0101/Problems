```c++
#include <bits/stdc++.h>
using namespace std;

int solution(string s) 
{
    int answer = s.size();

    
    for(int i = 1; i <= (s.size() / 2); ++i)
    {
        int count = 1;
        auto temp = s.substr(0, i);
        
        string str = "";
        string cmp = "";
        for(int j = i; j < s.size(); j += i)
        {
            cmp = s.substr(j,i);
            
            if(temp.compare(cmp) == false)
                count += 1;
            else
            {
                if(count == 1)
                {
                    str += temp;
                    temp = cmp;
                }//한개가 같은 경우
                else
                {
                    str += to_string(count) + temp;
                    temp = cmp;
                    count = 1;
                }
            }
            
            if(j + i >= s.size())
            {
                if(count != 1)
                {
                    str += to_string(count) + temp;
                }
                else
                {
                    str += s.substr(j);
                }
                break;
            }
        }
        if(answer > str.size())
            answer = str.size();
    }        
    
    return answer;
}
```
