# 프로그래머스_입실 퇴실 -> 자바
# 참고 포스팅 : https://velog.io/@courage331/%ED%94%84%EB%A1%9C%EA%B7%B8%EB%9E%98%EB%A8%B8%EC%8A%A4Java-%EC%9E%85%EC%8B%A4-%ED%87%B4%EC%8B%A4

import java.util.*;

class Solution {
    public int[] solution(int[] enter, int[] leave) {
        
        int[] answer = new int[enter.length];
        List<Integer> list = new ArrayList();
        int idx = 0;
        
        for(int i = 0; i < answer.length; i++){
            list.add(enter[i]);
            for(int j=0; j<list.size(); j++){
                
                // 방금 들어온 사람은 현재 list.size()-1 만큼의 사람을 마주침
                if(enter[i]==list.get(j)){
                    answer[list.get(j)-1] = list.size()-1;
                
                // 이미 list에 있는 값들은 새로운 사람을 만난것이므로 +1 처리
                }else{
                    answer[list.get(j)-1]++;
                }          
            }
            
            // 퇴실한 사람의 처리는, 사람이 입장한 후 확인하는데 leave의 인덱스값이 list에 있는지 체크하고 있다면, 제거처리,              없다면 그 인덱스에 머물러 있어야한다.
            while(idx<answer.length && list.contains(leave[idx])){
                list.remove(Integer.valueOf(leave[idx++]));
            }
        }
        
        return answer;
    }
}
