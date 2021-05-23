기능개발

```cs
using System.Collections.Generic;

public class Solution
{
    public int[] solution(int[] progresses, int[] speeds)
    {
        List<int> answer = new List<int>();
        int[] day = new int[progresses.Length]; // 작업일
        int count = 0; // 결과 값 카운트

        for (var i = 0; i < progresses.Length; i++)
        {
            day[i] = (100 - progresses[i]) / speeds[i]; // 속도 * 작업일 = 작업
            
            // progress 30 speed 30 일 경우 70이 남아서 3일을 해야하지만 나눗셈 때문에 2일 밖에 안뜬다.
            if ((day[i] * speeds[i]) < (100 - progresses[i])) 
            {
                day[i]++;
            }
        }
        
        int tmp = day[0]; // 비교용 변수
        
        for (var j = 0; j < day.Length; j++)
        {
            if (tmp >= day[j])
            {
                count++;
            }
            else
            {
                answer.Add(count);
                tmp = day[j];
                count = 1;
            }
        }
        answer.Add(count);
        
        return answer.ToArray();
    }
}
```

문자열 내 마음대로 정렬하기

```cs
using System;
using System.Linq;

public class Solution
{
    public string[] solution(string[] strings, int n)
    {
        string[] answer = new string[strings.Length];
        
        for (var i = 0; i < strings.Length; i++)
        {
            answer[i] = strings[i].Substring(n, 1) + strings[i];
            // answer[i] 의 n번째 글자를 맨 앞으로 땡긴다.
        }
        
        Array.Sort(answer);
        // 그 후 알파벳 순 정렬
        // nlogn, 최악의 경우는 n^2 (퀵소트)
        
        for (var j = 0; j < strings.Length; j++)
        {
            answer[j] = answer[j].Substring(1);
            // n번째 글자가 맨 앞에 있으므로 맨 앞 글자만 지우기
        }

        return answer;
    }
}
```
