https://leetcode.com/problems/longest-substring-without-repeating-characters/

```c++
#include <algorithm> // 시간복잡도 O(N)
using namespace std;
class Solution {
public:
    int lengthOfLongestSubstring(string s) {
        int answer = 0;
        int start = 0;
        int end = 0;
        bool used[128] = {0, };
        while(start <= end && end < s.size()) {
            if (used[s[end]]) {
                used[s[start]] = false;
                start++;
            } else {
                used[s[end]] = true;
                end++;
            }
            
            answer = max(answer, end - start);
        }
        return answer;
    }
};
```



 https://leetcode.com/problems/unique-paths/ 

```c++
class Solution { // 시간복잡도 O(N+M), 공간복잡도 O(N+M)
public:
    int uniquePaths(int m, int n) {
        int dp[101][101] = { 0 };
        dp[0][1] = 1;
        for(int i=1; i<=m; i++) {
            for(int j =1; j<=n; j++) {
                dp[i][j] = dp[i-1][j] + dp[i][j-1];
            }
        }
        return dp[m][n];
    }
};
```



```c++
class Solution { // 시간복잡도 O(N+M), 공간 O(1)
private:
public:
    int uniquePaths(int m, int n) {
        if (m == 1 || n == 1) {
            return 1;
        }
        long answer = 1;
        // 항상 m > n
        m--;
        n--;
        if (m < n) {
            int temp = m;
            m = n;
            n = temp;
        }
        for (int i = (m + n); i > m; i--) {
            answer *= i;
            if (answer % n == 0 && n > 1) {
                answer /= n;
                n--;
            }
        }
        while (n > 1) {
            answer /= n;
            n--;
        }
        return (int)answer;
    }
};

```

