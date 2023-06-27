using System;
using Lagosanto.Interpreter.TreeNode;

namespace Lagosanto.Interpreter.Parser;

public class ParserTreeText
{
     public TreeNode<String> TreeText { get; set; }
        public String Token { get => TreeText.Element; }
        public int CountChildren { get => this.TreeText.Children.Count; }

        public ParserTreeText(String text) {
            TreeText = TextToTree(text);
        }

        public ParserTreeText(TreeNode<String> treeText) {
            TreeText = treeText;
        }

        private static TreeNode<String> TextToTree(String text) {
            TreeNode<String> root = new("");
            int nbOpen = 0;
            int nbClose = 0;
            int lastSeparator = 0;
            int indexOpen = 0;
            for (int i = 0; (i < text.Length) && (nbOpen + nbClose >= 0); i++) {
                switch (text[i]) {
                    case Parser.OpenCharacter:
                        if (nbOpen == nbClose) {
                            indexOpen = i + 1;
                            lastSeparator = indexOpen;
                        }
                        nbOpen++;

                        break;
                    case Parser.CloseCharacter:
                        nbClose++;
                        if (nbOpen == nbClose) {
                            root.AddChild(TextToTree(text[lastSeparator..i]));
                            return root;
                        }
                        break;
                    case Parser.SeparatorCharacter:
                        if (nbOpen == (nbClose+1)) {
                            root.AddChild(TextToTree(text[lastSeparator..i]));
                            lastSeparator = i + 1;
                        }
                        break;
                    case ' ':
                        break;
                    default:
                        if (nbOpen == nbClose) {
                            root.Element += text[i];
                        }
                        break;
                }
            }

            return root;
        }

        public TreeNode<String> GetChild(int index) {
            if (CountChildren > index) {
                return TreeText.Children[index];
            }
            return null;
        }

        public override string ToString() {
            return TreeText.ToString();
        }
}