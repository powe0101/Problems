https://programmers.co.kr/learn/courses/30/lessons/42586?language=csharp

```C#
using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(int[] progresses, int[] speeds) {
        
			var issues = new Queue<Issue>();

			for (int i = 0; i < progresses.Length; i++)
			{
				issues.Enqueue(new Issue(progresses[i], speeds[i]));
			}
			var days = 1;

			var result = new List<int>();

			do
			{
				var doneCount = 0;

				while (issues.Count != 0)
				{
					var peek = issues.Peek();

                    //작업완료 확인
					if (peek.IsDone(days))
					{
						doneCount++;
						issues.Dequeue();
					}
					else//작업이 완료되지 않았다면 날 추가
					{
						days++;
						
						break;
					}
				}

				if (doneCount != 0)
				{
					result.Add(doneCount);
				}
			} while (issues.Count != 0);

			return result.ToArray();
    }
    
    class Issue
	{
		public Issue(int progress, int speed)
		{
			Progress = progress;
			Speed = speed;
		}

		public int Progress { get; set; }
		public int Speed { get; set; }

		internal bool IsDone(int days)
		{
			if ((days * Speed + Progress) >= 100)
			{
				return true;
			}

			return false;
		}
	}
}
```

시간복잡도 : N
