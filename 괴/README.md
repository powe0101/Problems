https://programmers.co.kr/learn/courses/30/lessons/42888

오픈채팅방

```c#

def solution(record):
    
    id = {}
    answer = []
    
    """
        "Enter uid1234 Muzi", => uid1234 : Muzi
        "Enter uid4567 Prodo", => uid4567 : Prodo
        "Leave uid1234", => [PASS]
        "Enter uid1234 Prodo", => uid1234 : Prodo
        "Change uid4567 Ryan" => uid4567 : Ryan
    """
    
    for r in record: 
        value = r.split()
        if len(value) == 3:
            # 고유값 : 닉네임
            id[value[1]] = value[2]
    
    """
        "Enter uid1234 Muzi", => Prodo + 님이 들어왔습니다.
        "Enter uid4567 Prodo", => Ryan + 님이 들어왔습니다.
        "Leave uid1234", => Prodo + 님이 나갔습니다.
        "Enter uid1234 Prodo", => Prodo + 님이 들어왔습니다.
        "Change uid4567 Ryan" => [PASS]
    """
    
    for r in record: 
        value = r.split()
        if len(value) == 3:
            # "Enter uid1234 Muzi"
            if value[0] == "Enter":
                answer.append('%s님이 들어왔습니다.' % id[value[1]])
        if len(value) == 2:
            # "Leave uid1234"
            if value[0] == "Leave":
                answer.append('%s님이 나갔습니다.' % id[value[1]])

    return answer

```

시간복잡도 : O(n)