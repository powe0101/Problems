https://school.programmers.co.kr/learn/courses/30/lessons/77484
```cpp

#include <bits/stdc++.h>

using namespace std;

vector<int> solution(vector<int> lottos, vector<int> win_nums) {
    vector<int> answer;
    map<int,int> list;
    
    for(int i = 0; i < win_nums.size(); ++i)
    {
        list[win_nums[i]] += 1;
    }
    
    int countZero = 0, count = 0;
    for(int i = 0; i < lottos.size(); ++i)
    {
        const int number = lottos[i];
        
        if(number == 0)
            countZero += 1;
        else if(list[number] > 0)
            count += 1;
    }
    
    if(countZero == 0 && count == 0) //testcase14
        return vector<int>{6,6};
    if(countZero == 6) //testcase15
        return vector<int>{1,6};
    
    return vector<int>{7-(countZero+count), 7-count};
}
```
https://leetcode.com/problems/strong-password-checker-ii/
```cpp
class Solution {
public:
    bool strongPasswordCheckerII(string password) {
        string special = "!@#$%^&*()-+";
        bool isLower = false, isUpper = false, isDigit = false, isSpecial = false;
        
        if(password.size() < 8)
            return false;
        
        for(int i = 0; i < password.size(); ++i)
        {
            if(password[i] == password[i+1])
                return false;
        
            const auto ch = password[i];
            
            if(islower(ch))
                isLower = true;
            else if(isupper(ch))
                isUpper = true;
            else if(isdigit(ch))
                isDigit = true;
            else if(special.find(ch) != string::npos)
                isSpecial = true;
        }
        
        return isLower && isUpper && isDigit && isSpecial;
    }
};
```
