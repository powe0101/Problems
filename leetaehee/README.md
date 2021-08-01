# LeetCode - 62. Unique Paths

https://leetcode.com/problems/unique-paths/
  
오른쪽, 아래쪽으로만 이동할 수 있는 2차원 맵에서 유일한 경로의 개수를 찾는 문제

```Java
class Solution {
    int result = 0;
    int width, height;
    
    public int uniquePaths(int m, int n) {
        width = n;
        height = m;
        
        explore(0, 0);
        
        return result;
    }
    public void explore(int x, int y) {
        if(height-1 > x) { //세로
            explore(x+1, y);
        }
        if(width-1 > y) { //가로
            explore(x, y+1);
        }
        
        if(x == height-1 && y == width-1) {
            result++;
            return;
        }
    }
}

```

시간복잡도 : O(???)
m * n 크기의 맵이 주어졌을 때, m * n = N이라고 하면 경로를 찾는 매 탐색마다 2개의 분기로 나뉜다.
그러면 모든 경로를 탐색하는 시간은 2^N이 될 것 같은데.. 어떻게 시간복잡도를 계산할지 헷갈린다.
재귀 호출의 시간복잡도를 구하는게 조금 어려운 관계로 이번건은 추후 수정해야 할 것 같다.

<br />


# LeetCode - 3. Longest Substring Without Repeating Characters

https://leetcode.com/problems/longest-substring-without-repeating-characters/
  
주어진 문자열에서 중복된 문자가 없는 가장 긴 문자열의 찾는 문제

```Java
class Solution {
    public int lengthOfLongestSubstring(String s) {
		int max = 0;
		int len = s.length();
		
		if(len == 0) return 0;
		
		for(int i=0; i<len; i++) {
			//비교할 문자열
			for(int j=i+1; j<len; j++) {
				//비교할 문자
				String temp = s.substring(i, j);
				String c = s.substring(j, j+1);
				int tempLen = temp.length();
				
				if(temp.contains(c)) {
					break;
				}
				else {
					max = max > tempLen ? max : tempLen;
				}
			}
		}

		return max+1;
    }
}

```

시간복잡도 : O(N^2)
java에서 substring 메소드는 O(N)의 시간 복잡도를 가진다.
그리고 소스코드에는 2중 for문을 사용했다. 밖의 for문은 n만큼 돌고, 안의 for문은 도는 횟수가 매번 1씩 줄어든다.
그렇다면 최악의 경우, 즉 찾고자 하는 문자열이 가장 뒤에 있는 케이스에서는 처음엔 n-1번 for문이 돌고 마지막에는 1번 돌게된다.
그럼 실제로 도는 (N^2) / 2이 될 것 같은데, 시간복잡도에서 차수만 고려하므로 O(N^2)이 될 것 같다. 

<br />
