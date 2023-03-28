using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    public GameObject foodPrefab;

    public Transform border_top;
    public Transform border_bottom;
    public Transform border_left;
    public Transform border_right;

    // Start is called before the first frame update
    void Spawn()
    {
        int x = (int)Random.Range(border_left.position.x,
                              border_right.position.x);
        int y = (int)Random.Range(border_bottom.position.y,
                              border_top.position.y);
        Instantiate(foodPrefab,
                new Vector2(x, y),
                Quaternion.identity);
    }
    void Start()
    {
        InvokeRepeating("Spawn", 3, 4);
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}
}
