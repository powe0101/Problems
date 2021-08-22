```cs
using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(int[] answers) {
            List<int> li = new List<int>();

            int[] first = { 1, 2, 3, 4, 5 };
            int[] second = { 2, 1, 2, 3, 2, 4, 2, 5 };
            int[] third = { 3, 3, 1, 1, 2, 2, 4, 4, 5, 5 };

            int[] score = { 0, 0, 0 };

            for (var i = 0; i < answers.Length; i++)
            {
                if (answers[i] == first[i % first.Length])
                    score[0]++;
                if (answers[i] == second[i % second.Length])
                    score[1]++;
                if (answers[i] == third[i % third.Length])
                    score[2]++;
            }

            int[] arr = new int[score.Length];
            for (int i = 0; i < score.Length; i++)
            {
                arr[i] = score[i];
            }

            Array.Sort(arr);

            for (int i = 0; i < arr.Length; i++)
            {
                if (score[i] == arr[2])
                {
                    li.Add(i + 1);
                }
            }

            int[] answer = new int[li.Count];
            for (int i = 0; i < li.Count; i++)
            {
                answer[i] = li[i];
            }

            return answer;
    }
}
```
