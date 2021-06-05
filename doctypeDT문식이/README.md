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
    var id = [];
    var newId = [];
    var name = [];
    var user = []; // id, 이름 저장
    var key = [];

    for (var i = 0; i < record.length; i++) {
        arr.push(record[i].split(' '));
        if (arr[i][0] != "Leave") { // leave 엔 이름이 없다.
            id.push(arr[i][1]);
            name.push(arr[i][2]);
        }
        if (arr[i][0] != "Change") { // chnage 는 출력하지 않는다.
            key.push([arr[i][0], arr[i][1]]);
        }
    }
    id.reverse(); // 최신 순으로 역정렬
    name.reverse();

    for (var j = 0; j < id.length; j++) // 중복 삭제 
        if (newId.indexOf(id[j]) == -1) newId.push(id[j]);

    for (var k = 0; k < newId.length; k++) // 2차원 배열로 저장
        user.push([newId[k], name[k]]);

    user.reverse(); // 순서대로 역정렬

    for (var l = 0; l < key.length; l++) { // enter, leave 개수 만큼 루프
        if (!user[l]) { // 인덱스 밖으로 가면 0부터 다시 시작
            user[l] = user[0];
        }
        if (key[l][1] == user[l][0]) { // id 가 같다면
            if (key[l][0] == "Enter") {
                answer.push(user[l][1] + "님이 들어왔습니다.");
            }
            else if (key[l][0] == "Leave") {
                answer.push(user[l][1] + "님이 나갔습니다.");
            }
        }
    }

    return answer;
}
input = ["Enter uid1234 Muzi", "Enter uid4567 Prodo", "Leave uid1234", "Enter uid1234 Prodo", "Change uid4567 Ryan"]; // 1234 : Muzi->Prodo 4567 : Prodo -> Ryan
console.log(solution(input));
```
