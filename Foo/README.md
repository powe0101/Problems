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
https://programmers.co.kr/learn/courses/30/lessons/42586
```c++
#include <bits/stdc++.h>

using namespace std;

int pop_front(vector<int>& list)
{
    int temp = list.front();
    list.erase(list.begin());
    return temp;
}

vector<int> solution(vector<int> progresses, vector<int> speeds) 
{
    vector <int> answer;
    
    int maximum = -1;
    int count = 0;

    while(progresses.empty() == false)
    {
        const int progress = pop_front(progresses);
        const int speed = pop_front(speeds);
        
        const int day = ceil(((double)(100 - progress) / speed));
        
        if(maximum >= day) // 기존 진행 중인 작업보다 더 적게 걸리면
            count += 1;
        else
        {
            maximum = day; // 더 오래걸리면 최대값 변경
            if(count > 0)
                answer.push_back(count);
            count = 1; //초기화
        }
    }
    
    answer.push_back(count); //남은 작업 추가
    return answer;
}
```
시간복잡도 O(N)
