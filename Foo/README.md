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
