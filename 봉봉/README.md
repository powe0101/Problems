using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmHub
{
    public class Solution
    {

        public string[] solution(string[] strings, int n)
        {

            string[] answer = strings.OrderBy(x => x).ToArray(); // linq OrderBy로 알파벳 순서대로 Sort 후 Array로 만들기

            answer = answer.OrderBy(x => x[n]).ToArray(); // 만든 Array에서 다시 OrderBy로 n번째 문자로 Sort하기

            return answer;
        }
    }
}

