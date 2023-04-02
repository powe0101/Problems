```cpp
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
  
public:
    TreeNode* pruneTree(TreeNode* root) 
    {
        if(root == NULL)
            return root;
        
        root->left = pruneTree(root->left);
        root->right = pruneTree(root->right);
            
        if(!root->left && !root->right && root->val == 0)
            return NULL;
            
        return root;
    }
};
```

`cpp
class Solution {
    vector<int> nums;
    vector<int> c_nums;
public:
    Solution(vector<int>& temp) {
        nums = temp;
        c_nums = temp;
    }
    
    vector<int> reset() {
        return nums;
    }
    
    vector<int> shuffle() 
    {
        next_permutation(c_nums.begin(),c_nums.end());
        return c_nums;
    }
};

/**
 * Your Solution object will be instantiated and called as such:
 * Solution* obj = new Solution(nums);
 * vector<int> param_1 = obj->reset();
 * vector<int> param_2 = obj->shuffle();
 */
  ```
