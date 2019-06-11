using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    private MoveScript moveScript;
    private WeaponScript[] weapons;
    bool hasSpawn;
    private Animator animator;


    void Awake()
    {
        //получить оружие только 1 раз
        weapons = GetComponentsInChildren<WeaponScript>();
       
        //отключить скрипты, чтобы деактивировать объекты при отсутствии спавна
        moveScript = GetComponent<MoveScript>();
    }

    //Отключить всех врагов
    void Start()
    {
        hasSpawn = false;

        //Отключить
        //--коллайдеры
        GetComponent<Collider2D>().enabled = false;
        //--перемещение
        GetComponent<MoveScript>().enabled = false;
        //--Стрельбу
        foreach(WeaponScript weapon in weapons)
        {
            weapon.enabled = false;
        }
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //2 Проверка спавна врагов
        if(hasSpawn == false)
        {
            if(GetComponent<Renderer>().isVisible)
            {
                
                Invoke("Spawn", 0.5f);
            }
        }
        else
        {
            //автоматическая стрельба
            foreach(WeaponScript weapon in weapons)
            {
                if(weapon!=null && weapon.enabled && weapon.CanAttack)
                {
                    weapon.Attack(true);
                    SoundController.Instance.MakeEnemyShotSound();
                }
            }
        }
        
    }

    //3 - Самоактивация
    private void Spawn()
    {
        hasSpawn = true;

        //Включить все
        //--коллайдеры
        GetComponent<Collider2D>().enabled = true;
        //--перемещение
        GetComponent<MoveScript>().enabled = true;
        //--стрельбу
        foreach(WeaponScript weapon in weapons)
        {
            weapon.enabled = true;
        }
        animator.SetBool("Move", true);
    }
}

