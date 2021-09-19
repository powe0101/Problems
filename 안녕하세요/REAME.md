```c++
#include <string>
#include <vector>
#include <algorithm>
using namespace std;

vector<int> solution(int brown, int yellow) {
    vector<int> answer;
    vector<int> yellowDivisors;
    for(int i =1; i<=yellow; i++) {
        if (yellow % i == 0) {
            yellowDivisors.push_back(i);
        }
    }
    // 가로가 넒음
    for(int i = 0;i< yellowDivisors.size();i++) {
        int width = yellowDivisors[i];
        int height = yellow / yellowDivisors[i];
        
        if (width < height) {
            swap(width, height);
        }
        
        int need = width * 2 + height * 2 + 4;
        if (brown == need) {
            answer.push_back(width + 2);
            answer.push_back(height + 2);
            break;
        }
        
    }
    return answer;
}
```



복서 정렬하기 https://programmers.co.kr/learn/courses/30/lessons/85002

```c++
#include <string>
#include <vector>
#include <algorithm>
using namespace std;

// 승률 순 정렬 ( 승률 내림, 자기보다 몸무게가 큰 이긴 횟수, 몸무게 내림, 작은 번호 오름)

struct Head2Head {
    int play;
    int winner;
    int winnerVsWeight;
    int weight;
    int number;
    float getWinnerRate() const {
        return play == 0 ? 0 : winner / (float)play;
    }
    Head2Head(int winner = 0, int winnerVsWeight = 0, int wiehgt = 0, int  number = 0)
        : winner(winner), winnerVsWeight(winnerVsWeight), weight(wiehgt), number(number) {
        play = 0;
    }
    bool operator<(Head2Head& other) {
        float winnerRate = getWinnerRate();
        float otherWinnerRate = other.getWinnerRate();
        if (winnerRate == otherWinnerRate) {
            if (winnerVsWeight == other.winnerVsWeight) {
                if (weight == other.weight) {
                    return number < other.number;
                }
                return weight > other.weight;
            }
            return winnerVsWeight > other.winnerVsWeight;
        }
        return winnerRate > otherWinnerRate;
    }
};

vector<int> solution(vector<int> weights, vector<string> head2head) {
    vector<int> answer;
    vector<Head2Head> players;
    for (int i = 0; i < head2head.size(); i++) {
        Head2Head player(0, 0, weights[i], i + 1);
        for (int j = 0; j < weights.size(); j++) {
            if (i == j || head2head[i][j] == 'N') continue;
            player.play++;
            if (head2head[i][j] == 'W') {
                player.winner++;
                if (weights[i] < weights[j]) {
                    player.winnerVsWeight++;
                }
            }
        }
        players.push_back(player);
    }
    sort(players.begin(), players.end());
    for (const auto& player : players) {
        answer.push_back(player.number);
    }
    return answer;
}
```

