using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public bool MultiDiag;
    public Image SpriteImage;
    public AudioSource audioSelect;
    public AudioClip nextsound;

    public Animator anim;

    public bool isDone;

    private bool first;


    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();

    }

    public void StartDialogue (Dialogue dialogue)
    {
        //Debug.Log("Start Convo with" + dialogue.name);
        anim.SetBool("IsOpen", true);
        isDone = false;

        nameText.text = dialogue.name;
        SpriteImage.sprite = dialogue.TalkerImage;

        sentences.Clear();


        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();


    }

    public void DisplayNextSentence()
    {
         if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        if(first){
        audioSelect.clip = nextsound;
        audioSelect.loop = false;
        audioSelect.Play();
        }
        string sentence = sentences.Dequeue();
        // Debug.Log(sentence);
        //dialogueText.text = sentence;
        StopAllCoroutines();
        first = true;
        StartCoroutine(TypeSentence(sentence));


    }

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
        if(!MultiDiag){
        anim.SetBool("IsOpen", false);
        }
        isDone = true;
       // Debug.Log("End of Convo");
    }
   
  
}
