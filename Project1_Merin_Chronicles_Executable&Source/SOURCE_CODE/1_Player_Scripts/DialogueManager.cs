using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText; // Text placeholder UI element for the talking character's name.
    public Text dialogueText; // The sentences will be displayed with this UI element.


    public Animator anim; // The animator of Dialogue.

    public bool isDone; // Check if the dialogue is done / All sentences displayed and read.


    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();

    }

    //Is called to initiate the dialogue
    //Give the UI elements the corresponding text so the dialogue can commence.
    public void StartDialogue (Dialogue dialogue)
    {
        //Debug.Log("Start Convo with" + dialogue.name);
        anim.SetBool("IsOpen", true);
        isDone = false;

        nameText.text = dialogue.name;

        sentences.Clear();


        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();


    }

    //Used to display the next sentence or finish the dialogue depending on character's Sentence array.
    public void DisplayNextSentence()
    {
         if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
       /// audioSelect.clip = nextsound;
       // audioSelect.Play();
        string sentence = sentences.Dequeue();
        // Debug.Log(sentence);
        //dialogueText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));


    }

    //Types the sentence so a typing effect is achieved.
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        anim.SetBool("IsOpen", false);
        isDone = true;
       // Debug.Log("End of Convo");
    }
   
  
}
