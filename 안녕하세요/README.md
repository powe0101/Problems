## [입국심사](https://programmers.co.kr/learn/courses/30/lessons/43238)

```c++
#include <string>
#include <vector>

using namespace std;

long long solution(int n, vector<int> times) {
    long long answer = 0;
    long long left = 0, right = 1000000000ll * 1000000000ll, mid;
    while (left <= right) {
        mid = (left + right) / 2;
        long long tasks = 0;
        for (int time : times) {
            tasks += (mid / time);
        }
        if (tasks >= n) {
            answer = mid;
            right = mid - 1;
        }
        else {
            left = mid + 1;
        }
    }
    return answer;
}
```



## [상호 평가](https://programmers.co.kr/learn/courses/30/lessons/83201)

```c++
#include <string>
#include <vector>
#include <algorithm>
#include <map>
#include <numeric>
using namespace std;

char getGradeByScore(double score) {
    if (score >= 90) {
        return 'A';
    }
    if (score >= 80) {
        return 'B';
    }
    if (score >= 70) {
        return 'C';
    }
    if (score >= 50) {
        return 'D';
    }
    return 'F';
}
vector<vector<int>> getStudentGradeTable(vector<vector<int>>& scores)
{
    int count = scores.size();
    vector<vector<int>> students(scores.size(), vector<int>());
    for (int i = 0; i < count; i++) {
        for (int j = 0; j < count; j++) {
            students[i].push_back(scores[j][i]);
        }
    }
    return students;
}
string solution(vector<vector<int>> scores) {
    string answer = "";
    int studentCount = scores.size();
    auto students = getStudentGradeTable(scores);
    for (int i = 0; i < studentCount; i++) {
        auto& student = students[i];
        map<int, int> grades;
        for (int grade : student) {
            grades[grade]++;
        }
        auto maxGrade = *max_element(grades.begin(), grades.end());
        auto minGrade = *min_element(grades.begin(), grades.end());
        if ((maxGrade.second == 1 && student[i] == maxGrade.first) ||
            (minGrade.second == 1 && student[i] == minGrade.first)) {
            student.erase(student.begin() + i);
        }
        int total = accumulate(student.begin(), student.end(), 0);
        double grade = (total * 1.0) / student.size();
        answer.push_back(getGradeByScore(grade));
    }
    return answer;
}
```

