```python3
class Solution:
    def spiralOrder(self, matrix: List[List[int]]) -> List[int]:
        result = []
        
        while matrix:
            temp = matrix.pop(0)
            result += temp
            
            if matrix and matrix[0]:
                for row in matrix:
                    temp = row.pop()
                    result.append(temp)
                
            if matrix:
                temp = matrix.pop()[::-1]
                result += temp
            
            if matrix and matrix[0]:
                for row in matrix[::-1]:
                    temp = row.pop(0)
                    result.append(temp)
        
        return result
        
```
