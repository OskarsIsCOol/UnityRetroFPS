using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float hp = 50f;
    public AudioSource audiosrc;
    public AudioClip hurtsfx;
    public int crntsprite = 0;
    public Sprite[] sprt;
    public SpriteRenderer sprtrender;
    public bool hurt = false;
    public float ls = 0.5f;
    
    //to render directions (the most optimized thing in this enemy script lol).
    public void Update()
    {
        for(int i = 0; i < sprt.Length; i++)
        {   
            if(crntsprite == i)
            {
	            sprtrender.sprite = sprt[i];
            }
        }
    }
    //rotational directions sprites for enemyrotation.cs
    public void R1()
    {
        crntsprite = 0;
    }
    public void R2()
    {
        crntsprite = 1;
    }
    public void R3()
    {
        crntsprite = 2;
    }
    public void R4()
    {
        crntsprite = 3;
    }
    public void R5()
    {
        crntsprite = 4;
    }
    public void R6()
    {
        crntsprite = 5;
    }
    public void R7()
    {
        crntsprite = 6;
    }
    public void R8()
    {
        crntsprite = 7;
    }
    //taking damage and playing sound accordingly.
    public void TakeDamage (float amount)
    {
        audiosrc.PlayOneShot(hurtsfx);
        crntsprite += 8;
        StartCoroutine(hurtie());
        hp -= amount;
        if (hp <= 0f)
        {
            Die();
        }
    }
    //dying
    void Die ()
    {
        Destroy(gameObject);
    }

    //hurt ienumerator (now better but like it sucks ass kinda because when you are on back of an enemy, it gets hurt and is +4 but then goes
    //back to -4 which sucks i guess and now i have to figure this shit out). >:(
    public IEnumerator hurtie()
    {
        yield return new WaitForSeconds(ls);
        crntsprite -= 8;
    }
}
