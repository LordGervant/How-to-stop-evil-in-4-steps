using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesScript : MonoBehaviour {

    public Vector2 velocity = new Vector2(-4, 0);

    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = velocity;
        transform.position = new Vector3(transform.position.x, transform.position.y - Random.Range(10f,12f), transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
 }
