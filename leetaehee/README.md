# 깊이/너비 우선 탐색(DFS/BFS) - 네트워크

https://programmers.co.kr/learn/courses/30/lessons/43162


```Java
class Solution {
    int answer = 0;
    boolean[] visit;
    
    public int solution(int n, int[][] computers) {
        visit = new boolean[n];
        
        // n개의 노드 각각을 출발점으로 삼아서 dfs를 실행해본다.
        for(int i=0; i<n; i++) {
            if(visit[i] == false) { // 이미 방문한 노드면 패스!
                dfs(n, computers, i);
                answer++;
            }
        }

        return answer;
    }
    
    public void dfs(int n, int[][] computers, int idx) {
        visit[idx] = true;  // 우선 현재 노드를 방문 처리한다.
        for(int i=0; i<computers[idx].length; i++) {  // 현재 노드에서 연결된 노드가 있나 확인해본다.
            if(i != idx && computers[idx][i] == 1 && visit[i] == false) { // 현재 방문한 노드가 아니고, 다른 노드와 연결되어 있고, 방문하지 않았다면 그 노드로 dfs 실행
                dfs(n, computers, i);
            }
        }
    }
}

```

시간복잡도 : O(n^2)
n개의 노드에 대해 n번의 반복을 진행하므로 시간 복잡도는 n^2이라고 생각한다.


<br />

# LeetCode - Sum of Unique Elements

https://leetcode.com/problems/sum-of-unique-elements/


```Java
import java.util.ArrayList;


class Solution {
    public int sumOfUnique(int[] nums) {
        int[] list = new int[101];  // 미리 배열을 101개 생성해준다. 숫자 계산 편하게 101개 생성
        int sum = 0;
        
        for(int i=0; i<nums.length; i++) {  // 숫자를 index로 삼아서, 해당 숫자의 배열값을 +1 증가
            list[nums[i]]++;
        }
        
        for(int i=1; i<list.length; i++) {  // 배열 원소의 값이 1인 경우만 카운트!
            if(list[i] == 1)
                sum += i;
        }
        
        return sum;
    }
}
```

시간복잡도 : O(n)  
해시맵을 이용해서 중복되는 숫자를 걸러내려고 했는데, 이 소스보다 시간이 더 많이 소요되는 문제가 있었음.