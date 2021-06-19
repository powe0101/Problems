# LeetCode - 11. Container With Most Water

https://leetcode.com/problems/container-with-most-water/submissions/  
  
가장 많은 물을 담을 수 있는 수직선을 골라 그 값을 구하는 문제

```Java
class Solution {
    public int maxArea(int[] height) {

/* 
이중 for문을 이용해 완전탐색으로 푸는 방법
간단하지만 시간복잡도가 O(n^2)이라 시간초과남.
*/

//         int len = height.length;
//         int max = 0;
        
//         for(int i=0; i<len-1; i++) {
//             for(int j=i+1; j<len; j++) {
//                 if(height[i] > height[j]) {
//                     if((j-i) * height[j] > max)
//                         max = (j-i) * height[j];
//                 } else {
//                     if((j-i) * height[i] > max)
//                         max = (j-i) * height[i];
//                 }
//             }
//         }
        
//         return max;

/* 
문제에 있는 Discuss 게시판의 이중 포인터를 이용하라는 조언을 이용한 코드
현재 l, r에서 max값을 계산하고, 좌우측 수직선 중 낮은 선의 위치를 하나씩 안쪽으로 옮겨가면서 최댓값을 계산한다.
*/
        int l=0, r=height.length-1;
        int max = 0;
        
        while(l < r) {
            int lowHeight = height[l] > height[r] ? height[r] : height[l];
            
            max = max > ( lowHeight * (r-l) ) ? max : ( lowHeight * (r-l) );
            
            if(height[l] > height[r]) {
                r--;
            } else {
                l++;
            }
        }
        
        return max;
    }
}

```

시간복잡도 : O(n)
가장 많은 물을 담을 수 있는 경우가 주어진 수직선들 중 한 가운데에 있는 수직선에서 나온다면 O(n)이다.  
<br />

# LeetCode - 921. Minimum Add to Make Parentheses Valid

https://leetcode.com/problems/minimum-add-to-make-parentheses-valid/  
  
주어진 문자열의 괄호를 올바르게 닫을 수 있도록(= 괄호가 모두 짝이 맞도록) 만드려면 추가로 몇 개의 괄호가 필요한가?
괄호의 종류 '(', ')' 및 위치는 상관하지 않는다.

```Java
class Solution {
    public int minAddToMakeValid(String s) {
        
        int len = s.length();
        int l=0, r=0;
        char prev = ' ';
        
        for(int i=0; i<len; i++) {
            if(s.charAt(i) == ')') {
                r++;
                if(prev == '(') {
                    l--;
                    r--;
                    if(l == 0)
                        prev = ' ';
                }
            }
            else {
                l++;
                prev = '(';
            }
        }
        
        return l + r;
    }
}
```

시간복잡도 : O(n)
주어진 문자열의 괄호 개수를 모두 파악해야 하므로 O(n)