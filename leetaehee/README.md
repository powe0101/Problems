# Summer/Winter Coding(~2018) - 스킬트리

https://programmers.co.kr/learn/courses/30/lessons/49993


```Java
import java.util.*;

class Solution {
    public int solution(String skill, String[] skill_trees) {
        int answer = 0;
        
        // 스킬 순서와 상관이 없는 기타 스킬을 지우는 단계.
        for(int i=0; i<skill_trees.length; i++) {
            String temp = "";   // 스킬 순서와 상관없는 스킬을 지운 결과를 담는 변수
            boolean flag = true;    // 스킬 순서에 맞는지 검사 true = 맞음, false = 안맞음
            
            // 스킬트리 배열에서 스킬트리를 꺼내서 스킬과 비교하고, 순서와 관련없는 불필요한 스킬은 제거한다.
            for(int j=0; j<skill_trees[i].length(); j++) {
                if( skill.contains( Character.toString(skill_trees[i].charAt(j)) ) ) {
                    temp += skill_trees[i].charAt(j);
                }
            }

            // System.out.println(temp);    // 스킬트리에 없는 스킬이 지워졌는지 확인용
            
            // 불필요한 값이 제거된 스킬트리를 스킬순서와 비교한다.
            for(int l=0; l<temp.length(); l++) {
                if(temp.charAt(l) != skill.charAt(l))
                    flag = false;
            }
            
            if(flag)
                answer++;
        }
        
        return answer;
    }
}

```

시간복잡도 : O(n^2)  
기준이 되는 skill 값과 skill_trees를 for문으로 반복하면서 문자열의 문자를 하나하나 비교하는 방법이라 조금 비효율적인 것 같습니다.  
개선할 방법이 있을지는 조금 더 생각을 해봐야..ㅠ


<br />

# 찾아라 프로그래밍 마에스터 - 게임 맵 최단거리
https://programmers.co.kr/learn/courses/30/lessons/1844


```Java
class Solution {
    public int[] hor = {-1,1,0,0}; //좌, 우, 상, 하
    public int[] ver = {0,0,-1,1}; //좌, 우, 상, 하
    public int min = Integer.MAX_VALUE;
    public boolean endFlag = false;
    
    public int solution(int[][] maps) {
        //int answer = 0;
        
        // 배열 복사
        // for(int i=0; i<course.length; i++) {
        //     for(int j=0; j<course[0].length; j++) {
        //         System.out.print(course[i][j] + " ");
        //     }
        //     System.out.println();
        // }
        
        // 0,0에서 탐험 시작
        explore(maps, new int[] {0,0}, 0);
        
        if(endFlag == false) {
            return -1;
        }
        
        return min;
    }
    
    public void explore(int[][] course, int[] pos, int dist) {
        course[pos[0]][pos[1]] = 0; //지나갔다고 표시
        dist++; //이동거리 +1
        
        // System.out.println("현재 위치 : " + pos[0] + ", " + pos[1] + "/ 현재 거리 : " + dist);
        
        for(int i=0; i<4; i++) {
            if(pos[0] + ver[i] >= 0 && pos[0] + ver[i] < course.length) {
                if(pos[1] + hor[i] >= 0 && pos[1] + hor[i] < course[0].length) {
                    if(course [pos[0] + ver[i]] [pos[1] + hor[i]] == 1) {
                        explore(course, new int[] {pos[0] + ver[i], pos[1] + hor[i]}, dist);
                    }
                }
            }
        }
        
        if(pos[0] == course.length-1 && pos[1] == course[0].length-1) {
            if(dist < min) {
                min = dist;
            }
            endFlag = true;
        }
        
        return;
    }
    
}
```

정확성 36.1
효율성 0

예제케이스는 정답인데, 실제로 돌려보면 풀이가 틀렸습니다.  
어디에서 틀렸는지 테스트 케이스를 추가로 더 확인해봐야 할 것 같습니다.


