using UnityEngine;
using System;

public class GhostController : EnemyController{
    [SerializeField] private float speed = 0;
    public LayerMask wallLayer;
    private Transform target;

    private Rigidbody2D rb;
    private Animator anim;

    public float rdist;

    private GameManagerShit gm;

    public int damage = 50;

    private AudioSource asource;
    public AudioClip death;

    void Start() {
        rb = transform.GetComponent<Rigidbody2D>();
        anim = transform.GetComponent<Animator>();
        gm = GameObject.Find("GameManager").gameObject.GetComponent<GameManagerShit>();
        asource = GameObject.Find("audio").GetComponent<AudioSource>();

        Invoke("getTargetData", .1f);
    }

    void getTargetData(){
        target = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
    }
    private String[] anim_names = {"g_up", "g_top_right", "g_right", "g_down_right", "g_down", "g_down_left", "g_left", "g_top_left"};

    [SerializeField] bool in_frame = false;

    void Update() {
        if(target == null) return;
        if(in_frame){
            Vector3 dir = target.position - transform.position;
            if(Math.Abs(dir.x) < .25f) dir.x = 0;
            if(Math.Abs(dir.y) < .25f) dir.y = 0;

            int mdir = 5;
            if(dir.x != 0f){    
                if(dir.x < 0) mdir = 6;
                else mdir = 2;
                
                if(dir.y != 0f){
                    int m = 1;
                    if(dir.x > 0) m = -1;

                    if(dir.y < 0) mdir = mdir-1*m;
                    else mdir = mdir+1*m;
                }
            }else if(dir.y != 0f){    
                if(dir.y < 0) mdir = 4;
                else mdir = 0;
            }

            if(anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == anim_names[mdir]) mdir = -1;
            anim.SetInteger("mov_dir",mdir);

            

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
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Frame")){
            in_frame = true;
            gm.peeps_in_frame.Add(gameObject);
        }else if(other.CompareTag("Player")){
            target.gameObject.GetComponent<PlayerController>().addHorsePower(-damage);
            asource.Play();
            asource.clip = death;
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Frame")){
            in_frame = false;
            gm.peeps_in_frame.Remove(gameObject);
        }
    }
}