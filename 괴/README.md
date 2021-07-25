Tree 의 이론적 배경 및 구조 학습
https://www.evernote.com/shard/s133/client/snv?noteGuid=5b4337df-6cdb-4ab8-beda-46a25fb07d86&noteKey=037aed9c29e61da2&sn=https%3A%2F%2Fwww.evernote.com%2Fshard%2Fs133%2Fsh%2F5b4337df-6cdb-4ab8-beda-46a25fb07d86%2F037aed9c29e61da2&title=2021.07.25%2BTree%2B%25EC%259D%2598%2B%25EC%259D%25B4%25EB%25A1%25A0%25EC%25A0%2581%2B%25EB%25B0%25B0%25EA%25B2%25BD%2B%25EB%25B0%258F%2B%25EA%25B5%25AC%25EC%25A1%25B0%2B%25ED%2595%2599%25EC%258A%25B5


572. Subtree of Another Tree
https://leetcode.com/problems/subtree-of-another-tree/

```python3

# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right
class Solution:
    def isSubtree(self, root: TreeNode, subRoot: TreeNode) -> bool:
        
        if root == None:
            return False
        elif root.val == subRoot.val and self.isSameTree(root, subRoot):
            return True
        else:
            return self.isSubtree(root.left, subRoot) or self.isSubtree(root.right, subRoot)
        
        return False
    
    
    def isSameTree(self, t1: TreeNode, t2: TreeNode):
        if t1 == None and t2 == None:
            return True
        if (t1 == None and t2 != None) or (t1 != None and t2 == None):
            return False
        
        return t1.val == t2.val and self.isSameTree(t1.left, t2.left) and self.isSameTree(t1.right, t2.right)
```

시간복잡도 : O(n)