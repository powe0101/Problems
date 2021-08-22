# Problems

https://programmers.co.kr/learn/courses/30/lessons/83201

``` C#
using System;
using System.Text;
using System.Collections.Generic;

public class Solution
{
	public string solution(int[,] scores)
	{
		var size = scores.GetLength(0);
		var sb = new StringBuilder();

		for (int i = 0; i < size; i++)
		{
			var min = int.MaxValue;
			var max = int.MinValue;
			var sum = 0;

			var dict = new Dictionary<int, int>();

			for (int j = 0; j < size; j++)
			{
				var value = scores[j, i];
				sum += value;

				if (dict.TryGetValue(value, out var valueCount))
				{
					dict[value]++;
				}
				else
				{
					dict.Add(value, 1);
				}

				if (value > max)
				{
					max = value;
				}

				if (value < min)
				{
					min = value;
				}
			}

			var myValue = scores[i, i];

			if ((myValue == min || myValue == max) && dict[myValue] == 1)
			{
				sb.Append(GetGrade((sum - myValue) / (size - 1)));
			}
			else
			{
				sb.Append(GetGrade(sum / size));
			}
		}

		return sb.ToString();
	}
	private char GetGrade(int v)
	{
		if (v >= 90)
		{
			return 'A';
		}
		else if (v >= 80)
		{
			return 'B';
		}
		else if (v >= 70)
		{
			return 'C';
		}
		else if (v >= 50)
		{
			return 'D';
		}
		else
		{
			return 'F';
		}
	}
}
```

https://leetcode.com/problems/integer-to-roman/

```
Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.

Symbol       Value
I             1
V             5
X             10
L             50
C             100
D             500
M             1000
For example, 2 is written as II in Roman numeral, just two one's added together. 12 is written as XII, which is simply X + II. The number 27 is written as XXVII, which is XX + V + II.

Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not IIII. Instead, the number four is written as IV. Because the one is before the five we subtract it making four. The same principle applies to the number nine, which is written as IX. There are six instances where subtraction is used:

I can be placed before V (5) and X (10) to make 4 and 9. 
X can be placed before L (50) and C (100) to make 40 and 90. 
C can be placed before D (500) and M (1000) to make 400 and 900.
Given an integer, convert it to a roman numeral.
```

``` C#

public class Solution
{
	public string IntToRoman(int num)
	{
		var dict = new Dictionary<int, char>();
		dict.Add(1, 'I');
		dict.Add(5, 'V');
		dict.Add(10, 'X');
		dict.Add(50, 'L');
		dict.Add(100, 'C');
		dict.Add(500, 'D');
		dict.Add(1000, 'M');

		var sb = new StringBuilder();

		for (int i = 1000; i > 0; i /= 10)
		{
			var value = num / i;

			if (value != 0)
			{
				if (value >= 1 && value < 4)
				{
					for (int j = 0; j < value; j++)
					{
						sb.Append(dict[i]);
					}
				}
				else if (value == 4)
				{
					sb.Append(dict[i]);
					sb.Append(dict[i * 10 / 2]);
				}
				else if (value == 5)
				{
					sb.Append(dict[i * 5]);
				}
				else if (value >= 6 && value < 9)
				{
					sb.Append(dict[i * 5]);
					for (int j = 0; j < value - 5; j++)
					{
						sb.Append(dict[i]);
					}
				}
				else
				{
					sb.Append(dict[i]);
					sb.Append(dict[i * 10]);
				}

				num = num % i;
			}
		}


		return sb.ToString();
	}
}
```