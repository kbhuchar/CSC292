﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
         
        EnemyScript enemy = hitInfo.GetComponent<EnemyScript>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        CorrectAnswerScript answer = hitInfo.GetComponent<CorrectAnswerScript>();
        if (answer != null)
        {
            answer.TakeDamage(damage);
        }

        IncorrectAnswerScript IncorrectAnswer = hitInfo.GetComponent<IncorrectAnswerScript>();
        if (IncorrectAnswer != null)
        {
            IncorrectAnswer.TakeDamage(damage);
        }

        Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }

}
