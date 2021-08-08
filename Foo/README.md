N으로 표현하기

```c++
#include <bits/stdc++.h>

using namespace std;
int answer = -1;

void dfs(int n, int pos, int num, int number) 
{
        if (pos > 8)
            return; //최솟값이 8보다 크면 -1을 return 합니다.

        if (num == number) //결과값이 목표값이랑 같으면
        {
            if (pos < answer || answer == -1) //작은값 찾기
            {
                //cout << pos << " " << answer << " " << endl;
                answer = pos;
            }
            return;
        }
    
        int nn=0;
        for (int i = 0; i < 4 ; ++i) //반복 회수 // 기존값 8
        {
            nn=nn*10+n; //5 이어붙이기 
            //if(i == 0)
            {
                //cout << nn << " " << " " << pos << endl;
            }
            dfs(n, pos + 1+i, num + nn, number);
            dfs(n, pos + 1+i, num - nn, number);
            dfs(n, pos + 1+i, num * nn, number);
            dfs(n, pos + 1+i, num / nn, number);
        }
}

int solution(int N, int number) {
    
    dfs(N, 0, 0, number);
    
    return answer;
}
```

거리두기 확인하기 (미완성)
```c++
#include <bits/stdc++.h>

using namespace std;


vector<int> solution(vector<vector<string>> places) {
    vector<int> answer;

    for(int i = 0; i < places.size(); ++i)
    {
        const auto room = places[i]; //vector<string>
        
        for(int j = 0; j < room.size(); ++j)
        {
            bool isFlag = false;
            for(int k = 0; k < room[j].size(); ++k)
            {
                int x = k;
                int y = j;
                vector<char> list;
                if(room[x][y] == 'P')
                {
                    if(x > 0)
                    list.push_back(room[x-1][y]);
                    if(x < 4)
                    list.push_back(room[x+1][y]);
                    if(x < 3 && room[x+1][y] != 'X')
                    list.push_back(room[x+2][y]);
                    if(x > 1 && room[x-1][y] != 'X')
                    list.push_back(room[x-2][y]);
                    
                    if(y > 0)
                    list.push_back(room[x][y-1]);
                    if(y < 4)
                    list.push_back(room[x][y+1]);
                    if(y < 3 && room[x][y+1] != 'X')
                    list.push_back(room[x][y+2]);
                    if(y > 1 && room[x][y-1] != 'X')
                    list.push_back(room[x][y-2]);
                    
                    if(x > 0 && y > 0 && room[x][y-1] != 'X' && room[x-1][y] != 'X')
                        list.push_back(room[x-1][y-1]);
                    if(x > 0 && y < 4 && room[x][y+1] != 'X' && room[x-1][y] != 'X')
                        list.push_back(room[x-1][y+1]);
                    if(x < 4 && y < 4 && room[x+1][y] != 'X' && room[x][y+1] != 'X')
                        list.push_back(room[x+1][y+1]);
                    if(x < 4 && y > 0 && room[x+1][y] != 'X' && room[x][y-1] != 'X')
                        list.push_back(room[x+1][y-1]);
                    
                    if(find(list.begin(),list.end(),'P') != list.end())
                    {
                        isFlag = true;
                        break;
                    }
                }
            }
            if(isFlag == true)
            {
                answer.push_back(0);
                break;
            }
            else{
                answer.push_back(1);
                break;
            }
        }
    }
    
    return answer;
}
```
