https://programmers.co.kr/learn/courses/30/lessons/42860

- 조이스틱

- 시간복잡도 O(N^2)
  - 우측 (N번), 좌측(N번) -> N^2, 좌측으로 이동하면 더이상 우측으로 이동X

```c#
using System;
using System.Text.RegularExpressions;

public class Solution
{
    private int answer = -1;
    private string target;
    private int GetMinClickCount(char alphabet)
    {
        var count = alphabet - 'A';
        return Math.Min(count, 'Z' - alphabet + 1);
    }

    private void run(string name, int count, int position, bool leftMoveOnly = false, bool useJumpToLast = false)
    {
        if (name == target)
        {
            if (answer == -1 || answer > count)
            {
                answer = count;
            }
            return;
        }
        if (position < 0 || position >= name.Length)
        {
            return;
        }

        var (next, charDistance) = GetNextString(name, position);
        if (next == target)
        {
            run(next, count + charDistance, position, leftMoveOnly);
            return;
        }
        if (leftMoveOnly == false)
        {
            run(next, count + charDistance + 1, position + 1, leftMoveOnly);
        }
        var nextPosition = position - 1;
        if (useJumpToLast == false && nextPosition == -1)
        {
            nextPosition = name.Length - 1;
            useJumpToLast = true;
        }
        run(next, count + charDistance + 1, nextPosition, true, useJumpToLast);
    }

    private (string, int) GetNextString(string name, int cur)
    {
        var count = 0;
        if (name[cur] != target[cur])
        {
            count = GetMinClickCount(target[cur]);
        }
        var temp = name.ToCharArray();
        temp[cur] = target[cur];
        var next = new string(temp);
        return (next, count);
    }

    public int solution(string name)
    {
        target = name;
        answer = -1;
        run(Regex.Replace(target, ".", "A"), 0, 0, false);
        return answer;
    }
}
```

