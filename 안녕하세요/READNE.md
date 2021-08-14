## [모의고사](https://programmers.co.kr/learn/courses/30/lessons/42840)
```c++
// O(3N) -> O(N) N: 시험문제수
#include <string>
#include <vector>
using namespace std;
vector<int> solution(vector<int> answers) {
    vector<int> answer;
    vector<vector<int>> mark = {
        { },
        { 1, 2, 3, 4, 5 },
        { 2, 1, 2, 3, 2, 4, 2, 5 },
        { 3, 3, 1, 1, 2, 2, 4, 4, 5, 5 }
    };
    int idx[4] = { 0 };
    int grade[4] = { 0 };
    int maxGrade = 0;
    for(auto number : answers) {
        for(int i=1; i<=3; i++) {
            if (number == mark[i][idx[i]]) {
                grade[i]++;
            }
            idx[i] = (idx[i] + 1) % mark[i].size();
            if (grade[i] > maxGrade) {
                maxGrade = grade[i];
            }
        }
    }
    for(int i = 1; i<=3; i++) {
        if (grade[i] == maxGrade) {
            answer.push_back(i);
        }
    }
    
    return answer;
}
```


## [70.Climbing Staris](https://leetcode.com/problems/climbing-stairs/)

```c++
// O(N)
class Solution {
public:
    int climbStairs(int n) {
        if (n <= 2) {
            return n;
        }
        int a1 = 2;
        int cur = 3;
        for(int i = 4; i <= n; i++) {
            int temp = cur;
            cur = cur + a1;
            a1 = temp;
        }
        return cur;
    }
};
```