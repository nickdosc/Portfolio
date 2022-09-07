using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_0Help : MonoBehaviour
{
    public Dialogue diag;
    public Animator TipAnim;
    public Text TipText;
    public Text ObjectiveText;

    bool looponce;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (!looponce)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(diag);
            GameObject.Find("Player").GetComponent<Animator>().enabled = false;
            FindObjectOfType<PlayerCharacter>().enabled = false;
            looponce = true;
        }
        if (FindObjectOfType<DialogueManager>().isDone && looponce)
        {
   
            StartCoroutine(ExecuteAfterTime(0.5f));

        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay

        FindObjectOfType<PlayerCharacter>().enabled = true;
        GameObject.Find("Player").GetComponent<Animator>().enabled = true;
        TipAnim.SetBool("IsOpen", true);
        TipText.text = "You can use TAB to see the current objectve!";
        ObjectiveText.text = "Find your Sword!";
        Destroy(gameObject);

    }
}
