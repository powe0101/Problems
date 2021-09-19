```c++
#include <bits/stdc++.h>

using namespace std;


vector<int> solution(int brown, int yellow) {
    vector<int> answer;
    
    int size = brown + yellow;
    
    for (int i = 1; i <= size; i++)
    {
        int x = 0, y = 0;
		if (size % i == 0)
		{
			x = i;
            y = size / i;
            if(x >= y)
            {
                int center = (x-2) * (y-2);
                if(center == yellow){
                    answer.push_back(x);
                    answer.push_back(y);
                }
            }
		}
    }
    
	//sort(answer.begin(), answer.end());
    
    
    
    return answer;
}
```

