﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public string enemyTag = "Enemy";
    public float damage = 100f;
    public float bulletVelocity = 20f;
    private Transform target;
    private bool firstStep = true;
    

    public void Target (Transform tgt)
    {
        target = tgt;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == enemyTag)
        {
            /// this.enabled = !this.enabled;
            Destroy(gameObject);
        }
    }



    private void Update()
    {
        if (target == null || transform.position.y < -3.40)
        {
            Destroy(gameObject);
            return;
        }

       

        if (true) //de momento que sean un poco teleridigidos
        {
            //Obtenemos la dirección de movimiento de la bala
            Vector3 dir = target.position - transform.position;
            //Velocidad Real = Velocidad Base * Tiempo
            float dTF = bulletVelocity * Time.deltaTime;
            //Efectua el movimiento de la bala
            transform.Translate(dir.normalized * dTF, Space.World);

            firstStep = false;
        }
    }
}
