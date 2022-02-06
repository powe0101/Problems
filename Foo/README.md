https://leetcode.com/problems/median-of-two-sorted-arrays
```c++
class Solution {
public:
    double findMedianSortedArrays(vector<int>& nums1, vector<int>& nums2) {
        double result = 0.0;
        vector <int> list;
        for(int i = 0; i < nums1.size(); ++i)
        {
            list.push_back(nums1[i]);
        }
        
        for(int i = 0; i < nums2.size(); ++i)
        {
            list.push_back(nums2[i]);
        }
        
        sort(list.begin(),list.end());
        
        if(list.size() % 2 == 0)
        {
            double temp1 = list[list.size()/2];
            double temp2 = list[list.size()/2-1];
            result = ((temp1 + temp2) / 2);
        }
        else
        {
            result = list[list.size()/2];
        }
        
        
        
        return result;
    }
};
```
https://leetcode.com/problems/remove-nth-node-from-end-of-list
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
        
        auto temp = new ListNode(-1, head); //insert
        
        auto front = temp; //iterator 1
        auto back = temp; //iterator 2
        
        for(int i = 0; i < n; ++i)
            front = front->next; //
        
        while(front->next != nullptr)
        {
            front = front->next;
            back = back->next;
        }
        
        back->next = back->next->next;
        
        return temp->next;
    }
};
