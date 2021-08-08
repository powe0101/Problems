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
