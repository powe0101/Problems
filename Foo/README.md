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
