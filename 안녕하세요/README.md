문자열 내맘대로 정렬하기

```c#
using System;

public class Solution {
    public string[] solution(string[] strings, int n) {
        string[] answer = new string[strings.Length];
        Array.Copy(strings, answer, strings.Length);
        Array.Sort(answer, (string a, string b) => {
                if (a[n] == b[n])
                {
                    return a.CompareTo(b);
                }
                return a[n] < b[n] ? -1 : 1; 
        });
        return answer;
    }
}
```

시간복잡도

- **O(nlogn)**

관련내용

- https://printfhello.tistory.com/57 (비번 스터디)

<hr />

기능개발

```c#
public int[] solution(int[] progresses, int[] speeds) {
    const int FINISH_PROGRESS = 100;
    var result = new List<int>();
    var task = new LinkedList<(int progress, int speed)>();
    for(var i=0;i<progresses.Length;i++) // O(N)
    {
        task.AddLast((progresses[i], speeds[i]));
    }
    while(task.Count != 0) // while() -> O(cN), task.Count -> O(1)
    {
        var size = task.Count;
        var finishTask = 0;
        var stop = false;
        while(size-- > 0) // O(N)
        {
            var front = task.First();
            task.RemoveFirst();
            front.progress += front.speed;
            if (stop == false && front.progress >= FINISH_PROGRESS)
            {
                finishTask++;
            }
            else
            {
                stop = true;
                task.AddLast(front);
            }
        }
        if (finishTask > 0)
        {
            result.Add(finishTask);
        }
    }
    return result.ToArray();
}
```

시간복잡도

- **O(N + M*N^2) -> O(M*N^2)** ?