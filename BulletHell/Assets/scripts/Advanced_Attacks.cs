﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Advanced_Attacks : Bullet {

    [SerializeField]
    Rigidbody2D bullet;
    [SerializeField]
    float m_BulletSpeed;
    [SerializeField]
    float m_FiringSpeed = 0.2f;

    Vector3 enemy_attackangle;
    Vector3 Direction;
    float m_Speed;
    float firingspeed;
    float timerl;
    float Timer;
    public override void Find_Target()
    {
        Target = GameObject.FindWithTag("Player");
        Debug.Log(Target);
    }

    public override void Bullet_Speed()
    {
        m_Speed = m_BulletSpeed;
    }
    public override void BulletFiringSpeed()
    {
        firingspeed = m_FiringSpeed;
    }



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Find_Target();
        Bullet_Speed();
        BulletFiringSpeed();


        if (Target != null)
        {

            //target_loc.position = target.transform.position;
            Direction = (Target.transform.position - transform.position).normalized;

            timerl += Time.deltaTime;
            Timer += Time.deltaTime;

            if (timerl >= 0.5f)
            {
                Direction.x -= 0.6f;
                for (float i = 0; i <= 20; i += 10)
                {
                    enemy_attackangle.y += i;
                    Rigidbody2D newProjectile = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody2D;
                    Direction.x += 0.3f;
                    newProjectile.AddForce(Direction * m_BulletSpeed);
                }




                timerl = 0;
            }

            if (Timer >= 3f)
            {

                for (float i = 0; i <= 30; i += 10)
                {
                    //enemy_attackangle.x -= i;
                    Rigidbody2D newProjectile = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody2D;
                    Direction.x -= 0.3f;
                    newProjectile.AddForce(Direction * m_BulletSpeed);
                }
                Timer = 0;

                Direction = (Target.transform.position - transform.position).normalized;


                for (float i = 0; i <= 30; i += 10)
                {
                    //enemy_attackangle.x -= i;
                    Rigidbody2D newProjectile = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody2D;
                    Direction.x += 0.3f;
                    newProjectile.AddForce(Direction * m_BulletSpeed);
                }
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player_Bullet")
        {
            Destroy(this.gameObject);
            //Destroy(collision.gameObject);
        }
    }
}
