https://school.programmers.co.kr/learn/courses/30/lessons/67256?language=cpp
```c++
#include <bits/stdc++.h>

using namespace std;

void ChangeCurrentPos(queue<int>& currentHandPos, int number)
{
    currentHandPos.pop();
    currentHandPos.push(number);
}

int FindDistance(int number, int pos)
{
    vector<vector<int>> keypads = {{1,2,3},{4,5,6},{7,8,9},{'*',0,'#'}};
    int x1,y1;
    int x2,y2;
    
    for(int i = 0; i < keypads.size(); ++i)
    {
        for(int j = 0; j < keypads[i].size(); ++j)
        {
            const auto key = keypads[i][j];
            if(key == number)
                x2 = i; y2 = j;
            if(key == pos)
                x1 = i; y1 = j;
        }
    }
    
    int a = (x2 - x1);
    int b = (y2 - y1);
    
    return sqrt(pow(a,2) + pow(b,2));
}

string solution(vector<int> numbers, string hand) {
    string answer = "";
    
    queue<int> left;
    left.push('*');
    
    queue<int> right;
    right.push('#');
    
    for(int i = 0; i < numbers.size(); ++i)
    {
        const auto number = numbers[i];
        cout << left.front() << " " << right.front() << " " << number << endl;

        if(number == 1 || number == 4 || number == 7)
        {
            answer += 'L';
            ChangeCurrentPos(left, number);
        }
        else if(number == 3 || number == 6 || number == 9)
        {
            answer += 'R';
            ChangeCurrentPos(right, number);
        }
        else if(number == 2 || number == 5 || number == 8 || number == 0)
        {
            int leftDistance = FindDistance(number, left.front());
            int rightDistance = FindDistance(number, right.front());
            
            if(leftDistance < rightDistance)
            {
                answer += 'L';
                ChangeCurrentPos(left, number);
            }
            else if(leftDistance > rightDistance)
            {
                answer += 'R';
                ChangeCurrentPos(right, number);
            }
            else if(leftDistance == rightDistance)
            {
                if(hand == "right")
                {
                    answer += 'R';
                    ChangeCurrentPos(right, number);
                }
                else if(hand == "left")
                {
                    answer += 'L';
                    ChangeCurrentPos(left, number);
                }
            }
        }
    }
    
    return answer;
}
```
class Solution {
public:
    vector<string> restoreIpAddresses(string s) 
    {
        vector<string> answer;
        
        queue<string> list;
        list.push(to_string(s[0]));
        
        int length = s.size() + 4;
        
        while(list.size() > 0)
        {
            int size = list.size();
            for(int i = 0; i < size; ++i)
            {
                auto temp = list.front(); list.pop();
                if(length == temp.size())
                {
                    answer.push_back(temp);
                    continue;
                }
                
                if()
            }
        }
        
        return answer;
    }
};
```c++

```
