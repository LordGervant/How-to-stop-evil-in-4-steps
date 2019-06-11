using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour {

    public GameObject pipes;

    // Use this for initialization
    void Start () {
        InvokeRepeating("CreateObstacle", 2f, 3f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void CreateObstacle()
    {
        Instantiate(pipes);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" )
        {
            Destroy(this);
        }
    }
}
