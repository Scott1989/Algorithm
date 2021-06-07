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
            public Node parent { get; set; }
            public int N { get; set; }   //以该节点为根的子树中，节点的数量

            public Node(Key key, Value value, int N, Node parent, Node left, Node right)
            {
                this.key = key;
                this.value = value;
                this.parent = parent;
                this.left = left;
                this.right = right;
                this.N = N;
            }
        }

        
        private Node root;  //查找二叉树根节点引用


        //获取根元素的VALUE
        public Value GetRoot()
        {
            if (root != null)
            {
                return root.value;
            }

            return default(Value);
        }

        /// <summary>
        /// 将给定的KEY,VALUE数据，插入到二叉查找树中
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Put(Key key, Value value)
        {
            Node newNode = new Node(key, value, 1, null, null, null);

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
                int cmp = cur.key.CompareTo(key);
                if (cmp == 0)       //KEY已经存在，直接覆盖Value
                {
                    cur.value = value;
                    return;
                }else if (cmp < 0)  //当前节点小于KEY，去右子树
                {
                    if (cur.right == null)
                    {
                        cur.right = newNode;
                        newNode.parent = cur;
                        break;
                    }else
                    {
                        cur = cur.right;
                    }
                }else if(cmp > 0)   //当前节点大于KEY，去左子树
                {
                    if (cur.left == null)
                    {
                        cur.left = newNode;
                        newNode.parent = cur;
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


        /// <summary>
        /// 从以node为根的树中，查找指定key的value
        /// </summary>
        /// <param name="node"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private Value Get(Node node, Key key)
        {
            Node cur = GetNode(node, key);
            if (cur != null) return cur.value;
            else return default(Value);
        }

        /// <summary>
        /// 从以node为根的树中，查找指定key的节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private Node GetNode(Node node, Key key)
        {
            Node cur = node;
            while (cur != null)
            {
                int cmp = cur.key.CompareTo(key);
                if (cmp == 0)
                {
                    return cur;
                }
                else if (cmp < 0)
                {
                    cur = cur.right;
                }
                else if (cmp > 0)
                {
                    cur = cur.left;
                }
            }
            return cur;
        }



        /// <summary>
        /// 删除指定key的节点信息，并保持二叉搜索树的定义
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public void Delete(Key key)
        {
            Node node = GetNode(root, key);
            Delete(node);
        }

        /// <summary>
        /// 删除指定引用的节点，并保持二叉搜索树的定义
        /// </summary>
        private void Delete(Node node)
        {
            if (node == null) return;

            Node parent = node.parent;
            if (node.left == null && node.right == null)  //左右子节点为空，将其父节点对应引用设置为空
            {
                //node就是根节点，没有parent，这棵树只有一个节点
                if (parent == null)
                {
                    root = null;
                    node.parent = null;
                    return;
                }else  //node是非根节点，需要更新parent引用
                {
                    if (parent.left == node)     parent.left = null;           //node为parent左节点
                    if (parent.right == node)   parent.right = null;         //cur为parent右节点

                    node.parent = null;
                    return;
                }
            }
            else if (node.left == null && node.right != null) 
            {
                if (parent == null)
                {
                    //node为根节点，更新root引用到孩子节点
                    root = node.right;
                    root.parent = null;
                }else
                {
                    if (parent.left == node)
                    {
                        parent.left = node.right;
                    }else if (parent.right == node)
                    {
                        parent.right = node.right;
                    }
                }
                node.right.parent = parent;
                node.parent = null;
                node.right = null;

            }
            else if (node.left != null && node.right == null)
            {
        
                if (parent == null)
                {
                    //node为根节点
                    root = node.left;
                    root.parent = null;
                }
                else
                {
                    if (parent.left == node)
                    {
                        parent.left = node.left;
                    }
                    else if (parent.right == node)
                    {
                        parent.right = node.left;
                    }
                }
                node.left.parent = parent;
                node.parent = null;
                node.left = null;
            }
            else   //左右子节点都不为空
            {           
                //找到node节点前驱节点，然后替换掉node，最后将对应得前驱节点删除
                Node prevNode = GetMaxNode(node.left);  //获取cur节点的前驱节点

                //左子树不为空，所以PrevNode一定不为空
                node.key = prevNode.key;
                node.value = prevNode.value;

                Node prevNodeParent = prevNode.parent;
                if (prevNodeParent.left == prevNode)
                {
                    prevNodeParent.left = prevNode.left;
                    
                    if (prevNode.left != null)
                    {
                        prevNode.left.parent = prevNodeParent;
                    }
                }
                if (prevNodeParent.right == prevNode)
                {
                    prevNodeParent.right = prevNode.left;
                    if (prevNode.left != null)
                    {
                        prevNode.left.parent = prevNodeParent;
                    }
                }
                return;
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
                int cmp = cur.key.CompareTo(key);
                if (cmp == 0)
                {
                    return true;
                }
                else if (cmp < 0)
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
            Node minNode = GetMinNode(root);
            if (minNode != null)
            {
                return minNode.key;
            }
            else
            {
                return default(Key);
            }
        }


        /// <summary>
        /// 根据指定节点，获取以它为根的子树中的最小节点
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private Node GetMinNode(Node node)
        {
            Node cur = node;
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
            Node maxNode = GetMaxNode(root);
            if (maxNode != null)
            {
                return maxNode.key;
            }else
            {
                return default(Key);
            }
        }

        /// <summary>
        /// 根据指定节点，获取以它为根的子树中的最大节点
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private Node? GetMaxNode(Node node)
        {
            Node cur = node;
            while (cur != null)
            {
                if (cur.right == null) break;
                else cur = cur.right;
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
            return Rank(root, key);
        }


        /// <summary>
        /// 从以给定节点为根的树中，查找KEY的排名
        /// </summary>
        /// <param name="cur"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private int Rank(Node cur, Key key)
        {
            int cmp = cur.key.CompareTo(key);

            if (cmp == 0)  //查找到目标节点，目标节点为根的树的大小，就是他的排名
            {
                return Size(cur);
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
      /*  public Key Select(int k)
        {

        }
*/
        /// <summary>
        /// 删除二叉查找树中的最小节点，即最左下脚节点
        /// </summary>
        public void DeleteMin()
        {
            if(root == null) return;

            //查找最小节点引用，并进行删除
            Node minNode = GetMinNode(root);
            Delete(minNode);            
        }

        /// <summary>
        /// 删除二叉查找树中的最大节点，即最右下脚节点
        /// </summary>
        public void DeleteMax()
        {
            //树节点为空，直接返回
            if (root == null)   return;

            //查找最大节点引用，并进行删除
            Node maxNode = GetMaxNode(root);
            Delete(maxNode);
        }


        /// <summary>
        /// 获取整个二叉搜索树的大小
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            if (root == null) return 0;

            root.N = Size(root);
            return root.N;
        }

        /// <summary>
        /// 获取以node为根节点的树的节点总数量
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
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
