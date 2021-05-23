기능개발

```cs
using System.Collections.Generic;

public class Solution
{
    public int[] solution(int[] progresses, int[] speeds)
    {
        List<int> answer = new List<int>();
        int[] day = new int[progresses.Length];
        int count = 0;

        for (var i = 0; i < progresses.Length; i++)
        {
            day[i] = (100 - progresses[i]) / speeds[i];

            if ((day[i] * speeds[i]) < (100 - progresses[i]))
            {
                day[i]++;
            }
        }
        int tmp = day[0];
        for (var j = 0; j < day.Length; j++)
        {
            if (tmp >= day[j])
            {
                count++;
                continue;
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
            answer[i] = strings[i][n] + strings[i];
        }
        Array.Sort(answer);
        
        for (var j = 0; j < strings.Length; j++)
        {
            answer[j] = answer[j].Substring(1);
        }

        return answer;
    }
}
```
