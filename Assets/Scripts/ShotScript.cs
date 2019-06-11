using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour {

    // причиненный вред
    public int damage = 1;
    //снаряд наносит повреждение игроку или врагам
    public bool isEnemyShot = false;

    void Start()
    {
        //ограниченное время жизни, чтобы избежать утечек
        Destroy(gameObject, 8);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
