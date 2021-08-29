## \19. Remove Nth Node From End of List 

O(N)

```c++
  class Solution {
 public:
     ListNode* removeNthFromEnd(ListNode* head, int n) {
         auto cur = head;
         int size = 0;
         while (cur != nullptr) {
             size++;
             cur = cur->next;
         }
         
         int removeIdx = size - n;
         ListNode* prev = nullptr;
         ListNode* answer = nullptr;
         cur = head;
         while (cur != nullptr) {
             if (removeIdx == 0) {
                 if (prev != nullptr) {
                    prev->next = cur->next;
                 }
             }
             else if (answer == nullptr) {
                 answer = cur;
             }
             prev = cur;
             cur = cur->next;
             removeIdx--;
         }

         return answer;
     }
 };
```



## [Problem - 1559D1 - Codeforces](https://codeforces.com/problemset/problem/1559/D1)

[Submission #126681654 - Codeforces](https://codeforces.com/contest/1559/submission/126681654)

O(N^2)