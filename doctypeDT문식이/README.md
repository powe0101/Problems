멀리뛰기

```cs
using System.Collections.Generic;

public class Solution
{
    public long solution(int n)
    {
            // 경우의 수는 피보나치 수열이다.

            long answer = 0;
            List<long> list = new List<long>();

            list.Add(1); // n == 1인 경우 - (1)
            list.Add(2); // n == 2인 경우 - 경우의 수는 2 (1+1, 2)

            for (var i = 2; i < n; i++)
            {
                list.Add((list[i - 1] + list[i - 2]) % 1234567);
            }

            answer = list[n - 1] % 1234567;            
            return answer;
    }
}
```

오픈채팅방

```js
function solution(record) {
    var answer = [];
    var arr = [];
    var user = {};

    for (var i = 0; i < record.length; i++) {
        arr.push(record[i].split(' '));
    }

    for (var j = 0; j < arr.length; j++) {
        if (arr[j].length == 3) { // 3이 아니라면 Leave 거나 오류가 있는 경우. [Keyword] [User id] [Name] 이렇게 3개가 나와야한다.
            user[arr[j][1]] = arr[j][2]; // 이름 저장
            /*
            JS 객체
            object = {
                name: value,
            };
            구조로 저장한다.
            여기서 user[arr[j][1]] 은 name에 name 대신 각 유저의 id 를 넣은 것이고 (uid1234, uid5678 등)
            value 부분에 arr[j][2], 즉 name 값을 넣은 것이다. (Ryan, Prodo 등)
            
            따라서 결과물은
            user = {
                uid1234: Prodo,
                uid4567: Ryan
            };
            이다.
            */
        }
    }
    for (var k = 0; k < arr.length; k++) {
        if (arr[k][0] == "Enter") {
            answer.push(user[arr[k][1]] + "님이 들어왔습니다.");
        }
        else if (arr[k][0] == "Leave") {
            answer.push(user[arr[k][1]] + "님이 나갔습니다.");
        }
    }

    return answer;
}
```
