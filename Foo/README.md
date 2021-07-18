```c++
#include <bits/stdc++.h>

using namespace std;
string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
int solution(string name) {
    int answer = 0;
    int minIndex = name.size() - 1;
    
    for(int i = 0; i < name.size(); ++i)
    {
        const int upPos = name[i] - 'A';
        const int downPos = abs('Z' - name[i] + 1);
        
        int pos = upPos > downPos ? downPos : upPos;

        answer += pos;
        
        int index = i + 1;
        while(index < name.size() && name[index] == 'A')
            index += 1;
        
        minIndex = min(minIndex, (int)((i * 2) + name.size() - index));
        
        //cout << upPos << " " << downPos << " " << name[i] << " " << pos << endl;
    }
    //cout << minIndex << endl;
    answer += minIndex;
    
    return answer;
}
```
시간복잡도 
