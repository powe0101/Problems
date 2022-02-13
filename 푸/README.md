```c++
class Solution {
public:
    int findLength(vector<int>& nums1, vector<int>& nums2) 
    {
        int result = 0;
        
        vector<vector<int>> list(nums1.size()+1, vector<int>(nums2.size()+1, 0));
        for(int i = nums1.size()-1; i >= 0; --i)
        {
            for(int j = nums2.size()-1; j >= 0; --j)
            {
                if(nums1[i] == nums2[j])
                {
                    list[i][j] = list[i+1][j+1] + 1;
                    if(result < list[i][j])
                        result = list[i][j];
                }
            }
        }
        
        return result;
    }
};
```

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
    bool isSameTree(TreeNode* p, TreeNode* q) 
    {

        if(p == nullptr && q == nullptr) return true;
        
        if(q == nullptr || p == nullptr) return false;
        
        if(p->val != q->val) return false;
        
        return isSameTree(p->right, q->right) && isSameTree(p->left, q->left);
    }
};
```

```c++
class Solution {
public:
    pair<pair<int,int>,int> pop_front(queue<pair<pair<int,int>,int>>& maps)
    {
        auto temp = maps.front();
        maps.pop();
        return temp;
    }

    int minPathSum(vector<vector<int>>& grid) 
    {
        int result = 0;
        const int height = grid.size();
        const int width = grid[0].size();
        
        queue<pair<pair<int,int>,int>> list;
        
        list.push(pair<pair<int,int>,int>(pair<int,int>(0,0),grid[0][0]));
        
        while(list.empty() == false)
        {
            int size = list.size();
            
            for(int i = 0; i < size; ++i)
            {
                const auto temp = pop_front(list);
                const auto x = temp.first.second;
                const auto y = temp.first.first;
                const auto sum = temp.second;
                
                if(x == grid.size() && y == grid[0].size())
                {
                    result = min(result, sum);
                    continue;
                }
                
                if(x+1 < width)
                    list.push(pair<pair<int,int>,int>(pair<int,int>(y,x+1), grid[y][x+1]));
                if(x-1 > -1)
                    list.push(pair<pair<int,int>,int>(pair<int,int>(y,x+1), grid[y][x-1]));
                if(y+1 < height)
                    list.push(pair<pair<int,int>,int>(pair<int,int>(y,x+1), grid[y+1][x]));
                if(y-1 > -1)
                    list.push(pair<pair<int,int>,int>(pair<int,int>(y,x+1), grid[y-1][x]));
            }
        }
        
        return result;
    }
};
```
