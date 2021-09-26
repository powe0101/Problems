```c++
#include <bits/stdc++.h>

using namespace std;

int myCompare(string X, string Y)
{
    // first append Y at the end of X
    string XY = X.append(Y);
 
    // then append X at the end of Y
    string YX = Y.append(X);
 
    // Now see which of the two
    // formed numbers is greater
    return XY.compare(YX) > 0 ? 1 : 0;
}

string solution(vector<int> numbers) {
    string answer = "";
    
    vector<string> list;
    for(int i = 0; i < numbers.size(); ++i){
        list.push_back(to_string(numbers[i]));
    }
    
    /*sort(list.begin(),list.end(),[&](string a, string b)-> bool {
        return a+b < b+a;
    });*/
    sort(list.begin(),list.end(), myCompare);
  
    for(int i = 0; i < list.size(); ++i)
        answer += list[i];
    /* while (!list.empty()) {
        answer += list.back();
        list.pop_back();
    }*/
    
    if(answer[0] == '0')
        return "0";
    
    return answer;
}
```
