using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferScript : MonoBehaviour {
    public GameObject target;
    public bool onoff;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(!onoff)
            if(collision.tag == "Player")
            {
                target.GetComponent<TransferScript>().onoff = true;
                collision.gameObject.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, 0);

            }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            onoff = false;
    }

}
