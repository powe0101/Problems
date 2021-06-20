
container-with-most-water
```c++
class Solution {
public:
    int maxArea(vector<int>& height) {
        int result = 0;
        
        int start = 0;
        int end = height.size()-1;
        
        while(start < end)
        {
            auto size = min(height[start],height[end]) * (end - start); 
            
            result = max(size,result);
            //cout << size << " " << start << " " << end << endl;
            
            if(height[start] < height[end])
                start += 1;
            else
                end -= 1;
        }
        
        //cout << endl;
        return result;
    }
};
```

minimum-add-to-make-parentheses-valid
```c++
class Solution {
public:
    int minAddToMakeValid(string s) 
    {
        int result = 0;
        int pos = -1;
        while((pos = s.find("()")) != string::npos)
        {
            s.erase(s.begin()+pos,s.begin()+pos+2);
        }
        result = s.size();
        return result;
    }
};
```
