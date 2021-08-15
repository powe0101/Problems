# LeetCode - 70. Climbing Stairs

https://leetcode.com/problems/climbing-stairs/
  
N개의 계단을 1, 2개씩 오를 경우 N번째 계단에 도착하는 서로 다른 방법의 개수찾기

```Java
class Solution {
    public int climbStairs(int n) {
        int temp=0,a=1,b=2;
        
        if(n == 1)
            return 1;
        else if(n == 2)
            return 2;
        
        for(int i=3; i<=n; i++) {
            temp = b;
            b = a+b;
            a = temp;
        }
        
        return b;
    }
}

```

시간복잡도 : O(N)
계단을 오르는 방법을 하나하나 찾다보면 N번째에 도착하는 서로 다른 방법의 개수가 피보나치 수열을 동일함을 발견할 수 있다.
피보나치 수열은 현 위치의 값이 2번째 전의 값과 1번째 전의 값을 더하여 구한다.
이 방법을 이용해 계산하면 시간복잡도는 O(N)이 나온다.

Runtime: 0 ms, faster than 100.00% of Java online submissions for Climbing Stairs.
Memory Usage: 36.1 MB, less than 15.86% of Java online submissions for Climbing Stairs.

<br />


# 프로그래머스 - 완전탐색 - 모의고사

https://programmers.co.kr/learn/courses/30/lessons/42840
  
1번 수포자가 찍는 방식: 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, ...
2번 수포자가 찍는 방식: 2, 1, 2, 3, 2, 4, 2, 5, 2, 1, 2, 3, 2, 4, 2, 5, ...
3번 수포자가 찍는 방식: 3, 3, 1, 1, 2, 2, 4, 4, 5, 5, 3, 3, 1, 1, 2, 2, 4, 4, 5, 5, ...

1번 문제부터 마지막 문제까지의 정답이 순서대로 들은 배열 answers가 주어졌을 때, 가장 많은 문제를 맞힌 사람이 누구인지 반환하기.
많이 맞힌 사람이 여러명이면 오름차순으로 정렬하기.

```Java
import java.util.*;

class Solution {
    public int[] solution(int[] answers) {
        // ArrayList<Integer> answer = new ArrayList<>();  //정답 많이 맞힌 순서대로 정렬
        int[] answer = {};
        int anscnt1=0, anscnt2=0, anscnt3=0;
        int[] anscnt = new int[3];
        int anslen = answers.length;
        
        int[] anspt1 = {1,2,3,4,5};
        int[] anspt2 = {2,1,2,3,2,4,2,5};
        int[] anspt3 = {3,3,1,1,2,2,4,4,5,5};
        
        int ansptn1 = anspt1.length;
        int ansptn2 = anspt2.length;
        int ansptn3 = anspt3.length;
        // System.out.println(ansptn1 +", "+ ansptn2 +", "+ ansptn3);
        
        for(int i = 0; i < anslen; i++) {
            if(answers[i] == anspt1[i%ansptn1])
                anscnt[0] += 1;
        }
        for(int i = 0; i < anslen; i++) {
            if(answers[i] == anspt2[i%ansptn2])
                anscnt[1] += 1;
        }
        for(int i = 0; i < anslen; i++) {
            if(answers[i] == anspt3[i%ansptn3])
                anscnt[2] += 1;
        }
        // System.out.println(anscnt[0] +", "+ anscnt[1] +", "+ anscnt[2]);
        
        //가장 높은 점수 구하기
        int max = 0;
        for (int i = 0; i < 3; i++) {
            if(anscnt[i] > max)
                max = anscnt[i];
        }
        // System.out.println(max);
        
        //가장 높은 점수를 똑같이 받은 사람이 몇명인지 숫자 세기
        int maxcnt = 0;
        for (int i = 0; i < 3; i++) {
            if(anscnt[i] == max)
                maxcnt++;
        }
        //System.out.println("동점자 : " + maxcnt);
        
        answer = new int[maxcnt];
        int j = 0;
        for (int i = 0; i < 3; i++) {
            if(anscnt[i] == max) {
                //System.out.println("i : "+ i+", anscnt[i] : " + anscnt[i]);
                answer[j++] = i+1;
                //System.out.println("answer[j] : " + answer[j]);               
            }
        }
        
        return answer;
    }
}

```

시간복잡도 : O(N)
파라미터 answers의 길이만큼 3번 for문이 도는 부분이 있어 3N 이상이지만, 상수는 무시하므로 O(N)이다.

<br />
