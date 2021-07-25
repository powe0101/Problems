```c++
/**
 * Definition for a binary tree node.
 * struct TreeNode {
 *     int val;
 *     TreeNode *left;
 *     TreeNode *right;
 *     TreeNode() : val(0), left(nullptr), right(nullptr) {}
 *     TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
 *     TreeNode(int x, TreeNode *left, TreeNode *right) : val(x), left(left), right(right) {}
 * };
 */
class Solution {
public:
    bool isSubtree(TreeNode* root, TreeNode* subRoot) 
    {
        if(subRoot == nullptr)
            return false;

        return subTree(root, subRoot);
    }
      
    bool subTree(TreeNode* t1, TreeNode* t2)
    {
        if(t1 == nullptr)
            return false;
        //데이터를 비교하고 현재 값이 같으면 서브트리 구조가 일치하는지 한번 더 비교.
        else if(t1->val == t2->val && matchTree(t1, t2) == true)
            return true;
        
        //값이 하지 않으면 왼쪽, 오른쪽 순으로 다시 데이터 비교
        return subTree(t1->left, t2) || subTree(t1->right, t2);
    }
    
    bool matchTree(TreeNode* t1, TreeNode* t2)
    {
        if(t1 == nullptr && t2 == nullptr)
            return true;
        else if(t1 == nullptr || t2 == nullptr)
            return false;
        else if(t1->val != t2->val)
            return false;
        else
            return matchTree(t1->left, t2->left) && matchTree(t1->right, t2->right);
    }
};
```
