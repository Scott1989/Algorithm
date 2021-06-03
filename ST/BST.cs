using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.ST
{
    /// <summary>
    /// 基于二叉查找树结构的KEY-VALUE数据结构
    /// key(ROOT) > key(LEFT) && key(ROOT) < key(RIGHT)，对于左右子树，同样符合该定义
    /// 通过中序遍历，可以输出一个升序的序列
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
            public int N { get; set; }   //以该节点为根的字数中，节点的数量

            public Node(Key key, Value value, int N, Node left, Node right)
            {
                this.key = key;
                this.value = value;
                this.left = left;
                this.right = right;
                this.N = N;
            }
        }

        
        private Node root;  //查找二叉树根节点引用

        /// <summary>
        /// 将给定的KEY,VALUE数据，插入到二叉查找树中
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Put(Key key, Value value)
        {
            Node newNode = new Node(key, value, 1, null, null);

            //树为空，直接将该节点作为根节点
            if (root == null)
            {
                root = newNode;
                return;
            }

            //比当前节点KEY小，向左子树找；比当前节点KEY大，向右子树找，寻找插入位置
            Node cur = root;

            while(cur != null)
            {
                if (cur.key.CompareTo(key) == 0)       //KEY已经存在，直接覆盖Value
                {
                    cur.value = value;
                    return;
                }else if (cur.key.CompareTo(key) < 0)  //当前节点小于KEY，去右子树
                {
                    if (cur.right == null)
                    {
                        cur.right = newNode;
                        break;
                    }else
                    {
                        cur = cur.right;
                    }
                }else                                                 //当前节点大于KEY，去左子树
                {
                    if (cur.left == null)
                    {
                        cur.left = newNode;
                        break;
                    }else
                    {
                        cur = cur.left;
                    }
                }
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


        /// <summary>
        /// 删除指定key的节点信息，并保持二叉搜索树的定义
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public void Delete(Key key)
        {
            Node cur = root;
            Node parent = null;
            

            while (cur != null)
            {
                if (cur.key.CompareTo(key) < 0)
                {
                    parent = cur;
                    cur = cur.right;
                
                }else if (cur.key.CompareTo(key) > 0)
                {
                    parent = cur;
                    cur = cur.left;
                
                }else if (cur.key.CompareTo(key) == 0)
                {
                    break;
                }
            }

            //未找到对应节点
            if (cur == null) return;

                
            if (cur.left == null && cur.right == null)  //左右节点为空，将其父节点对应得引用设置为空
            {
                //cur为parent左节点
                if(parent.left == cur)
                {
                    parent.left = null;
                }

                //cur为parent右节点
                if (parent.right == cur)
                {
                    parent.right = null;
                }
                
            }else if (cur.left == null && cur.right != null) //只有右孩子节点不为空
            {

                //cur为parent左节点
                if(parent.left == cur)
                {
                    parent.left = cur.right;
                }

                //cur为parent右节点
                if (parent.right == cur)
                {
                    parent.right = cur.right;
                }
            }else if (cur.left != null && cur.right == null) //只有左孩子节点不为空
            {
                //cur为parent左节点
                if(parent.left == cur)
                {
                    parent.left = cur.left;
                }

                //cur为parent右节点
                if (parent.right == cur)
                {
                    parent.right = cur.left;
                }
                
            }else   //左右子节点都不为空
            {
                //找到cur节点前驱节点，然后替换掉CUR，最后将对应得前驱节点删除
                Node prevNode = GetMaxNode(cur.left);  //获取cur节点的前驱节点
                cur.key = prevNode.key;
                cur.value = prevNode.value;
                prevNode = null;
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
            return GetMinNode(root).key;
        }


        /// <summary>
        /// 根据指定节点，获取以它为根的子树中的最小节点
        /// </summary>
        /// <param name="givenNode"></param>
        /// <returns></returns>
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
        public Key? Max()
        {
            return GetMaxNode(root).key;
        }

        /// <summary>
        /// 根据指定节点，获取以它为根的子树中的最大节点
        /// </summary>
        /// <param name="givenNode"></param>
        /// <returns></returns>
        private Node? GetMaxNode(Node givenNode)
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
        /// 获取小于key的关键字数量，有BUG
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int Rank(Key key)
        {
            return Rank(root, key);
        }


        /// <summary>
        /// 从以给定节点为根的子树中，查找KEY的排名
        /// </summary>
        /// <param name="cur"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private int Rank(Node cur, Key key)
        {
            int cmp = cur.key.CompareTo(key);

            if (cmp == 0)
            {
                return Size(cur.left);
            }else if (cmp < 0)
            {
                //cur左子树数量 + 1 + 
                return 1 + Size(cur.left) + Rank(cur.right, key);
            }else
            {
                return Rank(cur.left, key);
            }
        }

        /// <summary>
        /// 获取排名为K的关键字信息
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
 /*       public Key Select(int k)
        {

        }*/

        /// <summary>
        /// 删除二叉查找树中的最小节点，即最左下脚节点
        /// </summary>
        public void DeleteMin()
        {
            if(root == null) return;
            
            Node cur = root;
            Node parent = null;
            while (cur != null)
            {
                if (cur.left == null)
                {
                     parent.left = null;
                    return;
                }else
                {
                    parent = cur;
                    cur = cur.left;
                }
            }
        }

        /// <summary>
        /// 删除二叉查找树中的最大节点，即最右下脚节点
        /// </summary>
        public void DeleteMax()
        {
            //树节点为空，直接返回
            if (root == null)   return;

            Node cur = root;
            Node parent = null;
            while (cur != null)
            {
                if(cur.right == null)
                {
                    parent.right = null;
                    return;
                }else
                {
                    parent = cur;
                    cur = cur.right;
                }
            }
        }

        public int Size()
        {
            root.N = Size(root);
            return root.N;
        }

        private int Size(Node node)
        {
            if (node == null)
            {
                return 0;
            } else if (node.left == null && node.right == null)
            {
                node.N = 1;
                return node.N;
            }else
            {
                node.N = Size(node.left) + Size(node.right) + 1;
                return node.N;
            }
        }


    }
}
