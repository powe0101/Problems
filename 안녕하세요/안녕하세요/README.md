N으로 표현

```c++
#include <string> // O(number * N * N)
#include <vector>
#include <algorithm>
using namespace std;
const int LAST_NUMBER = 32000;
int solution(int N, int number) {
	int current = N;
	vector<vector<int>> numbers(9, vector<int>());
	numbers[1].push_back(current);
    
    // N
	for (int count = 2; count <= 8; count++) {
		current = current * 10 + N;        
		numbers[count].push_back(current);
        // N
		for (int remainCount = 1; remainCount <= count / 2; remainCount++) {
			for (int left : numbers[remainCount]) { // numbers
				for (int right : numbers[count - remainCount]) {
					if (left + right < LAST_NUMBER)
						numbers[count].push_back(left + right);
					if (left - right > 0)
						numbers[count].push_back(left - right);
					if (left * right < LAST_NUMBER)
						numbers[count].push_back(left * right);
					if (left / right > 0)
						numbers[count].push_back(left / right);
				}
			}
		}
		for (int number : numbers[count - 1]) {
			if (number + N < LAST_NUMBER)
				numbers[count].push_back(number + N);
			if (number - N > 0)
				numbers[count].push_back(number - N);
			if (number * N < LAST_NUMBER)
				numbers[count].push_back(number * N);
			if (number / N > 0)
				numbers[count].push_back(number / N);
		}
	}

	for (int count = 1; count <= 8; count++) {
		auto i = find(numbers[count].begin(), numbers[count].end(), number);
		if (i != numbers[count].end()) {
			return count;
		}
	}

	return -1;
}
```





거리두기 확인하기

https://programmers.co.kr/learn/courses/30/lessons/81302

```c++
#include <string> // O(N^2)
#include <vector>
#include <queue>
using namespace std;

int dir[][2] = { {1,0},{-1,0},{0,1},{0,-1} };

struct Coordinate {
    int r;
    int c;
    int d;
    Coordinate(int r, int c, int d) : r(r), d(d), c(c) {}
};

bool isSafety(vector<string>& place, int row, int col, bool visit[][5]) {
    queue<Coordinate> q;
    q.push(Coordinate(row, col, 0));
    visit[row][col] = 1;
    while (!q.empty()) {
        Coordinate cur = q.front();
        q.pop();
        for (int i = 0; i < 4; i++) {
            int nr = dir[i][0] + cur.r;
            int nc = dir[i][1] + cur.c;

            if (nr < 0 || nc < 0 || nr >= 5 || nc >= 5) continue;
            if (place[nr][nc] == 'X') continue;
            if (visit[nr][nc]) continue;
            if (cur.d + 1 <= 2 && place[nr][nc] == 'P') {
                return false;
            }
            visit[nr][nc] = 1;
            if (place[nr][nc] == 'P') {
                q.push(Coordinate(nr, nc, 0));
            }
            else {
                q.push(Coordinate(nr, nc, cur.d + 1));
            }
        }
    }
    return true;
}


vector<int> solution(vector<vector<string>> places) {
    vector<int> answer;
    int size = places.size();
    int test = 0;
    while (test < size) {
        int rows = places[test].size();
        int cols = places[test][0].size();

        int safety = 1;
        bool visit[5][5] = { 0 };
        for (int i = 0; i < rows && safety; i++) {
            for (int j = 0; j < cols && safety; j++) {
                if (places[test][i][j] == 'P'
                    && !visit[i][j]
                    && !isSafety(places[test], i, j, visit)) {
                    safety = 0;
                };
            }
        }

        answer.push_back(safety);

        test++;
    }
    return answer;
}
```





```c++
#include <string> // O(N^2)
#include <vector>
#include <queue>
using namespace std;

int dir[][2] = { {1,0},{-1,0},{0,1},{0,-1} };

vector<int> solution(vector<vector<string>> places) {
	vector<int> answer;
	int size = places.size();
	int test = 0;
	while (test < size) {
		int rows = places[test].size();
		int cols = places[test][0].size();
		vector<string>& place = places[test];
		int safety = 1;
		bool visit[5][5] = { 0 };
		for (int i = 0; i < rows && safety; i++) {
			for (int j = 0; j < cols && safety; j++) {
				if (places[test][i][j] == 'P') {
					for (int k = 0; k < 4; k++) {
						int nr = dir[k][0] + i;
						int nc = dir[k][1] + j;
						if (nr < 0 || nc < 0 || nr >= 5 || nc >= 5) {
							continue;
						}

						if (place[nr][nc] == 'P') {
							safety = 0;
							break;
						}

						if (place[nr][nc] == 'O') {
							if (visit[nr][nc]) {
								safety = 0;
								break;
							}
							visit[nr][nc] = 1;
						}
					}
				};
			}
		}

		answer.push_back(safety);

		test++;
	}
	return answer;
}
```