```c++
#include <string>
#include <vector>
#include <algorithm>
using namespace std;

vector<int> solution(int brown, int yellow) {
    vector<int> answer;
    vector<int> yellowDivisors;
    for(int i =1; i<=yellow; i++) {
        if (yellow % i == 0) {
            yellowDivisors.push_back(i);
        }
    }
    // 가로가 넒음
    for(int i = 0;i< yellowDivisors.size();i++) {
        int width = yellowDivisors[i];
        int height = yellow / yellowDivisors[i];
        
        if (width < height) {
            swap(width, height);
        }
        
        int need = width * 2 + height * 2 + 4;
        if (brown == need) {
            answer.push_back(width + 2);
            answer.push_back(height + 2);
            break;
        }
        
    }
    return answer;
}
```

입실 퇴실 - https://programmers.co.kr/learn/courses/30/lessons/86048

```c++
#include <string>
#include <vector>
#include <algorithm>
using namespace std;

vector<int> solution(vector<int> enter, vector<int> leave) {
    vector<int> answer(enter.size());
    vector<int> orders(enter.size() + 1);
    
    int order = 0;
    for(int number : enter) {
        orders[number] = order++;
    }
    
    int maxOrder = -1;
    for(int i = 0; i < leave.size(); i++) {
        maxOrder = max(maxOrder, orders[leave[i]]);
        for(int j = i + 1; j < leave.size(); j++) {
            if (orders[leave[j]] < maxOrder) {
                answer[leave[i] - 1]++;
                answer[leave[j] - 1]++;
            }
        }
    }
    
    return answer;
}
```

