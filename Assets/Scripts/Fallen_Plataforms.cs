using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallen_Plataforms : MonoBehaviour
{
    public float fallentime;
    public BoxCollider2D box;
    public TargetJoint2D target;

    private void Start()
    {
        target = GetComponent<TargetJoint2D>();
        box = GetComponent<BoxCollider2D>();
    }
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("falling", fallentime);
        }
    }
    void falling()
    {
        target.enabled = false;
        box.isTrigger = true;
    }
}
