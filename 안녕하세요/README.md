## 스킬 트리

- https://programmers.co.kr/learn/courses/30/lessons/49993

```c#
public bool isAvailableSkillTree(int[] level, string skill_tree)
{
    var currentLevel = 1;
    foreach (var skill in skill_tree)
    {
        if (level[skill] == currentLevel)
        {
            currentLevel++;
        } else if (level[skill] > currentLevel)
        {
            return false;
        }
    }
    return true;
}

public int solution(string skill, string[] skill_trees)
{
    int answer = 0;
    var level = new int[128];
    var currentLevel = 1;
    foreach (var name in skill)
    {
        level[name] = currentLevel++;
    }
    foreach (var skill_tree in skill_trees)
    {
        if (isAvailableSkillTree(level, skill_tree)) {
            answer++;
        }
    }
    return answer;
}
```

- 스킬 트리의 개수: M, 스킬트리의 길이: N -> 시간복잡도 O(MN)?

## 게임 맵 최단 거리

https://programmers.co.kr/learn/courses/30/lessons/1844

```C#
using System;
using System.Collections.Generic;

class Solution {
    readonly int[][] dirs = new int[4][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };

    public int solution(int[,] maps)
    {
        int answer = -1;

        // init
        var current = new Queue<(int row, int col, int dist)>();
        (int row, int col) size = (maps.GetLength(0), maps.GetLength(1));
        var visitCheck = new bool[size.row, size.col];

        current.Enqueue((0, 0, 1));
        while(current.Count != 0)
        {
            var (row, col, dist) = current.Dequeue();
            if (row == size.row -1 && col == size.col -1)
            {
                answer = dist;
                break;
            }
            foreach(var dir in dirs)
            {
                var (nextRow, nextCol) = (row + dir[0], col + dir[1]);
                if (nextCol < 0 || nextRow < 0 || nextRow >= size.row || nextCol >= size.col)
                {
                    continue;
                }
                if (maps[nextRow, nextCol] == 0)
                {
                    continue;
                }
                if (visitCheck[nextRow,nextCol])
                {
                    continue;
                }
                visitCheck[nextRow, nextCol] = true;
                current.Enqueue((nextRow, nextCol, dist + 1));
            }
        }


        return answer;
    }
}
```

- 시간복잡도 O(NM)?
  - 맵의 크기 N*M
  - 각 노드별 간선 E: 4
  - 각 노드별로 최대 4개의 노드가 연결되어 있어서 그래프에서 하나의 노드에서 연결되어 있는 노드를 리스트로 표현한 것으로 생각

