using UnityEngine;
using System;

public class PlayerController : MonoBehaviour{
    [SerializeField] private float speed = 0;

    private Rigidbody2D rb;

    void Start() {
        rb = transform.GetComponent<Rigidbody2D>();
    }

    void Update() {
        Vector3 dir = new Vector3(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"), 0);
        dir.Normalize();
        rb.velocity = dir*speed;
    }
}