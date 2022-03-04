using System;

namespace bor
{
    class Tree
    {
        private Node root;
        public int Size;
        public Tree()
        {
            root = new Node();
            this.Size = 0;
        }
        public bool Add(string element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("String can not be empty!");
            }
            ++Size;
            Node? current = root;
            var WasNotInBor = false;
            foreach (var symbol in element)
            {
                if (current == null)
                {
                    return false;
                }
                ++current.HowManyWordsPassedNode;
                var code = symbol - 'a';
                if (current.Children[code] == null)
                {
                    current.Children[code] = new Node();
                    WasNotInBor = true;
                }
                current = current.Children[code];
            }
            ++current.HowManyWordsEndsHere;
            return WasNotInBor;
        }
        public bool Contains(string element)
        {
            Node? current = root;
            foreach (var symbol in element)
            {
                var code = symbol - 'a';
                if (current == null || current.Children == null || current.Children[code] == null)
                {
                    return false;
                }
                current = current.Children[code];
            }
            return current.HowManyWordsEndsHere != 0;
        }
        public bool Remove(string element)
        {
            Node? current = root;
            var shouldRemove = false;
            foreach (var symbol in element)
            {
                var code = symbol - 'a';
                if (current == null || current.Children[code] == null)
                {
                    return false;
                }
                if (current.Children[code].HowManyWordsPassedNode > 1)
                {
                    --current.Children[code].HowManyWordsPassedNode;
                    current = current.Children[code];
                }
                else
                {
                    if (!shouldRemove)
                    {
                        shouldRemove = true;
                    }
                    var temporary = current.Children[code];
                    current.Children[code] = null;
                    current = temporary;
                }
            }
            --Size;
            return true;
        }
        public int HowManyStartsWithPrefix(string prefix)
        {
            Node? current = root;
            foreach (var symbol in prefix)
            {
                var code = symbol - 'a';
                if (current == null || current.Children == null || current.Children[code] == null)
                {
                    return 0;
                }
                current = current.Children[code];
            }
            return current.HowManyWordsPassedNode;
        }
    }
}
