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
private:
    void search(TreeNode* node, int val)
    {
        if(node == nullptr)
            return;

        if(node->val < val)
        {
            if(node->right != nullptr)
                search(node->right, val);
            else
                node->right = new TreeNode(val);
        }
        else
        {
            if(node->left != nullptr)
                search(node->left, val);
            else
                node->left = new TreeNode(val);
        }
    }

public:
    TreeNode* insertIntoBST(TreeNode* root, int val) 
    {
        if(root == nullptr)
            return new TreeNode(val);

        auto node = root;
        search(node, val);
        return root;
    }
};
```

