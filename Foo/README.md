```c++
class Solution {
public:
    string decodeString(string s) {
        stack<string> stringList;
        stack<int> numberList;
        
        string number = "";
        string str = "";
        
        int pos = 0;
        while(pos < s.size())
        {
            auto ch = s[pos];
            if(isdigit(ch))
                number += ch;
            else if(ch == '[')
            {
                numberList.push(stoi(number));
                stringList.push(str);
                
                number = "";
                str = "";
            }
           else if(ch ==']')
           {
               string temp = stringList.top(); stringList.pop();
               int loop = numberList.top(); numberList.pop();
               for(int i = 0; i < loop; ++i)
               {
                   temp.append(str);
               }
               str = temp;
           }
           else
           {
                str += (s[pos]);
           }
           pos += 1;
        }
        
        return str;
    }
};
```
```python3
class Solution:
    def decodeString(self, s: str) -> str:
        while "[" in s:
            s = re.sub(r"(\d+)\[([a-z]*)\]", lambda m: m.group(2)*int(m.group(1)),s) 
            
        return s


```
