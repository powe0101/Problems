```c++
#include <bits/stdc++.h>

using namespace std;

int pop_front(vector<int>& numbers)
{
    int result = numbers[0];
    
    numbers.erase(numbers.begin());
    
    return result;
}

int solution(vector<int> numbers, int target) {
    int answer = 0;
    
    queue<int> list;
    int first = pop_front(numbers);
    
    list.push(-first);
    list.push(first);
    
    while(numbers.size() > 0)
    {
        int size = list.size();
        int temp = pop_front(numbers);
        
        for(int i = 0; i < size; ++i)
        {
            int q = list.front(); list.pop();
            
            list.push(q+temp);
            list.push(q-temp);
        }
    }
    
    for(int i = 0; i < list.size(); ++i){
        if(abs(list.front()) == target)
            answer += 1;
        list.pop();
    }
        
    return answer;
}
```
