using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBirdScript : MonoBehaviour {

    public float spd = 5f;

    void Start()
    {
        
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {

            GetComponent<Rigidbody2D>().velocity = new Vector2(5, spd);
        }
    }
}
