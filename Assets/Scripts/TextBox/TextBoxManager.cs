using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour
{
    private static GameObject textBox;
    private static Text textBoxAuthor;
    public static Text textBoxContent;
    private static AudioSource audioSource;
    public static bool active = false;
    public static bool paused = false;

    public static Conversation conversation;

    private void Awake()
    {
        textBox = GameObject.FindGameObjectWithTag("TextBox");
        textBoxAuthor = GameObject.FindGameObjectWithTag("TextBoxAuthor").GetComponent<Text>();
        textBoxContent = GameObject.FindGameObjectWithTag("TextBoxContent").GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (active && conversation != null && ButtonHandler.jump)
        {
            if (conversation.hasEnded())
            {
                DisableTextBox();
            } else
            {
                conversation.prepareNextLine();
                DisplayConversation();
            }
        }
    }

    private static void DisplayConversation()
    {
        audioSource.Stop();
        textBoxContent.text = conversation.getNextLine();
        if (conversation.getAuthor().Length == 0)
        {
            textBoxAuthor.gameObject.SetActive(false);
        } else
        {
            textBoxAuthor.gameObject.SetActive(true);
            textBoxAuthor.text = conversation.getAuthor();
        }

        if(conversation.getCurrentSnippet() != null)
        {
            AudioClip vocals = conversation.getCurrentSnippet().vocals;
            if (vocals != null)
            {
                audioSource.PlayOneShot(vocals);
            }
        }
    }

    public static void EnableTextBox(Conversation conversation)
    {
        active = true;
        textBox.SetActive(true);
        TextBoxManager.conversation = conversation;
        DisplayConversation();
    }

    private void DisableTextBox()
    {
        active = false;
        textBox.SetActive(false);
        conversation = null;
    }

    public static bool isPlayingSound()
    {
        return audioSource != null && audioSource.isPlaying;
    }

    public static void StartConversation(string conversationId)
    {
        Conversation conversation = TextImporter.textFileToConversation("intro");
        EnableTextBox(conversation);
    }
}
