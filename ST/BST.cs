using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.ST
{
    /// <summary>
    /// 基于二叉查找树结构的KEY-VALUE数据结构
    /// key(ROOT) > key(LEFT) && key(ROOT) < key(RIGHT)
    /// 最小元素--最左下脚元素
    /// 最大元素-最右下脚元素
    /// 1.结构中不存在重复KEY
    /// 2.每个键只对应一个值
    /// 3.插入元素时，KEY若已存在，将VALUE覆盖
    /// 4.不存在KEY为NULL的键
    /// 5.不存在VALUE为NULL的值
    /// 6. 按KEY进行排好序
    /// </summary>
    /// <typeparam name="Key">关键字</typeparam>
    /// <typeparam name="Value">值</typeparam>
    public class BST<Key, Value> where Key : IComparable
    {
        private class Node
        {
            public Key key { get; set; }
            public Value value { get; set; }

            public Node left { get; set; }

            public Node right { get; set; }

            public Node(Key key, Value value, Node left, Node right)
            {
                this.key = key;
                this.value = value;
                this.left = left;
                this.right = right;
            }
        }

        private Node root;

        /// <summary>
        /// 将给定的KEY,VALUE数据，插入到二叉查找树中
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Put(Key key, Value value)
        {
            Node newNode = new Node(key, value, null, null);

            //树中为空，直接插入
            if (root == null)
            {
                root = newNode;
                return;
            }

            //根据比当前节点小，向左子树找；比当前节点大，向右子树找的规律，找插入位置
            Node cur = root;
            Node parent = null;
            while(cur != null)
            {
                if (cur.key.CompareTo(key) == 0)
                {
                    cur.key = key;
                    return;
                }else if (cur.key.CompareTo(key) < 0)
                {
                    parent = cur;
                    cur = cur.right;
                }else
                {
                    parent = cur;
                    cur = cur.left;
                }
            }

            //找到插入位置后，插入数据
            if (parent.key.CompareTo(key) > 0)
            {
                parent.left = newNode;
                return;
            }

            if (parent.key.CompareTo(key) < 0)
            {
                parent.right = newNode;
                return;
            }
        }

        /// <summary>
        /// 从二叉查找树中查找指定KEY对应的VALUE
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Value Get(Key key)
        {
            return Get(root, key);
        }

        private Value Get(Node root, Key key)
        {
           Node cur = root;
            while (cur != null)
            {
                if (cur.key.Equals(key))
                {
                    return cur.value;
                }
                else if (cur.key.CompareTo(key) < 0)
                {
                    cur = cur.right;
                }
                else
                {
                    cur = cur.left;
                }
            }
            return default(Value);
        }


        public void Delete(Key key)
        {
            Node cur = root;
            Node parent = null;

            while (cur != null)
            {
                if (cur.key.CompareTo(key) < 0)
                {
                    parent = cur;
                    cur = cur.left;
                }else if (cur.key.CompareTo(key) > 0)
                {
                    parent = cur;
                    cur = cur.right;
                }
                if (cur.key.CompareTo(key) == 0)
                {
                    break;
                }

                if (cur == null) return;

                
               /* if (parent != null && cur != null)
                {
                    parent.
                }*/
            }
        }

        /// <summary>
        /// 检查二叉查找树中是否存在指定的KEY
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Contains(Key key)
        {
            Node cur = root;
            while (cur != null)
            {
                if (cur.key.Equals(key))
                {
                    return true;
                }
                else if (cur.key.CompareTo(key) < 0)
                {
                    cur = cur.right;
                }
                else
                {
                    cur = cur.left;
                }
            }
            return false;
        }


        /// <summary>
        /// 判断二叉查找树是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return root == null;
        }

        /// <summary>
        /// 返回二叉查找树中的最小KEY
        /// 返回最左下脚元素
        /// </summary>
        /// <returns></returns>
        public Key Min()
        {
            if (IsEmpty())
            {
                return default(Key);
            }
            
            Node minNode = GetMinNode(root);
            if (minNode != null) return minNode.key;

            return default(Key);
        }

        private Node GetMinNode(Node givenNode)
        {
            Node cur = givenNode;
            while (cur != null)
            {
                if (cur.left == null) break;
                cur = cur.left;
            }

            return cur;
        }


        /// <summary>
        /// 返回二叉查找树中的最大KEY
        /// 返回最右下脚元素
        /// </summary>
        /// <returns></returns>
        public Key Max()
        {
            if (IsEmpty())
            {
                return default(Key);
            }
            Node maxNode = GetMaxNode(root);
            if (maxNode != null) return maxNode.key;

            return default(Key);
        }


        private Node GetMaxNode(Node givenNode)
        {
            Node cur = givenNode;
            while (cur != null)
            {
                if (cur.right == null) break;
                cur = cur.right;
            }

            return cur;
        }



        /// <summary>
        /// 获取小于key的关键字数量
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int Rank(Key key)
        {
            int lessCount = 0;
            Node cur = root;

            while(cur != null)
            {
                if (cur.key.CompareTo(key) < 0)
                {
                    lessCount++;
                    cur = cur.left;
                }else
                {
                    cur = cur.left;
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

        }


        public void DeleteMin()
        {
            Node cur = root;
            Node parent = null;

            while (cur != null)
            {
                if (cur.left != null)
                {
                    parent = cur;
                    cur = cur.left;
                }
                else
                {
                    break;
                }
            }

            //只有一个根节点
            if (parent == null && cur != null)
            {
                root = null;
            }else
            {
                parent.left = null;
            }
        }

        /// <summary>
        /// 删除二叉查找树中的最大节点，即右下脚节点
        /// </summary>
        public void DeleteMax()
        {
            Node cur = root;
            Node parent = null;

            while (cur != null)
            {
                if (cur.right != null)
                {
                    parent = cur;
                    cur = cur.right;
                }
                else
                {
                    break;
                }
            }

            //只有一个根节点
            if (parent == null && cur != null)
            {
                root = null;
            }
            else
            {
                parent.right = null;
            }
        }
    }
}
