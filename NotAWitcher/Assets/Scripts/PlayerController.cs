using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;

    public Rigidbody2D rb;
    public Camera cam;
    public Animator anim;

    Vector2 movement;
    Vector2 mousePos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Debug.Log("Add player");
        Debug.Log("Add dash(jump or shift)");
        Debug.Log("Add mouse input");

        Debug.Log("Add player level");
        Debug.Log("Add map");
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x != 0f || movement.y != 0f)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

}
