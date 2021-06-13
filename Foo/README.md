```C++
#include <bits/stdc++.h>
using namespace std;

void dfs(int n, const vector<vector<int>> & computers, int index, vector<bool>& visit)
{
    visit[index] = true;

    for(int i = 0; i < n; ++i)
    {
        const bool isConnected = computers[index][i] == 1;

        if(isConnected && i != index && visit[i] == false)
            dfs(n, computers, i, visit);
    }
}

int solution(int n, vector<vector<int>> computers) {
    int answer = 0;

    vector<bool> visit(n);
    for(int i = 0; i < n; ++i)
    {
        if(visit[i] == true)
            continue;
        dfs(n, computers, i, visit);
        answer += 1;
    }

    return answer;
}
```
시간 복잡도 O(N^2)

https://soobarkbar.tistory.com/61

```C++
class Solution {
public:
    int sumOfUnique(vector<int>& nums) {
        int result = 0;
        map<int,int> list;
        
        for(int i = 0; i < nums.size(); ++i)
        {
            const int temp = nums[i];
            list[temp] += 1;
        }
        
        for(auto iter = list.begin(); iter != list.end(); ++iter)
        {
            const auto temp = *iter;
            //cout << temp.first << " " << temp.second << endl;
            if(temp.second == 1)
                result += temp.first;
        }
        
        //cout << endl;
        return result;
    }
};
```

O(N)
