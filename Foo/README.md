http://naver.com
```python
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
