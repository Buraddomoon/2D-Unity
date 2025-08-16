using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Speed;
    private Rigidbody2D rig;
    public int Jumpforce;
    public bool pulando;
    public bool doublejump;
    private Animator anim;
    public int dashforce;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        jump();
    }

    void Move()
    {
        Vector3 walk = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += walk * Time.deltaTime * Speed;

        if (Input.GetAxis("Horizontal") > 0)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0,180,0);
        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            anim.SetBool("walk", false);
        }
    }
    void jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!pulando)
            {
                rig.AddForce(new Vector2(0, Jumpforce), ForceMode2D.Impulse);
                doublejump = true;
                anim.SetBool("jump", true);
                anim.SetBool("double jump", false);
            }
            else
            {
                if (doublejump)
                {
                    rig.AddForce(new Vector2(0, Jumpforce), ForceMode2D.Impulse);
                    anim.SetBool("double jump", true);
                    doublejump = false;
                }
            }
        }
    }
    //void dash()
    //{

    //    if (Input.GetKeyDown(KeyCode.LeftShift))
    //    {
    //        rig.AddForce(new Vector2(dashforce, 0), ForceMode2D.Impulse);

    //    }
    //}
        private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            pulando = false;
            anim.SetBool("jump", false);
            anim.SetBool("double jump", false);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            pulando = true;
        }
    }
}
