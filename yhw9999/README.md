https://programmers.co.kr/learn/courses/30/lessons/49993

스킬트리
전탐색
```C#
using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
	public int solution(string skill, string[] skill_trees)
	{
		int answer = 0;

		foreach (var skill_tree in skill_trees)
		{
			var skillQueue = new Queue<char>(skill);
			var treeQueue = new Queue<char>(skill_tree);
            //순서가 보장되는 Queue로 스킬의 유효성의 체크
			if (CheckValidTree(skillQueue, treeQueue))
			{
				answer++;
			}
		}

		return answer;
	}

	private bool CheckValidTree(Queue<char> skillQueue, Queue<char> treeQueue)
	{
		while (treeQueue.Any())
		{
			var currentSkill = treeQueue.Dequeue();
            //Contains에서 성능을 빼먹음 개선이 가능할것같음
			if (skillQueue.Contains(currentSkill))
			{
				if (skillQueue.Peek() == currentSkill)
				{
					skillQueue.Dequeue();
				}
				else
				{
					return false;
				}
			}
		}

		return true;
	}
}
```
시간복잡도 : N

---

https://programmers.co.kr/learn/courses/30/lessons/1844

게임 맵 최단거리
BFS

```C#
using System;
using System.Collections.Generic;
class Solution
{

	int destX;
	int destY;

	int minCount = int.MaxValue;

	int[,] map;
	bool[,] visited;

	public int solution(int[,] maps)
	{
		var destXLength = maps.GetLength(1);
		var destYLength = maps.GetLength(0);
		map = maps;
		visited = new bool[destYLength, destXLength];

		destX = destXLength - 1;
		destY = destYLength - 1;

		var queue = new Queue<Position>();

		var start = new Position(0, 0, 1);
		Visit(start);

		Find(start, queue);

		return minCount == int.MaxValue ? -1 : minCount;
	}

	private void Find(Position pos, Queue<Position> queue)
	{
        //TODO : 노드에 도착했을 때의 이동거리를 확인해서 더 이상 연산을 하지않게하면 성능 개선을 할 수 있을 것 같음.
		if (pos.x == destX && pos.y == destY)
		{
			if (pos.dist < minCount)
			{
				minCount = pos.dist;
			}

			return;
		}

		EnqueueNear(queue, pos);

		while (queue.Count > 0)
		{
			var nextPos = queue.Dequeue();

			Find(nextPos, queue);
		}
	}

	private void EnqueueNear(Queue<Position> stack, Position pos)
	{
		var left = pos.Left;
		var right = pos.Right;
		var top = pos.Top;
		var bottom = pos.Bottom;

		if (IsValid(left))
		{
			Visit(left);
			stack.Enqueue(left);
		}

		if (IsValid(right))
		{
			Visit(right);
			stack.Enqueue(right);
		}

		if (IsValid(top))
		{
			Visit(top);
			stack.Enqueue(top);
		}

		if (IsValid(bottom))
		{
			Visit(bottom);
			stack.Enqueue(bottom);
		}
	}

	private void Visit(Position pos)
	{
		visited[pos.y, pos.x] = true;
	}

	private bool IsValid(Position pos)
	{
		if (pos.x < 0 || pos.x > destX || pos.y < 0 || pos.y > destY)
		{
			return false;
		}

		if (map[pos.y, pos.x] == 1 && visited[pos.y, pos.x] == false)
		{
			return true;
		}

		return false;
	}

	struct Position
	{
		public int x;
		public int y;
		public int dist;

		public Position(int x, int y, int dist)
		{
			this.x = x;
			this.y = y;
			this.dist = dist;
		}

		public Position Left { get { return new Position(x - 1, y, this.dist + 1); } }
		public Position Right { get { return new Position(x + 1, y, this.dist + 1); } }
		public Position Top { get { return new Position(x, y - 1, this.dist + 1); } }
		public Position Bottom { get { return new Position(x, y + 1, this.dist + 1); } }
	}
}
```
시간복잡도 : V + E
V = 노드개수, E는 간선의 개수