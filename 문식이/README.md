```cs
public class Solution {
    public int Search(int[] nums, int target) {
        for (var i = 0; i < nums.Length; i++)
        {
          if (nums[i] == target)
          {
            return i;
          }
        }
        return -1;
    }
}
```
