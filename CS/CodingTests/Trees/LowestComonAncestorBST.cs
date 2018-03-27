namespace CodingTests.Trees
{
    public static class LowestComonAncestorBST
    {
        private static TreeNode GetLeastCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
            {
                return null;
            }

            if (root.Value < p.Value || root.Value < q.Value)
            {
                return null;
            }

            if (root == p || root == q)
            {
                return root;
            }

            TreeNode left = GetLeastCommonAncestor(root.LeftChild, p, q);
            TreeNode right = GetLeastCommonAncestor(root.RightChild, p, q);

            return left != null && right != null ? root : left == null ? right : left;
        }

        private static TreeNode GetLeastCommonAncestorIterative(TreeNode root, TreeNode p, TreeNode q)
        {
            while ((root.Value - p.Value) * (root.Value - q.Value) > 0)
            {
                root = root.Value > p.Value ? root.LeftChild : root.RightChild;
            }

            return root;
        }
    }
}
