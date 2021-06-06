오픈채팅방
https://programmers.co.kr/learn/courses/30/lessons/42888
```JS

function solution(record) {
    
    var users = {};
    var answer = [];
    var actions = [];
    record.forEach(x=> {
        var splited = x.split(" ");
        
        var action = splited[0];
        var id = splited[1];
        var nickName = splited[2];
        
        switch(action){
            case "Enter":
                users[id] = nickName;
                actions.push([action, id]);
                break;
            case "Leave":
                actions.push([action, id]);
                break;
            case "Change":
                users[id] = nickName;
                break;
        }
    });
    
    actions.forEach(x=> {
              
        var action = x[0];
        var id = x[1];
        
        switch(action){
            case "Enter":
                answer.push(users[id]+"님이 들어왔습니다.");
                break;
            case "Leave":
                answer.push(users[id]+"님이 나갔습니다.");
                break;
        }
    });
        
    return answer;
}
```
N

멀리뛰기
https://programmers.co.kr/learn/courses/30/lessons/12914#

```C#
using System.Collections.Generic;

public class Solution {
    public long solution(int n) {
			var result = new List<int>() { 1, 2 };

			if (n < 3)
			{
				return result[n-1];
			}

			for (int i = 2; i < n; i++)
			{
				result.Add((result[i - 1] + result[i - 2])% 1234567);
			}

			return result[n-1]% 1234567;
    }
}
```
N