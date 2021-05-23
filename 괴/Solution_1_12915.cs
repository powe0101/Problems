// https://programmers.co.kr/learn/courses/30/lessons/12915
// 문자열 내 마음대로 정렬하기

using System.Collections.Generic;

public class Solution
{
    public string[] solution(string[] strings, int n)
    {
        var lstWord = new List<string>();

        string[] answer = new string[strings.Length];

        // 기준 문자열 구하기
        foreach (var word in strings)
        {
            lstWord.Add(word.Substring(n, 1) + word);
        }

        // 기준 문자열 정렬
        lstWord.Sort();

        // 기준 문자열에 따른 결과물 생성
        for (int i = 0; i < lstWord.Count; i++)
        {
            foreach (var word in strings)
            {
                if (lstWord[i].Substring(1) == word)
                {
                    answer[i] = word;

                    break;
                }
            }
        }

        return answer;
    }
}