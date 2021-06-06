# 연습문제 - 멀리 뛰기

https://programmers.co.kr/learn/courses/30/lessons/12914


```Java
class Solution {
    public long solution(int n) {
        if(n <= 2) return n;
        
        // long long answer = 0;
        long [] arr = new long[n];
        arr[0] = 1;
        arr[1] = 2;
        
        for(int i=2; i<n; i++) {
            arr[i] = (arr[i-2] + arr[i-1]) % 1234567;
        }
        
        return arr[n-1];
    }   
}

```

시간복잡도 : O(n)  
피보나치 수열을 계산하는 문제와 동일함.  
멀리뛰기를 할 수 있는 방법의 개수가 피보나치 수열처럼 증가


<br />

# 2019 KAKAO BLIND RECRUITMENT - 오픈채팅방


https://programmers.co.kr/learn/courses/30/lessons/42888


```Java
import java.util.Map;
import java.util.Map.Entry;
import java.util.HashMap;
import java.util.Set;
import java.util.ArrayList;

class Solution {
    public String[] solution(String[] record) {
        String[][] strArr = new String[record.length][3];
        
        // 메시지를 명령어, uid, 닉네임으로 나눈다.
        for(int i=0; i<record.length; i++) {
            strArr[i] = record[i].split(" ");
        }
        
        // uid와 닉네임을 저장할 맵을 만든다.
        // 맵은 같은 키값으로 값을 여러 번 저장하면, 가장 마지막으로 저장한 값만 남는다.
        HashMap<String, String> map = new HashMap<>();
        
        // 맵의 특성을 이용해 [uid : 닉네임] 저장을 모든 메시지에 대해서 실행한다.
        // 아래 for문을 실행하고 나면 map에 uid에 대한 마지막 닉네임이 저장됨.
        // 단 Leave는 뺀다. 닉네임 변화와 무관함.
        for(int i=0; i<strArr.length; i++) {
            if(!strArr[i][0].equals("Leave")) {
                map.put(strArr[i][1], strArr[i][2]);
            }
        }
        
        // 결과의 크기를 모르므로 배열 크기 조절이 자유로운 ArrayList를 활용
        ArrayList<String> list = new ArrayList<String>();
        
        // 입력받은 메시지 중 Enter, Leave만 골라서 해당 uid에 맞는 마지막 닉네임으로 변경해준다.
        for(int i=0; i<strArr.length; i++) {
            if(strArr[i][0].equals("Enter")) {
                list.add(map.get(strArr[i][1]) + "님이 들어왔습니다.");
            } else if(strArr[i][0].equals("Leave")) {
                list.add(map.get(strArr[i][1]) + "님이 나갔습니다.");
            }
        }
        
        // 잘 나오는지 확인용
        // for(int i=0; i<list.size(); i++) {
        //     System.out.println(list.get(i));
        // }
        
        // 메소드 반환형에 맞춰 ArrayList를 배열로 변경한다.
        String[] answer = list.toArray(new String[0]);
        
        return answer;
    }
}
```

시간복잡도 : O(n)  
자바의 map이 같은 키값에 대해서는 마지막에 put한 값만 저장하기 때문에 그 특성을 이용하여 풀었음

