using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public Sprite profile;
    public string[] speechtext;
    public string actiorname;
    public float radius;
    bool onradius;

    public LayerMask playerlayer;
    private DialogueControl dc;
    private void FixedUpdate()
    {
        interact();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&& onradius==true)
        {
            dc.speech(profile, speechtext, actiorname);
        }
        else
        {

        }
    }
    private void Start()
    {

        dc = FindObjectOfType<DialogueControl>();
    }
    private void interact()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, playerlayer);

        if (hit != null)
        {
            onradius = true;
        }
        else
        {
            onradius= false;
        }
    }
}
