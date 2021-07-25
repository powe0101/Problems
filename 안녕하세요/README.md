문제: https://leetcode.com/problems/subtree-of-another-tree/submissions/

![트리 용어](http://ehpub.co.kr/wp-content/uploads/2016/06/2-110.png)

- 출처 : https://ehpub.co.kr/tag/%ED%8F%AC%ED%99%94%EC%9D%B4%EC%A7%84%ED%8A%B8%EB%A6%AC/
- 이진트리에서 배열로 표현할 때 (현재 노드 값을 index라 하고, 0부터 시작)
  - ![img](https://upload.wikimedia.org/wikipedia/commons/thumb/f/f7/Binary_tree.svg/150px-Binary_tree.svg.png)
    - 출처: https://en.wikipedia.org/wiki/Binary_tree
  - 높이는(균형 이진 트리 기준)
    - ![h=\lceil \log _{2}(l)\rceil +1=\lceil \log _{2}((n+1)/2)\rceil +1=\lceil \log _{2}(n+1)\rceil ](https://wikimedia.org/api/rest_v1/media/math/render/svg/0c2c3b8d442f7a10ba77ef6ddd5dc42f9a85c9ef)
  - 현재 노드에서 부모 노드는
    - tree[(index-1)/2] , 1부터 시작시 tree[index/2]
  - 현재 노드에서 자식 노드는
    - tree[index\*2 + 1], 1부터 시작시 tree[index\*2]
    - tree[index\*2 + 2], 1부터 시작시 tree[index\*2 + 1]

```c++
#define null 0
class Solution {
public:
    bool compare(TreeNode* root, TreeNode* subRoot) {
        if (root == null && subRoot == null) {
            return true;
        }
        if (root == null || subRoot == null) {
            return false;
        }
        if (root->val != subRoot->val) {
            return false;
        }
        return compare(root->left, subRoot->left) && compare(root->right, subRoot->right);
    }
    bool isSubtree(TreeNode* root, TreeNode* subRoot) {
        if (root == null) {
            return false;
        }
        if (compare(root, subRoot)) {
            return true;
        }
        return isSubtree(root->left, subRoot) || isSubtree(root->right, subRoot);
    }
};
```

재귀 순회이기 때문에 stack 자료구조를 이용하여 풀 수 있습니다.

```c++
class Solution {
public:
    bool compare(TreeNode* root, TreeNode* subRoot) {
        stack<pair<TreeNode*, TreeNode*>> st;
        st.push(make_pair(root, subRoot));
        while (!st.empty()) {
            auto top = st.top();
            auto a = top.first;
            auto b = top.second;
            st.pop();
            if (a == null && b == null) {
                continue;
            }
            else if (a == null || b == null) {
                return false;
            }
            else if (a->val != b->val) {
                return false;
            }
            else {
                st.push(make_pair(a->right, b->right)); // 역순으로 넣기 (이 문제는 순서 상관X)
                st.push(make_pair(a->left, b->left));
            }
        }
        return true;
    }
    bool isSubtree(TreeNode* root, TreeNode* subRoot) {
        stack<pair<TreeNode*, TreeNode*>> st;
        st.push(make_pair(root, subRoot));
        bool answer = false;
        while (!st.empty()) {
            auto top = st.top();
            auto a = top.first;
            auto b = top.second;
            st.pop();

            if (a == null) {
                answer |= false;
                continue;
            }
            if (compare(a, b)) {
                answer |= true;
                continue;
            }
            st.push(make_pair(a->right, b));
            st.push(make_pair(a->left, b));
        }
        return answer;
    }
};
```

위 코드는 재귀를 사용하지 않았지만 stack 생성, push, pop을 위한 시간이 소모됩니다.

이를 해결하기 위해 threa tree를 사용하는 방법이 있으나 제시된 문제에는 관련 멤버변수를 추가하기 어렵기때문에 이론만 간략히 하고 넘어가겠습니다.

![img](https://upload.wikimedia.org/wikipedia/commons/thumb/7/7a/Threaded_tree.svg/220px-Threaded_tree.svg.png)

출처: https://ko.wikipedia.org/wiki/%EC%8A%A4%EB%A0%88%EB%93%9C_%EC%9D%B4%EC%A7%84_%ED%8A%B8%EB%A6%AC (이중 스레드)

![스레드BT](https://media.geeksforgeeks.org/wp-content/cdn-uploads/gq/2014/07/threadedBT.png)

![threadedTraversal](https://media.geeksforgeeks.org/wp-content/cdn-uploads/gq/2014/07/threadedTraversal.png)

출처: https://www.geeksforgeeks.org/threaded-binary-tree/ (단일 스레드)

```c++
struct TreeNode {
    int val;
    bool rightThread;
    TreeNode *left;
    TreeNode *right;
};
 
class Solution {
    TreeNode* getLeftMost(TreeNode* cur) {
        if (cur == null) {
            return null;
        }
        while (cur->left != null) {
            cur = cur->left;
        }
        return cur;
    }
public:
    bool compare(TreeNode* root, TreeNode* subRoot) {
        root = getLeftMost(root);
        subRoot = getLeftMost(subRoot);

        while (root != null && subRoot != null) {
            if (root->val != subRoot->val) {
                return false;
            }
            if (root->rightThread != subRoot->rightThread) {
                return false;
            }
            if (root->rightThread) {
                root = root->right;
                subRoot = subRoot->right;
            }
            else {
                root = getLeftMost(root->right);
                subRoot = getLeftMost(subRoot->right);
            }

        }
        return root == null && subRoot == null;
    }
    bool isSubtree(TreeNode* root, TreeNode* subRoot) {
        if (root == null) {
            return false;
        }
        if (compare(root, subRoot)) {
            return true;
        }
        return isSubtree(root->left, subRoot) || isSubtree(root->right, subRoot);
    }
};
```



