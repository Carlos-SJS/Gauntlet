using UnityEngine;
using System.Collections.Generic;

public class GameManagerShit: MonoBehaviour{
    public List<GameObject> peeps_in_frame = new List<GameObject>();

    public void popPotion(){
        while(peeps_in_frame.Count > 0) Destroy(peeps_in_frame[0]);
    }
}