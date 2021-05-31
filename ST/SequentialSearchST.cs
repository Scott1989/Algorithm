using System;

namespace Algorithm.ST
{
    /// <summary>
    /// 线性链表式的KEY-VALUE数据结构
    /// 1.结构中不存在重复KEY
    /// 2.每个键只对应一个值
    /// 3.插入元素时，KEY若已存在，将VALUE覆盖
    /// 4.不存在KEY为NULL的键
    /// 5.不存在VALUE为NULL的值
    /// 6. 按KEY进行排好序
    /// </summary>
    /// <typeparam name="Key">关键字</typeparam>
    /// <typeparam name="Value">值</typeparam>
    public class SequentialSearchST<Key, Value> where Key : IComparable
    {
        
        /// <summary>
        /// 用于存放KEY - VALUE - 下一个数据结构引用的内部节点信息
        /// </summary>
        private class Node
        {
            public Key key { get; set; }
            public Value value { get; set; }
            public Node next { get; set; }
            public Node prev { get; set; }
             public Node(Key key, Value value, Node prev, Node next)
            {
                this.key = key;
                this.value = value;
                this.next = next;
                this.prev = prev;
            }
        }

        private Node first;
        public int count { get; set; }

        /// <summary>
        /// 将KEY-VALUE数据结构放置到链表中，
        /// 如果该KEY已经存在，用VALUE覆盖已有的内容
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Put(Key key, Value value)
        {
            if (key == null || value == null)
            {
                return;
            }

            for(Node m = first; m != null; m = m.next)
            {
                if (m.key.Equals(key))
                {
                    m.value = value;
                    return;
                }
            }

            Node n = new Node(key, value, null, first);
            first.prev = n;
            first = n;
            count++;
        }

        
        /// <summary>
        /// 根据KEY值从链表中查找对应的VALUE；若不存在，返回NULL
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Value Get(Key key)
        {
            for(Node m = first; m != null; m = m.next)
            {
                if (key.Equals(m.key))
                {
                    return m.value;
                }
            }

            return default(Value);
        }

        /// <summary>
        /// 删除key的节点信息，若不存在，返回即可
        /// </summary>
        /// <param name="key"></param>
        public void Delete(Key key)
        {
            Node prev = null;
            for(Node m = first; m != null; m = m.next)
            {
                //查找到对应节点
                if (key.Equals(m.key))
                {
                    //如果查找到的节点是I一个节点，直接调整first的指向
                    if (prev == null)
                    {
                        first = m.next;
                        return;
                    }

                    //非首节点，让前节点跳过当前节点，指向下一个点
                   prev.next = m.next;
                   m.next.prev = prev;
                   return;
                }

                prev = m;
            }
        }

        /// <summary>
        /// 判断符号表中是否包含KEY，包含返回TRUE，否则返回FALSE
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Contains(Key key)
        {
            return Get(key) != null;
        }

        /// <summary>
        /// 判断链表是否为空
        /// </summary>
        /// <returns>链表空，返回TRUE,否则返回FALSE</returns>
        public bool IsEmpty()
        {
            return first == null;
        }

        /// <summary>
        /// 返回链表中Node节点数量
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return count;
        }

        /// <summary>
        /// 返回链表中的最小KEY
        /// </summary>
        /// <returns></returns>
        public Key Min()
        {
            Key minKey = first.key;
            for(Node m = first.next; m != null; m = m.next)
            {
                if (minKey.CompareTo(m.key) > 0)
                {
                    minKey = m.key;
                }
            }
            return minKey;
        }

        /// <summary>
        /// 返回链表中发现的最大KEY
        /// </summary>
        /// <returns></returns>
        public Key Max()
        {
            Key maxKey = first.key;
            for(Node m = first.next; m != null; m = m.next)
            {
                if (maxKey.CompareTo(m.key) < 0)
                {
                    maxKey = m.key;
                }
            }
            return maxKey;
        }

      

        /// <summary>
        /// 获取小于key的关键字数量
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int Rank(Key key)
        {
            int lessCount = 0;
            for (Node m = first; m != null; m = m.next)
            {
                if (m.key.CompareTo(key) < 0)
                {
                    lessCount++;
                }else
                {
                    break;
                }
            }
            return lessCount;
        }

        /// <summary>
        /// 获取排名为K的关键字信息
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public Key Select(int k)
        {
            int tick = 0;
            for(Node m = first; m != null; m = m.next)
            {
                tick++;
                if (tick == k)
                {
                    return m.key;
                }
            }

            //抛出异常  对象不存在
            return default(Key);
                
        }

        public void DeleteMin()
        {
            Node minRef = GetMinNode();

            if (minRef == first)
            {
                Node tmp = first;
                tmp.next = null;
                tmp.prev = null;
                first = first.next;
            }else
            {
                Node prevNode = minRef.prev;
                Node nextNode = minRef.next;
                prevNode.next = nextNode;
                nextNode.prev = prevNode;
            }
        }


        public void DeleteMax()
        {
            Node maxRef = GetMaxNode();
            
            if (maxRef == first)
            {
                Node tmp = first;
                tmp.next = null;
                tmp.prev = null;
                first = first.next;
            }
            else
            {
                Node prevNode = maxRef.prev;
                Node nextNode = maxRef.next;
                prevNode.next = nextNode;
                nextNode.prev = prevNode;
            }
        }

        /// <summary>
        /// 统计KEY位于[lo, hi]的数量
        /// </summary>
        /// <param name="lo"></param>
        /// <param name="hi"></param>
        /// <returns></returns>
        public int Size(Key lo, Key hi)
        {
            int count = 0;
            for(Node m = first; m != null; m = m.next)
            {
                if (m.key.CompareTo(lo)>=0 && m.key.CompareTo(hi) <= 0)
                {
                    count++;
                }
            }

            return count;
        }

    

        /// <summary>
        /// 查找最大节点位置
        /// </summary>
        /// <returns></returns>
        private Node GetMaxNode()
        {
            if (count == 0) return null;

            Key maxKey = first.key;
            Node maxRef = first;
            for (Node m = first.next; m != null; m = m.next)
            {
                if (maxKey.CompareTo(m.key) < 0)
                {
                    maxKey = m.key;
                    maxRef = m;
                }
            }
            return maxRef;
        }
    

        /// <summary>
        /// 查找最小节点信息
        /// </summary>
        /// <returns></returns>
        private Node GetMinNode()
        {
            if (count == 0) return null;

            Key minKey = first.key;
            Node minRef = first;
            for (Node m = first.next; m != null; m = m.next)
            {
                if (minKey.CompareTo(m.key) > 0)
                {
                    minKey = m.key;
                    minRef = m;
                }
            }
            return minRef;
        }


    }
}
