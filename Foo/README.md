https://programmers.co.kr/learn/courses/30/lessons/12915

```c++
#include <bits/stdc++.h>

using namespace std;


vector<string> solution(vector<string> strings, int n) 
{
 
    for(int i = 0; i < strings.size(); ++i)
    {
        strings[i].insert(0,1, strings[i][n]);
    }
    
    sort(strings.begin(),strings.end());
    
    for(int i = 0; i < strings.size(); ++i)
    {
        strings[i].erase(0,1);
    }
    
    return strings;
}
```
시간복잡도 : N?
