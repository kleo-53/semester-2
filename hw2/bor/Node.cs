using System;

namespace bor
{
    class Node
    {
        public Node?[] Children;
        public int HowManyWordsPassedNode;
        public int HowManyWordsEndsHere;
        public Node()
        {
            this.Children = new Node[26];
            this.HowManyWordsPassedNode = 0;
            this.HowManyWordsEndsHere = 0;
        }
    }
}
