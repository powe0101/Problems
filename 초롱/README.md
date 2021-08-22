# Leetcode 1. Two Sum -> JAVA 사용
# https://leetcode.com/submissions/detail/542304708/
# 시간복잡도 : O(n)

# 시간복잡도 순위 2등

class Solution {
    public int[] twoSum(int[] nums, int target) {
        /*
        maybe creating a hashmap which contains element as key and indices as value can solve it?        
        */
        
        HashMap <Integer, Integer> map = new HashMap<>();
        // for storing indices
        int[] StoreIndex = new int[2];
        
        // inserting it on HashMap
        for (int i=0; i < nums.length; i++)
        {
            if (map.containsKey(target - nums[i]))
            {
                StoreIndex[1] = i;
                StoreIndex[0] = map.get(target - nums[i]);
                return StoreIndex;
            }
            map.put(nums[i], i);
            
        }
        return nums;
    }
}

# 시간복잡도 순위 1등

class Solution {
    public int[] twoSum(int[] nums, int target) {
        
         int[] arr = new int[2];
        
        for (int i = 1; i < nums.length; i++) {
            
            for (int j = i; j < nums.length; j++) {
                
                if (nums[j] + nums[j - i] == target) {
                    
                    arr[0] = j - i;
                    arr[1] = j;
                    
                    return arr;   
                }
            }
        }
        
        return arr;
    }
}
