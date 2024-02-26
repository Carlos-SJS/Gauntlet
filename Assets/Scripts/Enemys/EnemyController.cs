using System;
using UnityEngine;

public class EnemyController: MonoBehaviour{
    public int hp = 0;
    public int score_value = 0;
    

    public int hit(int v){
        hp = Math.Max(hp-v, 0);

        if(hp == 0){
            Destroy(gameObject);
            return score_value;
        }
        return 0;
    }
}