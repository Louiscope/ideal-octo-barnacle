using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movespd = 6f;
    public float drag = 6f;
    public float movementmultiplier = 10f;
    float verticalmov;
    float horizontalmov;
    Vector3 movedirection;

    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }


    private void Update()
    {
        input();
        dragcontrol();
    }

    private void dragcontrol()
    {
        rb.drag = drag;
    }

    void input()
    {
        horizontalmov = Input.GetAxisRaw("Horizontal");
        verticalmov = Input.GetAxisRaw("Vertical");

        movedirection = transform.forward * verticalmov + transform.right * horizontalmov;

    }

    private void FixedUpdate()
    {
        moveplayer();
    }

    void moveplayer()
    {
        rb.AddForce(movedirection.normalized * movespd * movementmultiplier, ForceMode.Acceleration);
    }
}
