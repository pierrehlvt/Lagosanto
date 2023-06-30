using System;
using System.Collections.Generic;

namespace Lagosanto.Interpreter.TreeNode;
public class TreeNode<TE> {
        public List<TreeNode<TE>> Children = new();
        public int Count { get => Children.Count; }
        public TE Element { get; set; }

        public TreeNode(TE element) {
            Element = element;
        }

        public TreeNode<TE> AddChild(TE element) {
            TreeNode<TE> child = new(element);
            Children.Add(child);
            return child;
        }

        public TreeNode<TE> AddChild(TreeNode<TE> treeElement) {
            TreeNode<TE> child = treeElement;
            Children.Add(child);
            return child;
        }

        public override string ToString() {
            String returnedString = "" + Element;
            if (Children.Count > 0) {
                returnedString += "(";
                foreach (TreeNode<TE> child in Children) {
                    returnedString += child + ",";
                }
                returnedString = returnedString[0..(returnedString.Length - 2)] + ")";
            }
            return returnedString;
        }
}