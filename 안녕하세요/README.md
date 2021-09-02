## 33. Search in Rotated Sorted Array

풀이 (비번: tmxjel) 영어로 스터디

[33. Search in Rotated Sorted Array — 기록 (tistory.com)](https://printfhello.tistory.com/61?category=861864)

```c++
class Solution {
private:
    int getPivot(vector<int> &nums) {
        int l = 0, r = nums.size() - 1, mid, pivot = 0;
        while (l<=r) {
            mid = (l + r) / 2;
            if (mid > 0 && nums[mid-1] > nums[mid]) {
                break;
            }
            if (nums[mid] > nums[r]) {
                l = mid + 1;
            } else {
                r = mid - 1;
            }
        }
        return mid;
    }
    
    int getIdx(vector<int> &nums, int start, int size, int target) {
        int mid, l = start, r = start + size - 1;
        int answer = -1;
        while (l<=r) {
            mid = (l+r)/2;
            if (nums[mid] == target) {
                answer = mid;
                break;
            } else if (nums[mid] > target) {
                r = mid - 1;
            } else {
                l = mid + 1;
            }
        }
        return answer;
    }
public:
    int search(vector<int>& nums, int target) {
        int answer = -1;
        int pivot = this->getPivot(nums);
        answer = getIdx(nums, 0, pivot, target);
        if (answer == -1) {
            answer = getIdx(nums, pivot, nums.size() - pivot, target);
        }
        return answer;
    }
};
```



## D. Solve The Maze

풀이 (비번: tmxjel) 영어로 스터디

[D. Solve The Maze — 기록 (tistory.com)](https://printfhello.tistory.com/60?category=861864)

Code: https://codeforces.com/contest/1365/submission/127569502 

