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
    ListNode* mergeNodes(ListNode* head) {
        ListNode* result = new ListNode(0);
        
        ListNode* seek = result;
        while(head->next != nullptr)
        {
            if(head->val == 0)
            {
                long long temp = 0;
                head = head->next;
                
                while(head->next != nullptr)
                {
                    if(head->val == 0)
                        break;
                    
                    temp += head->val;
                    head = head->next;
                    
                }
                
                auto node = new ListNode(temp);
                seek->next = node;
                seek = seek->next;
            }
        }
        return result->next;
    }
};

```

```python3
class Solution(object):
    def multiply(self, num1, num2):
        """
        :type num1: str
        :type num2: str
        :rtype: str
        """
        return str(int(num1)*int(num2))

```
