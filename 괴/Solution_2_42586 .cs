// https://programmers.co.kr/learn/courses/30/lessons/42586
// 기능개발

using System;
using System.Collections.Generic;

public class Solution
{
    // 배포 마다 몇 개의 기능이 배포 되는지 반환
    public int[] solution(int[] progresses, int[] speeds)
    {
        int[] workDays = new int[progresses.Length];

        // 각 progresses 별 작업일수를 구함
        for (int i = 0; i < progresses.Length; i++)
        {
            var progress = progresses[i];
            var speed = speeds[i];

            var leftProgress = 100 - progress;

            float calculateDay = (float)leftProgress / speed;

            // 계산된 작업일수의 소수점 올림
            var workDay = (int)Math.Ceiling(calculateDay);

            workDays[i] = workDay;
        }

        var count = 0;
        var currentWork = workDays[0]; //첫번째 기능 작업일수
        var workDayList = new List<int>();

        // 작업 일 수로 배포 개수 계산
        for (int i = 1; i < workDays.Length; i++)
        {
            var nextWork = workDays[i]; //두번째 기능 이후 작업일수

            if (currentWork >= nextWork)
            {
                // 이전 작업일수 보다 작은 작업일수라면 이전 작업일수 배포에 포함됨
                count++;
            }
            else
            {
                // 이전 작업일수 보다 큰 작업일수라면 이전 작업일수 배포에 포함되지 않음 => 배포 처리
                workDayList.Add(count + 1);
                currentWork = workDays[i];
                count = 0;
            }
        }

        workDayList.Add(count + 1); // 마지막 배포 처리

        var answer = workDayList.ToArray();

        return answer;
    }
}