# 19. Remove Nth Node From End of List
https://leetcode.com/problems/remove-nth-node-from-end-of-list/

```python
class Solution:
    def removeNthFromEnd(self, head: Optional[ListNode], n: int) -> Optional[ListNode]:
        
        dummy = ListNode(0)
        dummy.next = head
        
        slow = fast = dummy
        
        # 처음부터 n까지 첫번째 커서를 이동
        for i in range(n):
            fast = fast.next
        
        # 끝까지 첫번째 커서를 이동 / 두번째 커서는 처음부터 따라서 이동함
        while fast.next != None:
            slow = slow.next
            fast = fast.next
        
        # 두번째 커서의 다음 노드를 제거
        slow.next = slow.next.next
        
        return dummy.next
```

# 1957. Delete Characters to Make Fancy String
https://leetcode.com/problems/delete-characters-to-make-fancy-string/

```python
class Solution:
    def makeFancyString(self, s: str) -> str:
        
        # 같은 알파벳의 반복 횟수
        check_count = 0
        before_char = ""
        
        # 새로운 문자열 = 반환 결과물
        new_str = ""
        
        for i in s:
            
            # 이전 알파벳과 확인하여 다른 경우
            if before_char != i:
                check_count = 0
                before_char = i
            else:
                check_count += 1
            
            # 반복 횟수를 확인하여 허용치까지 새로운 문자열에 추가
            if check_count < 2:
                new_str += i
        
        return new_str
```
