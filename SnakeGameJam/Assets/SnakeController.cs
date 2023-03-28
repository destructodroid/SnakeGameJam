using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class SnakeController : MonoBehaviour
{ 
    bool ate = false;
    public GameObject tailPrefab;
    List<Transform> tail = new List<Transform>();
    Vector2 dir = Vector2.right;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Move", 0.1f,0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) && dir != Vector2.left)
        {
            dir = Vector2.right;
        }
            
        else if (Input.GetKey(KeyCode.DownArrow) && dir != Vector2.up)
        {
            dir = -Vector2.up;
        }
              
        else if (Input.GetKey(KeyCode.LeftArrow) && dir != Vector2.right)
        {
            dir = -Vector2.right;
        }
            
        else if (Input.GetKey(KeyCode.UpArrow) && dir != Vector2.down)
        {
            dir = Vector2.up;
        }
            
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag.Equals("Border") || collision.collider.tag.Equals("Snake")){
            SceneManager.LoadScene(2);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.name.StartsWith("FoodPrefab"))
        {
            ate = true;
            Destroy(collision.gameObject);
        }
    }
    void Move()
    {
        Vector2 v = transform.position;
        transform.Translate(dir);
        if (ate)
        {
            GameObject g = (GameObject)Instantiate(tailPrefab,v,Quaternion.identity);
            tail.Insert(0, g.transform);
            ate = false;
        }
        else if (tail.Count > 0)
        {
            // Move last Tail Element to where the Head was
            tail.Last().position = v;

            // Add to front of list, remove from the back
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }
}
