using System;
using static Code1.Tree;

namespace Code1
{
	public class Program3
	{
		public Program3()
		{

		}
		//108 有序数组转为二叉搜索树
        public TreeNode SortedArrayToBST(int[] nums)
        {
			return SortedArrayToBST2(nums, 0, nums.Length - 1);
        }
		public TreeNode SortedArrayToBST2(int[] nums, int left, int right)
		{
			if (right < left)
				return null;
			int mid = left + (right-left) / 2;
			TreeNode tMid = new TreeNode(nums[mid]);
			tMid.left = SortedArrayToBST2(nums, left, mid - 1);
			tMid.right = SortedArrayToBST2(nums, mid + 1, right);
			return tMid;
		}
    }
}

