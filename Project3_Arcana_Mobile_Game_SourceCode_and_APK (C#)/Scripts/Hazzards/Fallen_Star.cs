using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fallen_Star : MonoBehaviour
{
    public Transform meteorTransform;
    Vector2 StartPosition;
    Vector2 SelectedPoint;
    Vector2 extraSpace = new Vector2(0, 15);
    Vector2 removalSpace = new Vector2(0, 30);
    public int RandomSelection;
    public float speed = 3f;
    

    // Start is called before the first frame update
    void Start()
    {
        SpawnSelection();
       
        StartPosition = SelectedPoint;
        meteorTransform.localPosition = SelectedPoint + extraSpace;
        



    }

    void Update()
    {
        meteorTransform.localPosition = Vector2.MoveTowards(meteorTransform.localPosition, (StartPosition-removalSpace), speed * Time.deltaTime);
        SelectedPoint = meteorTransform.localPosition;
        if ((StartPosition-removalSpace) == (SelectedPoint))
        {
            Object.Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameObject.Find("Player").GetComponent<Player_Script>().gameover = true;
            Time.timeScale = 0;

            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

    private void SpawnSelection()
    {
        RandomSelection = Random.Range(1, 6);
        SelectedPoint = GameObject.Find("Player").transform.localPosition + GameObject.Find("SpawnPoint"+RandomSelection).transform.localPosition;



    }
   
}
