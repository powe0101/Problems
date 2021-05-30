스킬트리
```cs
using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int solution(string skill, string[] skill_trees) {
            int answer = 0;
            bool chk = true;

            foreach (var str in skill_trees)
            {
                List<char> strList = str.ToCharArray().ToList(); // FindIndex를 위해 리스트화

                chk = true; // 반복문 돌 때마다 true로 초기화
                for (var i = 0; i < skill.Length - 1; i++) // -1 하는 이유는 배열 오류가 나서
                {
                    int pIndex = strList.FindIndex(x => x.Equals(skill[i])); // 이전스킬
                    int nIndex = strList.FindIndex(x => x.Equals(skill[i + 1])); // 다음스킬
                    
                    // 다음스킬 존재
                    if (nIndex >= 0)
                    {
                        // 이전스킬이 다음스킬 후에 온다 || 이전스킬이 없다.
                        if (pIndex > nIndex || pIndex < 0)
                        {
                            chk = false;
                            break;
                        }
                    }                    
                }
                if (chk)
                {
                    answer++;
                }
            }

            return answer;
    }
}
```
시간복잡도 : O(C^N)?
