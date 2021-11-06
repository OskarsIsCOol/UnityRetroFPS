using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float shotdmg;
    public float dmg = 10f;
    public float range = 100f;
    public float fireRate = 1;
    public float impactForce = 30f;
    public AudioSource audiosrc;
    public AudioClip firesfx;
    public bool IsShotgun = false;
    public Camera fpsCam;
    private float nextTimeToFire = 0f;
    public Animator anim;
    public float waitTime = 1.0f;

    void Update()
    {
        //checks what is next time to fire(the fire-rate) and also plays sfx accordingly
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            audiosrc.PlayOneShot(firesfx);
            anim.SetBool("Shoot", true);
            Shoot();
        } 

        //is a shotgun? and random shotgun damage if it is.
        if (IsShotgun == true)
        {
            shotdmg = Random.Range(33, 68);
        }
    }

    void Shoot()
    {
        //debug for how much damage the shotgun did and raycasting stuff (of which i hate).
        Debug.Log(shotdmg);
        RaycastHit hit;
        StartCoroutine(endshoot());
       if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
       {
           Debug.Log(hit.transform.name);

           Target target = hit.transform.GetComponent<Target>();
           if (target != null)
           {
               target.TakeDamage(dmg);
           }

           if (hit.rigidbody != null)
           {
               hit.rigidbody.AddForce(-hit.normal * impactForce);
           }
       }
    }

    //delay and setting the "Shoot" bool false in order to end the shotgun animation.
    private IEnumerator endshoot()
    {
        yield return new WaitForSeconds(waitTime);
        anim.SetBool("Shoot", false);
    }
}
