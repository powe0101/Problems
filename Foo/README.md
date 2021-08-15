Climbing Stairs

```c++
class Solution {
public:
    int fibonacci_iter(int n) 
    {

        if (n == 0) return 0; // 제 0항은 0을 반환한다.
        else if (n == 1) return 1; // 제 1항은 1을 반환한다.
        else 
        {
            int result = 0;
            int iterA = 0, iterB = 1;
    
            for (int i = 2; i <= n; i++) 
            {
    
                result = iterA  + iterB;
                iterA = iterB;
                iterB = result;
    
            } // n항의 값을 구한다.
    
            return result;
        }
    }
    
    int climbStairs(int n) 
    {
        int result = fibonacci_iter(n+1);
        
        return result;
    }
};
```
모의고사
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


    return answer % 1234567;
}

```
