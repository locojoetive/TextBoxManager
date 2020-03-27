Purpose: Text Box Management in Unity (v2019.2.4f1)
Developer: Johannes Michael
Date: 27-03-2020

Use this project, if you want to include a dialouge system into your unity project. 
Usage is for free, but at least reference this github repository.
Also, it would be a big help, if you support me on Patreon to help me make games, music, and projects like this.

This project is only recommended to use, if you have less than 100k dialouge snippets.
Since you will safe all dialouges in a single CSV file, it will not be feasible to show the content without interruption.
This paragraph is also here to remind me, to implement a distributed solution, which will handle  

These Instructions will make sure, you can integrate modifiable TextBoxes.
You will also learn to give voices or sound effects to specified text passages.
After this 15 min read, your only job is to write and record the dialouges in your game.

Entities:

First you should get familiar with the two entity types, which destructure a conversation.
This will help you to script your conversations and add audio files to the correct snippets.

ConversationSnippet:
This entity represents content a TextBox can display at one point in time.
It contains 
- the text content (can be empty),
- the talking person's name (optional),
- an audio clip which will be played as a one-shot during the display of this content (optional),
- and an image which will be displayed as an avatar (optional).

Conversation:
This entity contains all ConversationSnippets which, will be displayed during this conversation.



Instructions:

1. Download and clone the repository
2. Copy both directories into your Unity project's Asset folder
3. Open your Unity project
4. Integrate th eprefabs into your Unity Project
Pull the UI prefab into your scene hierarchy.
If you already have an EventSystem in your Scene, delete the EventSystem of the new object.
You can achieve this by deleting the EventSystem in the prefab, by unpacking your instance, or by creating and using a variant of this prefab.
5. Create your conversation
All conversations are saved in one csv file.
Open the csv file "Asset/Resources/text/TextBoxLines" in Excel or Google Sheets.
You will see the following columns 

- Conversation ID (String)
- Talker Name (String, optional)
- Content (String, optional)

Each row represents a snippet of a conversation in a specific conversation.
To create your first conversation, 
	1. set a desired conversationId (eg. "intro") without using spaces, forward-, or backward-slash.
	   You will later display the conversation with this conversationId.
	2. enter a talker name, which will be displayed as the talking person.
	   If you enter no name, the name text field will be disabled for this snippet.
	3. enter the content which will be displayed in the TextBox.

Repeat this process with the same Conversation ID, if you want to add content to your conversation.

Repeat this process with a different Conversation ID, if you want to create 

If you want to add sound effects to specific snippets,
1. create a folder inside "Assets/Resources/vocals" called after your Conversation ID (eg. "intro")
2. add the audio file into this folder and rename it to the number of the snippet subtracted by one.
(eg if your audio file is for the first snippet of your conversation call it "0", if it is for the 5th, call it "4")

As a final step use the following line to display the TextBox for a specified conversation

```
TextBoxManager.StartConversation("Conversation-ID")
```


Future Work:

1. Implement support for Sprites as avatars, per snippet.
2. Implement a distibuted variant of TextBoxLines.csv file