using UnityEngine;

public class HammerController: MonoBehaviour{
    public System.Action onDestroy;
    public Sprite[] sprites;
    public Sprite hit_sprite;
    public float speed = 5f;
    public Vector3 dir;

    private Rigidbody2D rb;

    public PlayerController pc;

    public int damage = 100;

    private bool alive = true;

    void Start(){
        rb = gameObject.GetComponent<Rigidbody2D>();
        int ix = 0;
        if(dir.x != 0){
            if(dir.x < 0) ix = 6;
            else ix = 2;

            if(dir.y != 0){
                if(dir.y < 0) ix--;
                else ix++;
            }
        }else{
            if(dir.y > 0) ix = 0;
            else ix = 4;
        }

        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[ix];
    }

    void Update(){
        if(alive)
            rb.velocity = dir * speed;
    }

    void destroySelf(){
        gameObject.GetComponent<SpriteRenderer>().sprite = hit_sprite;
        alive = false;
        rb.velocity = Vector3.zero;
        Invoke("actuallyDestroy", .07f);
    }

    void actuallyDestroy(){
        onDestroy?.Invoke();
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player") || other.CompareTag("Frame") || other.CompareTag("SpawningSpace")) return;

        if(other.CompareTag("Enemy")){
            pc.addScore(other.gameObject.GetComponent<EnemyController>().hit(damage));
        }else if(other.CompareTag("Spawner")){
            other.gameObject.GetComponent<SpawnerController>().hit(damage);
        }

        destroySelf();
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Frame")){
            destroySelf();
        }
    }
}
