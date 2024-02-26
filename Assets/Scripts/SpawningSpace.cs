using UnityEngine;

public class SpawningSpace: MonoBehaviour{
    private SpawnerController sc;
    int colcount = 0;

    void Start(){
        sc = transform.parent.gameObject.GetComponent<SpawnerController>();
        sc.spawning_spaces.Add(transform);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Frame")) return;

        colcount++;
        if(sc.spawning_spaces.Contains(transform))
            sc.spawning_spaces.Remove(transform);
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Frame")) return;

        colcount--;
        if(colcount == 0 && !sc.spawning_spaces.Contains(transform))
            sc.spawning_spaces.Add(transform);

    }
}