```c++
/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     ListNode *next;
 *     ListNode() : val(0), next(nullptr) {}
 *     ListNode(int x) : val(x), next(nullptr) {}
 *     ListNode(int x, ListNode *next) : val(x), next(next) {}
 * };
 */
class Solution {
public:
    ListNode* removeNthFromEnd(ListNode* head, int n) {
        
        auto temp = new ListNode(-1, head);
        
        auto front = temp;
        auto back = temp;
        
        for(int i = 0; i < n; ++i)
            front = front->next;
        
        while(front->next != nullptr)
        {
            front = front->next;
            back = back->next;
        }
        
        back->next = back->next->next;
        
        return temp->next;
    }
};
```


