using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour {

    public Sprite boss;

    public GameObject player;

    private WeaponScript[] weapons;

    private MoveScript moveScript;

    private Animator animator;

    public int n;
    public int m;

    public int k;

    public bool facingRight;

    public bool change;

    public bool shoot;

    public float ShowTime;
    public int counter;

    public bool lose;

    public bool isFacingRight = false;

    bool hasSpawn;



    void Awake()
    {
        //получить оружие только 1 раз
        weapons = GetComponentsInChildren<WeaponScript>();

        //отключить скрипты, чтобы деактивировать объекты при отсутствии спавна
        moveScript = GetComponent<MoveScript>();
    }

    // Use this for initialization
    void Start () {

        facingRight = false;

        change = false;

        m = Random.Range(1, 3);
        n = Random.Range(1, 3);

        k = 0;

        ShowTime = 0f;

        counter = 5;
        shoot = false;

        hasSpawn = false;

        //Отключить
        //--коллайдеры
        GetComponent<Collider2D>().enabled = true;
        //--Стрельбу
        foreach (WeaponScript weapon in weapons)
        {
            weapon.enabled = false;
        }

        animator = GetComponentInChildren<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

       if (GetComponent<Renderer>().isVisible)
        {
            Invoke("Change", 4);
            Invoke("Weapon", 4);
           
        }
       if(transform.GetComponent<HealthScript>().hp <= 0)
        {
            transform.GetComponent<BoxCollider2D>().size = new Vector2(0.3731825f, 0.0783417f);
            lose = true;
        }
	}

    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
    }

    void Change()
    {
        animator.SetBool("Turn", true);
        animator.SetBool("Turn", true);
        transform.GetComponent<SpriteRenderer>().sprite = boss;
        transform.GetComponent<BoxCollider2D>().size = new Vector2(0.2819464f, 0.4375088f);
        change = true;
        shoot = true;
        transform.GetComponent<HealthScript>().hp = 1000;
        
    }

    private void Spawn()
    {
        hasSpawn = true;

        //Включить все
        //--коллайдеры
        GetComponent<Collider2D>().enabled = true;
        //--стрельбу
        foreach (WeaponScript weapon in weapons)
        {
            weapon.enabled = true;
        }
     }

    private void Weapon()
    {
        if (hasSpawn == false)
        {
            if (GetComponent<Renderer>().isVisible)
            {

                Invoke("Spawn", 0.5f);
            }
        }
        else
        {
            //автоматическая стрельба
            foreach (WeaponScript weapon in weapons)
            {
                if (weapon != null && weapon.enabled && weapon.CanAttack)
                {
                    weapon.Attack(true);
                    SoundController.Instance.MakeEnemyShotSound();
                }
            }
        }
    }
}
