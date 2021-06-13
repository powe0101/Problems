릿코드 - Sum of Unique Elements

```cs
public class Solution {
    public int SumOfUnique(int[] nums)
    {
            int count = 0;
            int sum = 0;

            for (var i = 0; i < nums.Length; i++)
            {
                count = 0;
                for (var j = 0; j < nums.Length; j++)
                {
                    if (nums[i] == nums[j])
                        count++;
                }

                if (count == 1)
                {
                    sum += nums[i];
                }            
            }

            return sum;
    }
}
```
