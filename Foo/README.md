```c++
#include <bits/stdc++.h>
using namespace std;

pair<int,int> pop_front(queue<pair<int,int>>& maps)
{
    auto temp = maps.front();
    maps.pop();
    return temp;
}

int solution(vector<vector<int> > maps)
{
    int result = 0;
    const int height = maps.size();
    const int width = maps[0].size();
    
    queue<pair<int,int>> list;
    //탐색 기준점이 되는 좌표
    
    list.push(pair<int,int>(0,0));
    //시작점을 추가한다.
    
    while(list.empty() == false) //더이상 갈 수 없을 때까지 탐색하고, 최종 값이 나오면 아래 for 문에서 루프 종료
    {
        result += 1; ////탐색 회차 
        //cout << result << endl; 
        
        int size = list.size();
        //아래에서 다음 탐색 좌표가 추가되기 때문에 탐색할 좌표의 크기를 임시로 담아둔다.
        for(int i = 0; i < size; ++i)
        {
            const auto temp = pop_front(list);
            const auto x = temp.second;
            const auto y = temp.first;
            
            if(maps[y][x] == 0) //막힌 길 
                continue;
            if(x == width-1 && y == height-1) // 목표 위치 
                return result;
            
            maps[y][x] = 0; 
            //현재 탐색한 위치는 더이상 탐색 할 필요가 없으므로 막힌 길로 변경
            
            //cout << y << " " << x <<  " " << size << endl;
            //동서남북을 조사하고 갈 수 있으면 list에 넣는다.
            if(x+1 < width && maps[y][x+1] == 1)
                list.push(pair<int,int>(y,x+1));
            if(x-1 > -1 && maps[y][x-1] == 1)
                list.push(pair<int,int>(y,x-1));
            if(y+1 < height && maps[y+1][x] == 1)
                list.push(pair<int,int>(y+1,x));
            if(y-1 > -1 && maps[y-1][x] == 1)
                list.push(pair<int,int>(y-1,x));
        }
    }
    
    return -1; //탐색 할 수 있는 모든 길을 탐색 했지만 남은 길이 없는 경우
}
```c++
#include <bits/stdc++.h>
using namespace std;

int solution(string skill, vector<string> skill_trees) {
    //총 개수에서 틀린 개수를 빼기 위해 최대값 지정
    int answer = skill_trees.size();
    
    for(int i = 0; i < skill_trees.size(); ++i)
    {
        const string str = skill_trees[i];
        string temp = "";
        //skill에 있는 문자열 찾기 
        for(int j = 0; j < str.size(); ++j)
        {
            const char ch = str[j];
            const int pos = skill.find(ch);
            if(pos != string::npos)
                temp.push_back(ch);
        }
        
        if(temp.size() == 0)  //일치하는 문자열이 없는 경우
            continue;
        
        const int pos = skill.find(temp[0]);
        const string result = skill.substr(pos, temp.size());
        //cout << temp << " " << result << endl;
        //첫번째 문자를 찾아서 현재 유효한 스킬의 size 만큼 substr
        //시작 스킬이 없거나, 스킬트리가 일치하지 않으면 불가능.
        if((result != temp) || (result.front() != skill.front()))
            answer -= 1;
    }
    
    return answer;
}
```

