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

```c++
class Solution {
public:
    void ToZero(int x, int y, vector<vector<char>>& grid) {
        if(x < 0 || x >= grid.size()) 
            return;
        if(y < 0 || y >= grid[x].size()) 
            return;
        if(grid[x][y] == '0') 
            return;
        
        grid[x][y] = '0';
        
        ToZero(x+1, y, grid);
        ToZero(x-1, y, grid);
        ToZero(x, y-1, grid);
        ToZero(x, y+1, grid);
    }
    
    int numIslands(vector<vector<char>>& grid) {
        int result = 0;
        
        for(int i = 0; i < grid.size(); ++i)
        {
            for(int j = 0; j < grid[i].size(); ++j)
            {
                if(grid[i][j] =='0')
                    continue;
                
                result += 1;
                ToZero(i, j, grid);
            }
        }
        
        return result;
    }
};
```
