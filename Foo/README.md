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
```c++
class Solution {
public:
    int jump(vector<int>& nums) 
    {
        if(nums.size() == 1)
            return 0;
        
        int result = 1;///점프를 먼저 한번 했다고 가정하고 들어감.
       
        int maxJump = nums[0];
        int pos = nums[0];
        //초기화
        
        //cout << maxJump << " " << pos << endl;
        for(int i = 1; i < nums.size()-1; ++i)
        {
            maxJump = max(maxJump, nums[i] + i); //현재 점프 크기 와 다음 스텝 크기 비교
            pos -= 1;
            if(pos == 0) //pos가 0이되면 다음 포문에서 돌릴수 없는데, 이때는 점프를 해야함을 의미
            {
                result += 1; //점프 
                pos = maxJump - i; //최대값에서 i를 빼면 업데이트 된것.
                //cout << result << endl;
            }
            //cout << i << " " << maxJump << " " << pos << endl;
        }
        
        //cout << endl;
        
        return result;
    }
};
```
