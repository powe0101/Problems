deepest leaves sum
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
    int result = 0;

    int depthHelper(TreeNode* root) 
    {
      if(root == nullptr) 
        return 0;

      return max(depthHelper(root->left) + 1, depthHelper(root->right) + 1);
    }

    void search(TreeNode* root, int deep, const int deepest)
    {
        if(root == nullptr)
            return;

        if(deep == deepest)
            result += root->val;
            
        search(root->left, deep + 1, deepest);
        search(root->right, deep + 1, deepest);
    }

public:
    int deepestLeavesSum(TreeNode* root) 
    {
        int deepest = depthHelper(root);

        search(root, 1, deepest);
        return result;
    }
};
```

안전지대 
```c++
#include <bits/stdc++.h>

using namespace std;

int solution(vector<vector<int>> board) 
{
    int answer = 0;
    
    const int width = board.size();
    const int height = board[0].size();
    
    for(int i = 0; i < board.size(); ++i)
    {
        for(int j = 0; j < board[i].size(); ++j)
        {
            int target = board[i][j];
            
            if(target == 1) // mine
            {
                if(i+1 < width && board[i+1][j] != 1)
                    board[i+1][j] = 2;
                if(i-1 > -1 && board[i-1][j] != 1)
                    board[i-1][j] = 2;
                if(j+1 < height && board[i][j+1] != 1)
                    board[i][j+1] = 2;
                if(j-1 > -1 && board[i][j-1] != 1)
                    board[i][j-1] = 2;
                
                if(i+1 < width && j+1 < height && board[i+1][j+1] != 1)
                    board[i+1][j+1] = 2;
                if(i-1 > -1 && j-1 > -1 && board[i-1][j-1] != 1)
                    board[i-1][j-1] = 2;
                
                if(i+1 < width && j-1 > -1 && board[i+1][j-1] != 1)
                    board[i+1][j-1] = 2;
                if(i-1 > -1 && j+1 <height && board[i-1][j+1] != 1)
                    board[i-1][j+1] = 2;
            }
        }
    }
    
    for(int i = 0; i < board.size(); ++i)
    {
        for(int j = 0; j < board[i].size(); ++j)
        {
            if(board[i][j] == 0)
                answer += 1;
        }
    }
    
    return answer;
}

```
