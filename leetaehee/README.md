# LeetCode - 19. Remove Nth Node From End of List

https://leetcode.com/problems/remove-nth-node-from-end-of-list/
  
노드 리스트의 뒤에서 N번째 노드를 삭제하기

```Java
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     int val;
 *     ListNode next;
 *     ListNode() {}
 *     ListNode(int val) { this.val = val; }
 *     ListNode(int val, ListNode next) { this.val = val; this.next = next; }
 * }
 */
class Solution {
    public ListNode removeNthFromEnd(ListNode head, int n) {
        
        ListNode a, b;
        a = head;   //앞서가는 포인터
        b = head;   //뒤에 있는 포인터
        int pos = 0;

        //현재 위치가 주어진 n보다 작다면 계속 다음칸으로 넘어간다
        while(true) {
            if(pos < n) {
                a = a.next;
                pos++;
            }
            else
                break;
        }
        
        if(a == null)
            return head.next;
        
        while(a.next != null) {
            a = a.next;
            b = b.next;
        }
        
        b.next = b.next.next;
        return head;
    }
}

```

시간복잡도 : O(N)
모든 노드를 1회만 탐색하기 때문에 O(N) 안에 끝낼 수 있다.  
<br />