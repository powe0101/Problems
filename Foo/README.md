```c++
#include <bits/stdc++.h>
using namespace std;

pair<string, string> GetData(const string &str)
{
    pair<string,string> temp;
    string name = "";
    string id = "";
    int i = str.size() - 1;
    for(; i >= 0; --i)
    {
        if(str[i] == ' ')
        {
            i -= 1;
            break;
        }
        name += str[i];
    }
    
    for(; i >= 0; --i)
    {
        if(str[i] == ' ')
            break;
        id += str[i];
    }
    
    reverse(id.begin(),id.end());
    reverse(name.begin(), name.end());
    temp.first = id;
    temp.second = name;
    
    return temp;
}

vector<string> solution(vector<string> record) {
    vector<string> answer;
    
    unordered_map<string,string> list;
    vector<string> ids;
    for(int i = 0; i < record.size(); ++i)
    {
        auto temp = GetData(record[i]);
        switch(record[i][0])
        {
            case 'L':
                ids.push_back(temp.second);
                break;
            case 'E':
            case 'C':
                ids.push_back(temp.first);
                list[temp.first] = temp.second;
                break;
        }
    }

    for(int i = 0; i < record.size(); ++i)
    {
        switch(record[i][0])
        {
            case 'E':
                answer.push_back(list[ids[i]] + "님이 들어왔습니다.");
                break;
            case 'L':
                answer.push_back(list[ids[i]] + "님이 나갔습니다.");
                break;
        }
    }
    
    return answer;
}
```
