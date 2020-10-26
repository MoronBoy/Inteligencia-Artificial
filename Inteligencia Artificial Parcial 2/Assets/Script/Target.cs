using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public delegate void EnemyKilled();
    public static event EnemyKilled OnEnemyKilled;

    public float health = 100f;
    void Start()
    {
        //setRigidbodyState(true);
        //setColliderState(false);
        //GetComponent<Animator>().enabled = true;
    }


    public void TakeDamage(float amount)
    {
        health -= amount;
        Debug.Log(health,this);
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        //GetComponent<Animator>().enabled = false;
        //setRigidbodyState(false);
        //setColliderState(true);
        Destroy(gameObject);// agregar timer en caso de usar enemigos con ragdoll
        if (OnEnemyKilled != null)
        {
            OnEnemyKilled();
        }
    }
   /* void setRigidbodyState(bool state)
    {

        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = state;
        }

        GetComponent<Rigidbody>().isKinematic = !state;

    }


    void setColliderState(bool state)
    {

        Collider[] colliders = GetComponentsInChildren<Collider>();

        foreach (Collider collider in colliders)
        {
            collider.enabled = state;
        }

        GetComponent<Collider>().enabled = !state;

    }*/
}
