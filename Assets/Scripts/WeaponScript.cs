using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

    //1 переменные
    //префаб снаряда для стрельбы
    public Transform shotPrefab;
    //время перезарядки в секундах
    public float shootingRate = 0.25f;
    //2 перезарядка
    private float shootCooldown;

    void Start()
    {
        shootCooldown = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;

        }


    }

    //3 стрельба из другого скрипта
    public void Attack(bool isEnemy)
    {
        if (CanAttack)
        {
            shootCooldown = shootingRate;
            //создайте новый выстрел
            var shotTransfrom = Instantiate(shotPrefab) as Transform;
            //определите положение
            shotTransfrom.position = transform.position;
            //свойство врага
            ShotScript shot = shotTransfrom.gameObject.GetComponent<ShotScript>();
            if (shot != null)
            {
                shot.isEnemyShot = isEnemy;
            }
            //сделать так, чтобы выстрел всегда был направлен на него
            MoveScript move = shotTransfrom.gameObject.GetComponent<MoveScript>();
            if (move != null)
            {
                move.direction = this.transform.right;
            }
        }

    }

    //готово ли оружие выпустить снаряд
    public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0f;
        }
    }

}
