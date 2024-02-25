using UnityEngine;
using System;

public class GhostController : MonoBehaviour{
    [SerializeField] private float speed = 0;
    public LayerMask wallLayer;
    private Transform target;

    private Rigidbody2D rb;

    public float rdist;

    void Start() {
        target = GameObject.Find("Player").gameObject.transform;
        rb = transform.GetComponent<Rigidbody2D>();
    }

    void Update() {
        Vector3 dir = target.position - transform.position;

        if(Math.Abs(dir.x) < .04) dir.x = 0;
        if(Math.Abs(dir.y) < .04) dir.y = 0;

        if(dir.x != 0f){
            RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(dir.x/Math.Abs(dir.x), 0f), rdist, wallLayer);
            if (hit.collider != null && hit.collider.CompareTag("Wall"))
                dir.x = 0f;
        }

        if(dir.y != 0f){
            RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(0f, dir.y/Math.Abs(dir.y)), rdist, wallLayer);
            if (hit.collider != null && hit.collider.CompareTag("Wall"))
                dir.y = 0f;
        }

        dir.Normalize();
        rb.velocity = dir*speed;
    }

    void OnCollisionStay(Collision col){
        Debug.Log("a");
        if(col.gameObject.CompareTag("Wall")){
            Vector3 dir = transform.position - col.gameObject.transform.position;
            dir.Normalize();
            dir = dir*.1f;
            transform.position = transform.position + dir;
        }
    }
}