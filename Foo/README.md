https://leetcode.com/problems/island-perimeter
```c++
class Solution {
public:
    int islandPerimeter(vector<vector<int>>& grid) 
    {
        int result = 0;
        queue<pair<int,int>> list;
        for(int i = 0; i < grid.size(); ++i)
        {
            for(int j = 0; j < grid[i].size(); ++j)
            {
                int temp = grid[i][j];
                
                if(temp == 1){
                    list.push(make_pair(i,j));
                    break;
                }
            }
        }
        
        while(list.size() > 0)
        {
            int size = list.size();
            
            for(int i = 0; i < size; ++i)
            {
                auto pos = list.front(); list.pop();
                int line = 4;
                
                if(grid[pos.first][pos.second] == 0 || grid[pos.first][pos.second] == 2)
                    continue;
                
                grid[pos.first][pos.second] = 2;
                
                if(pos.second > 0 && grid[pos.first][pos.second-1] == 1)
                {
                    line -=1;
                    list.push(make_pair(pos.first, pos.second-1));
                }
                //상
                if(pos.second+1 < grid[0].size() && grid[pos.first][pos.second+1] == 1)
                {
                    line -=1;
                    list.push(make_pair(pos.first, pos.second+1));
                }
                //하
                if(pos.first > 0 && grid[pos.first-1][pos.second] == 1)
                {
                    line -=1;
                    list.push(make_pair(pos.first-1, pos.second));
                }
                //좌
                if(pos.first+1 < grid.size() && grid[pos.first+1][pos.second] == 1)
                {
                    line -= 1;
                    list.push(make_pair(pos.first+1, pos.second));
                }
                //우
                
                if(pos.first > 0 && grid[pos.first-1][pos.second] == 2)
                    line -= 1;
                if(pos.first+1 < grid.size() && grid[pos.first+1][pos.second] == 2)
                    line -= 1;
                if(pos.second > 0 && grid[pos.first][pos.second-1] == 2)
                    line -= 1;
                if(pos.second+1 < grid[0].size() && grid[pos.first][pos.second+1] == 2)
                    line -= 1;
                result += line;
            }
        }
        
        return result;
    }
};
```
