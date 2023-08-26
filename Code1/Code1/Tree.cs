using System;
namespace Code1
{
    public class Tree
    {
        public Tree()
        {
        }

        //Definition for a binary tree node.
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
        //前序遍历
        //144 递归
        public IList<int> PreorderTraversal(TreeNode root)
        {
            List<int> res = new List<int>();
            PreorderTraversal2(root, res);
            return res;
        }
        public void PreorderTraversal2(TreeNode t, List<int> list)
        {
            if (t == null)
                return;
            list.Add(t.val);
            PreorderTraversal2(t.left, list);
            PreorderTraversal2(t.right, list);
        }
        //144 非递归
        public IList<int> PreorderTraversalIteration(TreeNode root)
        {
            List<int> res = new List<int>();
            Stack<TreeNode> s = new Stack<TreeNode>();
            if (root != null)
            {
                s.Push(root);
                while (s.Count != 0)
                {
                    TreeNode t = s.Pop();
                    res.Add(t.val);
                    if (t.right != null)
                        s.Push(t.right);
                    if (t.left != null)
                        s.Push(t.left);
                }
            }
            return res;
        }
        //中序遍历
        //94
        public IList<int> InorderTraversal(TreeNode root)
        {
            List<int> res = new List<int>();
            InorderTraversal2(root, res);
            return res;
        }
        public void InorderTraversal2(TreeNode t, List<int> list)
        {
            if (t == null)
                return;
            InorderTraversal2(t.left, list);
            list.Add(t.val);
            InorderTraversal2(t.right, list);
        }
        //94 非递归 维护一个当前正在处理的节点 先向左寻找 左节点无了（当前==null）就可以出栈并处理右节点（当前=s.pop.right）了
        public IList<int> InorderTraversalIteration(TreeNode root)
        {
            List<int> res = new List<int>();
            if (root != null)
            {
                Stack<TreeNode> s = new Stack<TreeNode>();
                while (root != null || s.Count != 0)
                {
                    if (root != null)
                    {
                        s.Push(root);
                        root = root.left;
                    }
                    else
                    {
                        TreeNode t = s.Pop();
                        res.Add(t.val);
                        root = t.right;
                    }
                        
                }
            }
            return res;
        }
        //145 后序遍历
        public IList<int> PostorderTraversal(TreeNode root)
        {
            List<int> res = new List<int>();
            if (root != null)
            {
                Stack<TreeNode> s = new Stack<TreeNode>();
                while (root != null || s.Count != 0)
                {
                    while (root != null)
                    {
                        s.Push(root);
                        if (root.left != null)
                        {
                            root = root.left;
                        }
                        else
                            root = root.right;
                    }
                    TreeNode t = s.Pop();
                    res.Add(t.val);
                    if (s.Count!=0 && t == s.Peek().left)
                    {
                        root = s.Peek().right;
                    }
                    else
                        root = null;
                }
            }
            return res;
        }
        //102 层序遍历
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            List<IList<int>> res = new List<IList<int>>();
            Queue<TreeNode> q = new Queue<TreeNode>();
            int curLevelLength = 0;
            if (root != null)
                q.Enqueue(root);
            while (q.Count > 0)
            {
                List<int> l = new List<int>();
                curLevelLength = q.Count;
                for (int i = 1; i <= curLevelLength; i++)
                {
                    TreeNode t = q.Dequeue();
                    l.Add(t.val);
                    if (t.left != null)
                        q.Enqueue(t.left);
                    if (t.right != null)
                        q.Enqueue(t.right);
                }
                res.Add(l);
            }
            return res;
        }
    }
}

