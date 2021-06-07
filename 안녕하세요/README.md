## 멀리 뛰기

https://programmers.co.kr/learn/courses/30/lessons/12914

방법 1

```c#
public class Solution // O(n)
{
    const long MOD = 1234567;
    public long solution(int n)
    {
        long answer = 0;
        var dp = new int[2001];
        dp[0] = 0; dp[1] = 1; dp[2] = 2;
        for (int i = 3; i <= n; i++)
        {
            dp[i] = (int)((dp[i - 1] + dp[i - 2]) % MOD);
        }
        return dp[n];
    }
}
```

방법2

```c#
public class Solution // O(n)
{
    const long MOD = 1234567;
    public long solution(int n)
    {
        if (n <= 2) return n;
        long n2 = 1, n1 = 2, cur = 0;
        for (int i = 3; i <= n; i++)
        {
            cur = (int)((n1 + n2) % MOD);
            n2 = n1;
            n1 = cur;
        }
        return cur;
    }
}
```

방법3

```c#
public class Solution // O(n)
{
    const long MOD = 1234567;
    readonly int[] memo = new int[2000];
    public int jump(int n)
    {
        if (n <= 2)
        {
            return n;
        }
        if (memo[n] > 0) {
            return memo[n];
        }
        return memo[n] = (int)((jump(n - 1) + jump(n - 2)) % MOD);
    }
    public long solution(int n)
    {
        return jump(n);
    }
}
```

## 오픈 채팅방

https://programmers.co.kr/learn/courses/30/lessons/42888

```c++
#include <string> // Record: N -> O(N)
#include <vector>
#include <sstream>
#include <unordered_map>
using namespace std;
#define umap unordered_map


struct Action {
    string action;
    string id;
    string nickname;
    Action(string message) {
        istringstream iss(message); // stringstream으로 사용 가능함
        iss >> action >> id >> nickname;
    }
};

vector<string> solution(vector<string> record) {
    vector<string> answer;
    umap<string, string> member;
    vector<Action> history;
    for (string command : record) {
        Action message = Action(command);
        char action = message.action[0];
        if (action != 'C') {
            history.push_back(message);
        }
        if (action == 'C' || action == 'E') {
            member[message.id] = message.nickname;
        }
    }
    for (Action action : history) {
        stringstream ss;
        ss << member[action.id] << "님이 ";
        ss << ((action.action[0] == 'E') ? "들어왔습니다." : "나갔습니다.");
        answer.push_back(ss.str());
    }
    return answer;
}
```

- map

  - 균형 이진 트리

  - key별로 정렬

  - unordered_map 보다 느리다고 한다.

    > map containers are generally slower than unordered_map containers to access individual elements by their key, but they allow the direct iteration on subsets based on their order. - http://www.cplusplus.com/reference/map/map/?kw=map

- unordered_map

  - hash 방식
  - 평균적인 경우 O(1), 최악의 경우 O(N) (해쉬충돌 등)
