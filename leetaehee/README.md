# LeetCode - 572. Subtree of Another Tree

https://leetcode.com/problems/subtree-of-another-tree/
  
주어진 이진트리에 찾고자하는 서브트리가 존재하는지 확인하는 문제.

```Java
class Solution {
    public boolean isSubtree(TreeNode root, TreeNode subRoot) {
        // 문제에서 제시한 root가 null이면 비교할게 없으므로 false
        if(root == null)
            return false;

        /* root가 null이 아니면 일단 서브트리가 있는지 확인해본다.
        check 함수가 true를 반환하면 return true 실행
        */
        else if(check(root, subRoot))
            return true;

        /* check 함수가 false를 반환하면 아래 else문 실행
        else문이 실행된다는건 root의 시작점에서 봤을 때 subRoot와 동일한 트리가 없다는 뜻
        */
        else
            return isSubtree(root.left, subRoot) || isSubtree(root.right, subRoot);
    }
    
    public boolean check(TreeNode r, TreeNode s) {
        /* 둘 다 null이 아니면 false
        한쪽만 null이면 비교할 수 없으니 false
        둘 다 null이면 둘이 똑같은거니까 true
        */
        if(r == null || s == null)
            return r == null && s == null;
        /* 노드의 값이 같으면 양쪽 자식 값을 확인해봐야 함 */
        else if(r.val == s.val)
            return check(r.left, s.left) && check(r.right, s.right);
        /* 노드의 값이 다르면 비교할 필요 없으니까 false */
        else
            return false;
    }
}

```

시간복잡도 : O(n)
최악의 경우가 모든 노드가 값이 동일하고, 비교 대상인 subTree의 노드가 1개인 케이스라고 생각했다.
이럴 경우 모든 노드를 다 탐색한 다음 마지막 가장 맨 아래 높이의 노드에서 subTree랑 동일한 노드를 찾을 수 있다.
다른 최악 케이스를 더 생각해봐야 할 것 같다
<br />
