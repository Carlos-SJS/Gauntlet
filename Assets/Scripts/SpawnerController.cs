using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class SpawnerController: MonoBehaviour{
    public List<Transform> spawning_spaces;
    public float time_min = .8f;
    public float time_max = 4f;

    public Sprite[] states;
    private SpriteRenderer sr;
    private int state = 0;
    void Start(){
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.sprite = states[0];
        Invoke("spawn", UnityEngine.Random.Range(time_min, time_max));
    } 

    public void hit(int dmg){
        state++;
        if(state >= states.Length) Destroy(gameObject);
        else sr.sprite = states[state];

    }

    public abstract void spawn();
}