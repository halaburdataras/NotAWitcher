using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    public Transform demoMenu;
    public Transform damageIndicator;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            this.gameObject.SetActive(false);
            damageIndicator.gameObject.SetActive(false);
            demoMenu.gameObject.SetActive(true);
        }
    }
}
