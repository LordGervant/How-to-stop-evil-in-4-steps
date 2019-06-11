using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour {

    //всего здоровья
    public int hp = 1;
    //щит
    public int shield = 0;

    //враг или игрок
    public bool isEnemy = true;
    private Animator animator;

    // наносим урон и проверяем должен ли объект быть уничтожен
   
    // Use this for initialization
    void Start () {
        animator = GetComponentInChildren<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Damage(int DamageCount)
    {
        if (shield >= 0)
            shield -= DamageCount;
        else 
        {
            hp -= DamageCount;

            if (hp <= 0)
            {
                SoundController.Instance.MakeExplosionSound();
                Invoke("Destroy", 0.9f);
                shield = 0;
                animator.SetBool("Death", true);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //это выстрел?
        ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();

        if (shot != null)
        {
            //Избегайте дружетсвенного огня
            if (shot.isEnemyShot != isEnemy)
            {
                Damage(shot.damage);
                //уничтожить выстрел
                Destroy(shot.gameObject);
            }
        }
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
