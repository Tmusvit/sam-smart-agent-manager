using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sam.helper
{

    

    internal class TreeViewBuilder
    {
        private readonly TreeView _treeView;
        private readonly ImageList _imageList;

        public TreeViewBuilder(TreeView treeView)
        {
            _treeView = treeView;
            _imageList = new ImageList();
            _treeView.ImageList = _imageList;
        }

        public void AddTopLevelCategory(string categoryName, Image icon)
        {
            var node = new TreeNode(categoryName);
            node.ImageIndex = _imageList.Images.Count;
            node.SelectedImageIndex = _imageList.Images.Count;
            _imageList.Images.Add(icon);
            _treeView.Nodes.Add(node);
        }

        public TreeNode AddSubCategory(string parentCategoryName, string subCategoryName, Image icon, object tag)
        {
            var parentNode = FindNode(parentCategoryName);
            if (parentNode == null)
            {
                return null;
            }

            var node = new TreeNode(subCategoryName);
            node.ImageIndex = _imageList.Images.Count;
            node.SelectedImageIndex = _imageList.Images.Count;
            _imageList.Images.Add(icon);
            node.Tag = tag; // Set the tag for the node
            parentNode.Nodes.Add(node);

            return node;
        }



        private TreeNode FindNode(string text)
        {
            foreach (TreeNode node in _treeView.Nodes)
            {
                if (node.Text == text)
                {
                    return node;
                }
            }

            return null;
        }

    }
}
