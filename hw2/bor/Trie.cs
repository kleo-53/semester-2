namespace Bor;

using System;

/// <summary>
/// Class of Trie structure
/// </summary>
public class Trie
{
    /// <summary>
    /// Element of the trie
    /// </summary>
    private class Node
    {
        /// <summary>
        /// Потомки элемента
        /// </summary>
        public Dictionary<char, Node> Children { get; set; }

        /// <summary>
        /// Number of words that are in the descendants of the vertex
        /// </summary>
        public int HowManyWordsPassedNode { get; set; }

        /// <summary>
        /// Number of words that are ends in the vertex
        /// </summary>
        public int HowManyWordsEndsHere { get; set; }

        public Node()
        {
            this.Children = new Dictionary<char, Node>();
        }
    }

    private Node root;

    /// <summary>
    /// Number of words in the trie
    /// </summary>
    public int Size { get; set; }

    public Trie()
    {
        root = new Node();
    }

    /// <summary>
    /// Adds element to the trie
    /// </summary>
    /// <param name="element">Element to add</param>
    /// <returns>Was the same element in the trie before the addition</returns>
    public bool Add(string element)
    {
        ArgumentNullException.ThrowIfNull(element);
        ++Size;
        var current = root;
        var isNew = false;
        foreach (var symbol in element)
        {
            if (current == null)
            {
                return false;
            }
            ++current.HowManyWordsPassedNode;
            if (!current.Children.ContainsKey(symbol))
            {
                current.Children[symbol] = new Node();
                isNew = true;
            }
            current = current.Children[symbol];
        }
        ++current.HowManyWordsPassedNode;
        ++current.HowManyWordsEndsHere;
        return isNew;
    }

    /// <summary>
    /// Checks if element is located in the trie
    /// </summary>
    /// <param name="element">Element to check</param>
    /// <returns>If the trie consists the element</returns>
    public bool Contains(string element)
    {
        var current = root;
        foreach (var symbol in element)
        {
            if (current == null || current.Children == null || !current.Children.ContainsKey(symbol))
            {
                return false;
            }
            current = current.Children[symbol];
        }
        return current.HowManyWordsEndsHere != 0;
    }

    /// <summary>
    /// Removes the element of the trie
    /// </summary>
    /// <param name="element">Element to remove</param>
    /// <returns>Is removing was successful</returns>
    public bool Remove(string element)
    {
        if (!Contains(element))
        {
            return false;
        }
        var current = root;
        foreach (var symbol in element)
        {
            if (current == null || !current.Children.ContainsKey(symbol))
            {
                return false;
            }
            if (current.Children[symbol].HowManyWordsPassedNode > 1)
            {
                --current.Children[symbol].HowManyWordsPassedNode;
                current = current.Children[symbol];
            }
            else if (current.Children[symbol].HowManyWordsPassedNode == 1)
            {
                --current.Children[symbol].HowManyWordsPassedNode;
                var temporary = current.Children[symbol];
                current.Children.Remove(symbol);
                current = temporary;
            }
            else
            {
                return false;
            }
        }
        --Size;
        return true;
    }

    /// <summary>
    /// Counts how many words start from given prefix
    /// </summary>
    /// <param name="prefix">Prefix to work with</param>
    /// <returns>Number of words</returns>
    public int HowManyStartsWithPrefix(string prefix)
    {
        var current = root;
        foreach (var symbol in prefix)
        {
            if (current == null || current.Children == null || !current.Children.ContainsKey(symbol))
            {
                return 0;
            }
            current = current.Children[symbol];
        }
        return current.HowManyWordsPassedNode;
    }
}
