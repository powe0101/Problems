```cpp
#include <bits/stdc++.h>

using namespace std;
//https://codingdojang.com/scode/458?orderby=time&langby=cpp
string convertion(long long num,long long notation){
    string res = "";
    long long mok = num;
    long long nmg = 0ll;
    
    while(mok >= notation){
        nmg = mok % notation;
        mok /= notation;
        
        // 10진법보다 크고 나머지가 10 이상인 경우
        if(notation > 10 && nmg >= 10){
            res = (char)(nmg+55) + res;
        }else{
            res = to_string(nmg) + res;
        }
    }
    
    if(notation > 10 && mok >= 10){
        res = (char)(mok+55) + res;
    }else{
        res = to_string(mok) + res;
    }
    
    return res;
}

//https://notepad96.tistory.com/54
bool checkPrime(int num) {
	if (num < 2) return false;
	int a = (int) sqrt(num);
	for (int i = 2; i <= a; i++) if (num % i == 0) return false;
	return true;
}

int solution(int n, int k) {
    int answer = 0;
    
    string number = convertion(n, k);
    string temp = "";
    for(int i = 0; i < number.size(); ++i)
    {
        if(temp.size() > 0 && number[i] == '0')
        {
            bool isPrime = checkPrime(stoi(temp));
            if(isPrime == true)
                answer += 1;
            temp = "";
        }
        else{
            temp += number[i];
        }
    }
    
    if(checkPrime(stoi(temp)) == true)
       answer += 1;
    
    return answer;
}
```
