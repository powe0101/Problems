https://programmers.co.kr/learn/courses/30/lessons/49993

스킬 트리

```c#

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Solution
{
    /*
        CBD
        "BACDE": B 스킬을 배우기 전에 C 스킬을 먼저 배워야 합니다. 불가능한 스킬트립니다.
        "CBADF": 가능한 스킬트리입니다.
        "AECB": 가능한 스킬트리입니다.
        "BDA": B 스킬을 배우기 전에 C 스킬을 먼저 배워야 합니다. 불가능한 스킬트리입니다.
     */

    public int solution(string skill, string[] skill_trees)
    {
        var word = new string[skill.Length];
        var list = new List<string>();

        // 스킬 순서를 숫자로 치환함
        for (int i = 0; i < skill.Length; i++)
        {
            word[i] = skill.Substring(i, 1);
        }

        // 치환된 숫자로 스킬 트리에 해당하는 스킬을 숫자로 변경함
        for (int i = 0; i < skill_trees.Length; i++)
        {
            var target = skill_trees[i];

            for (int j = 0; j < word.Length; j++)
            {
                target = target.Replace(word[j], j.ToString());
            }

            list.Add(target);
        }

        var answer = 0;

        for (int i = 0; i < list.Count; i++)
        {
            // 변환된 스킬 트리 문자열에 선행 스킬 트리만 남김 : 정규식을 사용하여 숫자만 남김
            var skillTree = Regex.Replace(list[i], @"\D", "");

            /*
                "BACDE": B 스킬을 배우기 전에 C 스킬을 먼저 배워야 합니다. 불가능한 스킬트립니다.
                => 1A02E
                => 102
                "CBADF": 가능한 스킬트리입니다.
                => 01A2F
                => 012
            */
            
            var check = false;

            // 선행 스킬 트리에 해당하는 스킬이 존재하지 않음
            if (skillTree.Length == 0 && list[i].Length > 0) 
            {
                check = true;
            }
            // 선행 스킬 트리에 해당하는 스킬이 존재함
            else
            {
                // 선행 스킬 트리에 해당하는 스킬이 1개임
                if (skillTree.Length == 1 && skillTree.IndexOf("0") == 0)
                {
                    check = true;
                }
                else
                {
                    // 선행 스킬 트리에 첫번째 스킬이 존재하지 않음
                    if (skillTree.IndexOf("0") != -1)
                    {
                        // 순차적으로 선행 스킬 트리의 순서를 비교함
                        for (int j = 0; j < skillTree.Length; j++)
                        {
                            // 다음 스킬이 존재하는 경우
                            if (skillTree.Length > j + 1)
                            {
                                // 다음 스킬과 순서가 이상하지 않는다면
                                if (skillTree.IndexOf(j.ToString()) < skillTree.IndexOf((j + 1).ToString()))
                                {
                                    check = true;
                                }
                                else
                                {
                                    check = false;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            if (check)
            {
                answer++;
            }
        }

        return answer;
    }
}
```

시간복잡도 : O(n²)