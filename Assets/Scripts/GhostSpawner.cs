using Unity.Mathematics;
using UnityEngine;

public class GhostSpawner: SpawnerController{
    public GameObject ghost;
    public override void spawn(){
        int ix = UnityEngine.Random.Range(0, 4);
        if(spawning_spaces.Count > ix){ 
            Instantiate(ghost, spawning_spaces[ix].position, quaternion.identity);
            spawning_spaces.RemoveAt(ix);
        }

        Invoke("spawn", UnityEngine.Random.Range(time_min, time_max));
    }
}