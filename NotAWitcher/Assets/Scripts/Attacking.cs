using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{

    public Transform attackPoint;
    public GameObject splashPrefab;

    public Animator anim;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //anim.SetBool("isAttacking", true);
            anim.SetTrigger("startAttack");

            Attack();
        }
        
    }

    void Attack()
    {
        GameObject splash = Instantiate(splashPrefab, attackPoint.position, attackPoint.rotation);
        Rigidbody2D rb = splash.GetComponent<Rigidbody2D>();
        Destroy(splash, 0.2f);
    }
}
