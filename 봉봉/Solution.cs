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

            string[] answer = strings.OrderBy(x => x).ToArray();

            answer = answer.OrderBy(x => x[n]).ToArray();

            return answer;
        }
    }
}
