namespace Bor.Tests;

using NUnit.Framework;
using Bor;

public class Tests
{
    private Trie trie = new Trie(); 

    [SetUp]
    public void Setup()
    {
        trie = new Trie();
    }

    [Test]
    public void TrieAddAndDeleteSameOrPartsTest()
    {
        Assert.IsTrue(trie.Add("qwerty"));
        Assert.IsFalse(trie.Add("qwerty"));
        Assert.IsTrue(trie.Add("qasdfg"));
        Assert.IsFalse(trie.Remove("qag"));
        Assert.IsTrue(trie.Remove("qasdfg"));
        Assert.IsFalse(trie.Remove("qwe"));
        Assert.IsTrue(trie.Remove("qwerty"));
        Assert.IsTrue(trie.Remove("qwerty"));
        Assert.IsTrue(trie.Size == 0);
    }

    [Test]
    public void TrieSizeTest()
    {
        Assert.IsTrue(trie.Size == 0);
        trie.Add("qwerty");
        Assert.IsTrue(trie.Size == 1);
        trie.Add("qwerty");
        Assert.IsTrue(trie.Size == 2);
        trie.Add("qasdfg");
        Assert.IsTrue(trie.Size == 3);
        trie.Remove("qwerty");
        Assert.IsTrue(trie.Size == 2);
        trie.Remove("qasdfg");
        Assert.IsTrue(trie.Size == 1);
        trie.Remove("qwerty");
        Assert.IsTrue(trie.Size == 0);
        trie.Remove("qwerty");
        Assert.IsTrue(trie.Size == 0);
    }

    [Test]
    public void TrieContainsTest()
    {
        trie.Add("qwerty");
        Assert.IsTrue(trie.Contains("qwerty"));
        trie.Add("qwerty");
        Assert.IsFalse(trie.Contains("qwertyi"));
        trie.Add("qasdfg");
        Assert.IsFalse(trie.Contains("q"));
        Assert.IsTrue(trie.Contains("qwerty"));
        Assert.IsTrue(trie.Contains("qasdfg"));
        trie.Remove("qwerty");
        Assert.IsTrue(trie.Contains("qwerty"));
        trie.Remove("qasdfg");
        Assert.IsFalse(trie.Contains("qasdfg"));
        trie.Remove("qwerty");
        Assert.IsFalse(trie.Contains("qwerty"));
    }

    [Test]
    public void TrieStartsWithPrefixTest()
    {
        trie.Add("qwerty");
        Assert.IsTrue(trie.HowManyStartsWithPrefix("qwerty") == 1);
        trie.Add("qwerty");
        Assert.IsTrue(trie.HowManyStartsWithPrefix("qwert") == 2);
        trie.Add("qasdfg");
        Assert.IsTrue(trie.HowManyStartsWithPrefix("q") == 3);
        Assert.IsTrue(trie.HowManyStartsWithPrefix("qasdfgsdy") == 0);
        trie.Remove("qwerty");
        Assert.IsTrue(trie.HowManyStartsWithPrefix("qwerty") == 1);
        trie.Remove("qasdfg");
        Assert.IsTrue(trie.HowManyStartsWithPrefix("qas") == 0);
        trie.Remove("qwerty");
        Assert.IsTrue(trie.HowManyStartsWithPrefix("q") == 0);
    }
}
