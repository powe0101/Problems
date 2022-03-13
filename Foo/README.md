```c++
/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     ListNode *next;
 *     ListNode() : val(0), next(nullptr) {}
 *     ListNode(int x) : val(x), next(nullptr) {}
 *     ListNode(int x, ListNode *next) : val(x), next(next) {}
 * };
 */
class Solution {
public:
    ListNode* mergeNodes(ListNode* head) {
        ListNode* result = new ListNode(0);
        
        ListNode* seek = result;
        while(head->next != nullptr)
        {
            if(head->val == 0)
            {
                long long temp = 0;
                head = head->next;
                
                while(head->next != nullptr)
                {
                    if(head->val == 0)
                        break;
                    
                    temp += head->val;
                    head = head->next;
                    
                }
                
                auto node = new ListNode(temp);
                seek->next = node;
                seek = seek->next;
            }
        }
        return result->next;
    }
};

```

```python3
class Solution(object):
    def multiply(self, num1, num2):
        """
        :type num1: str
        :type num2: str
        :rtype: str
        """
        return str(int(num1)*int(num2))

```

```
using System;
using System.Collections.Generic;

class LinkedHashMap<T, U>
{
    Dictionary<T, LinkedListNode<Tuple<U, T>>> D = new Dictionary<T, LinkedListNode<Tuple<U, T>>>();
    LinkedList<Tuple<U,T>> LL = new LinkedList<Tuple<U, T>>();

    public U this[T c]
    {
        get
        {
            return D[c].Value.Item1;
        }

        set
        {
            if(D.ContainsKey(c))
            {
                LL.Remove(D[c]);
            }

            D[c] = new LinkedListNode<Tuple<U, T>>(Tuple.Create(value, c));
            LL.AddLast(D[c]);
        }
    }

    public bool ContainsKey(T k)
    {
        return D.ContainsKey(k);
    }

    public U PopFirst()
    {
        var node = LL.First;
        LL.Remove(node);
        D.Remove(node.Value.Item2);
        return node.Value.Item1;
    }

    public int Count
    {
        get
        {
            return D.Count;
        }
    }
}

public class LRUCache {
    private LinkedList<KeyValuePair<int, int>> list;
    private Dictionary<int, LinkedListNode<KeyValuePair<int, int>>> map;
    private int capacity;
    
    public LRUCache(int capacity) {
        this.capacity = capacity;

        list = new LinkedList<KeyValuePair<int, int>>();
        map = new Dictionary<int, LinkedListNode<KeyValuePair<int, int>>>();
    }
    
    public int Get(int key) {
        
        if (!map.ContainsKey(key)) 
            return - 1;
        
        var node = map[key];
        list.Remove(node);
        
        map[key] = list.AddFirst(node.Value);
        
        return node.Value.Value;
    }
    
    public void Put(int key, int value) {
        if(map.ContainsKey(key))
        {
            var node = map[key];
            list.Remove(node);
            map[key] = list.AddFirst(new KeyValuePair<int, int>(key, value));
        }
        else 
        {
            if(list.Count>= this.capacity) 
            {
                map.Remove(list.Last().Key);
                list.RemoveLast();
            }
            
            map[key] = list.AddFirst(new KeyValuePair<int, int>(key, value));
        }
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */

```
