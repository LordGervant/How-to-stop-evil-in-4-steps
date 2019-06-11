using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

    //скорость
    public float maxSpeed = 10f;
    //сила прыжка
    public float jumpForce = 700f;
    //повернут вправо
    public bool facingRight = true;
    //на земля
    public bool grounded = false;

    public bool jumped = true;

    public bool fly = false;
    //проверка земли
    public Transform groundCheck;

    public float groundRadius = 0.2f;
    //что является землей
    public LayerMask whatIsGround;

    float SpawnX, SpawnY;

    //горючее
    public float gas;

    public float move;

    public Camera camera;

    private Animator animators;
    
    public GameObject ui;

    public GameObject boss = null;

    void Start()
    {
        SpawnX = transform.position.x;
        SpawnY = transform.position.y;
        animators = GetComponentInChildren<Animator>();
       
    }

   void Update()
    {
        //прыжок
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            if (grounded == true)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
                grounded = false;
                jumped = false;
                animators.SetBool("Grounded", false);
                animators.SetBool("Jumped", false);
            }
        
            
        }

        if (Input.GetKeyDown(KeyCode.Space) && (gas > 0))
        {

            GetComponent<Rigidbody2D>().velocity = new Vector2(7, 7);
            gas--;
            grounded = false;
            jumped = false;
            animators.SetBool("Grounded", false);
            animators.SetBool("Jumped", true);
            animators.SetBool("Fly", true);
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        //поворот
        if (move > 0 && facingRight)
        {
            Flip();

        }
        else if (move < 0 && !facingRight)
            Flip();

        //стрельба
        
        bool shoot = Input.GetButtonDown("Fire1");
        if ((shoot)&&(!facingRight)&&(move==0))
        {
            WeaponScript weapon = GetComponent<WeaponScript>();
            if (weapon != null)
            {
                //ложь, т.к. игрок не враг
                weapon.Attack(false);

                SoundController.Instance.MakePlayerShotSound();
            }

        }

        
        if ((ui.GetComponent<MenuScript>().pause == true)||(Input.GetKeyDown(KeyCode.Escape)))
        {
            ui.GetComponent<MenuScript>().Pause();
            
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
            ui.GetComponent<MenuScript>().Continue();
        
        if(transform.GetComponent<HealthScript>().hp <= 0)
        {
            ui.GetComponent<MenuScript>().GameOver();
            Time.timeScale = 0;
            Invoke("Replay", 0.5f);
        }

        if(boss.GetComponent<BossScript>().lose)
        {
            ui.GetComponent<MenuScript>().Victor();
        }
        
        
    }

    void FixedUpdate()
    {
        
        move = Input.GetAxis("Horizontal");
        animators.SetFloat("Moving", move);
        animators.SetBool("Grounded", grounded);
        animators.SetBool("Jumped", jumped);
        animators.SetBool("Fly", fly);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "EndLevel")
            Application.LoadLevel("Scene 2");
        if (collision.gameObject.name == "EndLevel1")
            Application.LoadLevel("Scene 3");
        if (collision.gameObject.name == "EndLevel2")
            Application.LoadLevel("Scene 4");
        if (collision.gameObject.name == "Pipe1" || collision.gameObject.name == "Pipe2")
        {
            ui.GetComponent<MenuScript>().GameOver();
            Invoke("Replay", 0.5f);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            jumped = true;
        }
        bool damagePlayer = false;
        //столкновение с врагом
        EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
        if (enemy != null)
        {
            //смерть врага
            HealthScript enemyHealth = enemy.GetComponent<HealthScript>();
            damagePlayer = true;
            //повреждение у игрока
            if (damagePlayer)
            {
                HealthScript playerHealth = this.GetComponent<HealthScript>();
                if (playerHealth != null)
                {
                    playerHealth.Damage(playerHealth.hp);
                    
                }
            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "fuel")&&(gas<8))
        {
            Destroy(collision.gameObject);
            gas += 2;
            
        }
        if (collision.gameObject.name == "Camera1")
        {
            camera.orthographicSize = 5.580537f;
             camera.transform.position = new Vector3(7.04f, -1.45f, -10);
        }
        if (collision.gameObject.name == "Camera")
        {
            camera.transform.position = new Vector3(-9.75f, -2.01f, -10);
           
        }
        if (collision.gameObject.name == "Death")
            ui.GetComponent<MenuScript>().GameOver();

        if (collision.gameObject.tag == "health")
        {
            transform.gameObject.GetComponent<HealthScript>().hp += 5;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "shield")
        {
            transform.gameObject.GetComponent<HealthScript>().shield += 5;
            Destroy(collision.gameObject);
        }
    }

    void GameOver()
    {

    }
}
