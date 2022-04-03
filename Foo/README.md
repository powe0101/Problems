https://programmers.co.kr/learn/courses/30/lessons/42587?language=cpp
```c++
#include <bits/stdc++.h>

using namespace std;

int solution(vector<int> priorities, int location) {
    int answer = 0;
    
    priority_queue <int> pq;
    queue <pair<int,int>> q;
    for(int i = 0; i < priorities.size(); ++i)
    {
        int paper = priorities[i]; 
        
        pq.push(paper);
        q.push(make_pair(i, paper));
    }
    
    int step = 0;
    while(q.empty() == false)
    {
        auto temp = q.front(); q.pop();
        
        if(pq.top() == temp.second)
        {
            pq.pop();
            step += 1;
            
            if(temp.first == location)
                return step;
        }
        else
        {
            q.push(temp);
        }
    }
    
    return answer;
}
```
