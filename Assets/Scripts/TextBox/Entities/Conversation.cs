using System;

public class Conversation
{
    public string id;
    public int currentSnippet;
    public ConversationSnippet[] snippets;

    public Conversation(string id, ConversationSnippet[] snippets)
    {
        this.id = id;
        this.snippets = snippets;
        currentSnippet = 0;
    }

    public bool hasEnded()
    {
        return currentSnippet > snippets.Length - 1;
    }

    public ConversationSnippet getCurrentSnippet()
    {
        if (hasEnded())
            return null;
        else
            return snippets[currentSnippet];
    }

    public string getAuthor()
    {
        if (hasEnded())
        {
            return "";
        }
        return snippets[currentSnippet].talkerName;
    }

    public string getNextLine()
    {
        if (hasEnded())
        {
            return "";
        }
        return snippets[currentSnippet].text;
    }

    public void prepareNextLine()
    {
        currentSnippet++;
    }
}