# LeetCode - 1382. Balance a Binary Search Tree

https://leetcode.com/problems/balance-a-binary-search-tree/
  
이진트리를 밸런스이진트리로 만드는 문제

```Java
import java.util.*;

public class TreeNode {
    int val;
    TreeNode left;
    TreeNode right;
    TreeNode() {}
    TreeNode(int val) { this.val = val; }
    TreeNode(int val, TreeNode left, TreeNode right) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

class Solution {
    TreeNode root; 

    ArrayList<Integer> arr = new ArrayList<Integer>();
    ArrayList<String> result = new ArrayList<String>();
    
    public TreeNode balanceBST(TreeNode param) {
        inOrder(param, 1);
        makeTree();
        inOrder(root, 2);
    
        return root;
    }
    public void inOrder(TreeNode node, int mode) {
        if(node != null) {
            if(mode == 2)
                result.add(Integer.toString(node.val));
            
            //왼쪽 노드 방문
            if(node.left != null) {
                if(mode == 2)
                    result.add(Integer.toString(node.val));
                inOrder(node.left, mode);
            }
            else {
                if(mode == 2)
                    result.add("null");
            }
            
            //값을 배열에 넣는다.
            if(mode == 1)
                arr.add(node.val);
           esult.add();
            
            
            //오른쪽 노드 방문
            if(node.right != null) {
                if(mode == 2)
                    result.add(Integer.toString(node.val));
                inOrder(node.right, mode);
            }
            else {
                if(mode == 2)
                    result.add("null");
            }
        }
        
    }
    
    public void makeTree() {
        root = makeSubTree(0, arr.size()-1);
    }
    
    public TreeNode makeSubTree(int start, int end) {
        if(start > end) return null;
        int mid = (start + end) / 2;
        TreeNode node = new TreeNode(arr.get(mid));
        node.left = makeSubTree(start, mid-1);
        node.right = makeSubTree(mid+1, end);
        
        return node;
    }
}

```

시간복잡도 : O(n^2)
ArrayList의 Add 메소드의 시간복잡도는 O(n)이고, n개의 노드가 있다고 가정할 때 O(n^2)이 될 것 같다.
<br />

# 프로그래머스 - 탐욕법 - 조이스틱

https://programmers.co.kr/learn/courses/30/lessons/42860
  
조이스틱으로 알파벳 이름을 완성하기.
A로 구성된 문자열에서 최소한의 움직임으로 주어진 문자열을 만들어야 함.

```Java
class Solution {
    public int solution(String name) {
        int answer = 0;
        // int before = 0, after = 0;
        int len = name.length();
        int min = len - 1;
        int aCnt = 0;
        
        for(int i=0; i<len; i++) {
            // A가 아닌 문자를 바꿀 때 발생하는 조작 횟수 계산
            char c = name.charAt(i);
            
            int diff = 0;
            if(c-'A' < 'Z'-c)
                diff = c-'A';
            else
                diff = 'Z'-c+1;
            
            answer += diff;
            
            for(int j=i+1; j<len; j++) {
                c = name.charAt(j);
                if(c != 'A') {
                    break;
                }
                else {
                    int temp = (i*2) + len - (j+1);
                    min = min < temp ? min : temp;
                }
            }
        }      
        return answer+min;
    }
}
```

시간복잡도 : O(n^2)
이중 for문이 맨 처음 실행될 때 n * (n-1)번 실행되므로 O(n^2)