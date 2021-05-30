# 연습문제 - 문자열 내 마음대로 정렬하기
https://programmers.co.kr/learn/courses/30/lessons/12915


```Java
import java.util.*;

class Solution {
    public String[] solution(String[] strings, int n) {
        Arrays.sort(strings, new Comparator<String>() {
            @Override
            public int compare(String s1, String s2) {
                char c1 = s1.charAt(n);
                char c2 = s2.charAt(n);
                
                if(c1 == c2) {
                    return s1.compareTo(s2);
                } else return c1 - c2;
            }
        });
        
        return strings;
    }
}
```

시간복잡도 : O(n log n)  

Arrays.sort()의 시간복잡도는 검색을 통해 알아봤습니다.  
>Dual-Pivot Quicksort로 구현되어 있으며, 모든 데이터 타입에서 O(n log n)의 시간 복잡도를 제공한다.  
>시간복잡도 관련 참고 : https://girawhale.tistory.com/105

파라미터로 받은 strings를 정렬하기 위해 Comparator를 구현했습니다.  
~~Arrays.sort 메소드를 이용해보았는데 그냥 직접 짜는 것보다 더 복잡해진 것 같은건 느낌탓일거에요.~~  

-----------------------------------------

#스택/큐 - 기능개발
https://programmers.co.kr/learn/courses/30/lessons/42586


```Java
package com.company;

import java.util.Queue;
import java.util.LinkedList;

public class Main {

    public static void main(String[] args) {
        Solution sol = new Solution();
        int[] progresses = new int[] {93, 30, 55};
        int[] speeds = new int[] {1, 30, 5};
        int[] answer = sol.solution(progresses, speeds);
        for(int i=0; i<answer.length; i++) {
            System.out.print(answer[i] + ", ");
        }
        System.out.println();

        progresses = new int[] {95, 90, 99, 99, 80, 99};
        speeds = new int[] {1, 1, 1, 1, 1, 1};
        answer = sol.solution(progresses, speeds);
        for(int i=0; i<answer.length; i++) {
            System.out.print(answer[i] + ", ");
        }
    }

    static class Solution {
        public int[] solution(int[] progresses, int[] speeds) {
            int[] remains = new int[progresses.length]; // 기능별 개발이 필요한 일수
            int funcNum = 0;  // 하루에 배포할 기능개수
            int max = 0;
            Queue<Integer> q = new LinkedList<>();
            boolean flag = false;   // 마지막 배포일자의 기능개수를 큐에 넣기 위한 플래그

            // 기능별로 남은 잔여개발일수를 구한다.
            for(int i=0; i<progresses.length; i++) {
                if((100 - progresses[i]) % speeds[i] == 0)
                    remains[i] = (100 - progresses[i]) / speeds[i];
                else
                    remains[i] = (100 - progresses[i]) / speeds[i] + 1;
            }

            // 잔여개발일수 배열을 계산하여 배포일별 기능건수를 계산한다
            for(int i = 0; i < remains.length; i++) {
                // 잔여개발일 수 중 큰 값을 찾기 위해 max와 비교한다.
                if(max < remains[i]) {
                    if(max != 0) {
                        max = remains[i];
                        q.add(funcNum);
                        funcNum = 1;
                    } else {
                        max = remains[i];
                        funcNum = 1;
                    }
                    flag = true;
                } else {
                    funcNum++;
                    flag = false;
                }
            }

            if(flag == true || funcNum >= 1)
                q.add(funcNum);

            Object[] retArr = q.toArray();
            int length = retArr.length;
            int[] intRetArr = new int[length];
            for (int i = 0; i < length; i++) {
                intRetArr[i] = (int) retArr[i];
            }

            return intRetArr;
        }
    }
}
```

시간복잡도 : O(n)  
중첩하여 도는 for문이 없어서 n이라고 생각합니다.

각 기능별 잔여개발일을 미리 계산해놓고, 잔여개발일의 국소 최댓값(local maximum) 값을 찾아 배포일별 기능 숫자를 계산하는 방식입니다.


