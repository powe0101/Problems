```c++
class Solution {
public:
    bool stoneGame(vector<int>& piles) 
    {
        auto result = false;
        
        vector<vector<int>> list(piles.size(), vector<int>(piles.size()));
        
        for(int i = 0; i < piles.size(); ++i)
        {
            list[i][i] = piles[i];
        }
        
        for(int i = 1; i < piles.size(); ++i)
        {
            for(int j = 0; j < piles.size()-i; ++j)
            {
                list[j][j+i] = max(piles[j] - list[j+1][j+i], piles[j+i] - list[j][j+i-1]);
            }
        }
        
        
        return list[0][piles.size()-1] > 0;
    }
};
```
