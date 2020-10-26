using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public float damage = 30f;
    public float range = 100f;
    public float impactForce = 50f;

    public Camera fpsCam;
    public ParticleSystem muzzleFash;
    public GameObject impactEffect;
    public LayerMask targetLayers;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("pium pium!");
            Shoot();
        }

        void Shoot()
        {
           //Debug.Log("Shot");
            muzzleFash.Play();
            RaycastHit hit;
            if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward,out hit, range, targetLayers))
            {
                //Debug.Log("Choque!");
                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    Debug.Log(hit.transform.name);
                    target.TakeDamage(damage);
                }
                if(hit.rigidbody != null)
                {
                    //Debug.Log("Alta fuerza loco");
                    hit.rigidbody.AddForce(-hit.normal * impactForce);
                }
            }
            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
}