https://leetcode.com/problems/powx-n/
```c++
class Solution {
public:
    double myPow(double x, int n) 
    {
        if(n == 0)
            return 1.0;
        
        double result = x;

        int count = abs(n) - 1;
        
        while(count)
        {
            if(count & 1)
                result *= x;
            count >>= 1;
            x *= x;
        }
        
        if(n < 0)
            return 1.0 / result;
        
        return result;
    }
};
```

https://leetcode.com/problems/baseball-game/
```c++
class Solution {
public:
    int calPoints(vector<string>& ops) {
        
        vector<int> list;
        
        for(int i = 0; i < ops.size(); ++i)
        {
            string op = ops[i];
            if(isdigit(op[0]) || op[0] == '-')
            {
                list.push_back(stoi(op));
                continue;
            }
            
            switch(op[0])
            {
                case '+':
                    list.push_back(list[list.size()-1]+list[list.size()-2]);
                    break;
                case 'D':
                    list.push_back(list[list.size()-1]*2);
                    break;
                case 'C':
                    list.pop_back();
                    break;
            }
        }
        
        return accumulate(list.begin(),list.end(),0);
    }
};
```
