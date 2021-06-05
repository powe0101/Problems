```c++
#include <bits/stdc++.h>
using namespace std;

unsigned int fibonacci_iter(unsigned int n) {

    if (n == 0) return 0; // 제 0항은 0을 반환한다.
    else if (n == 1) return 1; // 제 1항은 1을 반환한다.
    else {

        int result = 0;
        int iterA = 0, iterB = 1;

        for (int i = 2; i <= n; i++) {

            result = iterA % 1234567 + iterB % 1234567; 
            iterA = iterB;
            iterB = result;
        } // n항의 값을 구한다.
        
        return result;
    }
}

long long solution(int n) {
    long long answer = 0;

    answer = fibonacci_iter(n+1);
    
    return answer;
}
```
```c++
#include <bits/stdc++.h>
using namespace std;

pair<string, string> ParseData(const string &str)
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
    
    unordered_map<string,string> list; // id에 해당하는 닉네임 저장
    vector<string> ids; //id 값의 순서를 저장하는 리스트
    for(int i = 0; i < record.size(); ++i)
    {
        auto temp = ParseData(record[i]);
        //L과 EC의 아이디 출력 순서가 서로 다름
        switch(record[i][0])
        {
            case 'L':
                ids.push_back(temp.second); 
                break;
            case 'E':
            case 'C':
                ids.push_back(temp.first); 
                list[temp.first] = temp.second; //변경되는 경우 id에 맞게 닉네임을 새로 할당
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
