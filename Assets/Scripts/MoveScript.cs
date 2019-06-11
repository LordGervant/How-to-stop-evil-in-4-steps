using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour {

    // 1 переменные
    // скорость объекта
    public Vector2 speed = new Vector2(10, 0);

    //направление движения
    public Vector2 direction = new Vector2(-1, 0);

    private Vector2 movement;

    PlayerScript player = new PlayerScript();
    // Use this for initialization
    void Start () {
		
	}

    void Update()
    {
        //2 переменные 
         movement = new Vector2(
                speed.x * direction.x,
                speed.y * direction.y);
       


    }

    void FixedUpdate()
    {
        //применить движение к RigidBody 
        gameObject.GetComponent<Rigidbody2D>().velocity = movement;
    }

}
