using UnityEngine;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour{

    [SerializeField] private float color_speed = .01f;
    [SerializeField] private Image logo_fill;
    private int cstate = 0;

    void Start() {
        logo_fill.color = new Color(0,0,0);
    }

    void Update() {
        colorUpdate();
    }

    void colorUpdate(){
        if(cstate == 0){
            Color c = logo_fill.color;
            c.r = Math.Min(c.r + color_speed*Time.deltaTime, 1.0f);
            logo_fill.color = c;

            if(c.r == 1) cstate = 2;
        }else if(cstate == 1){
            Color c = logo_fill.color;
            c.b = Math.Min(c.b + color_speed*Time.deltaTime, 1.0f);
            logo_fill.color = c;

            if(c.b == 1) cstate = 3;
        }else{
            Color c = logo_fill.color;
            c.r = Math.Max(c.r - color_speed*Time.deltaTime, 0f);
            c.b = Math.Max(c.b - color_speed*Time.deltaTime, 0f);
            logo_fill.color = c;

            if(c.r == 0 && cstate == 2) cstate = 1;
            else if(c.b == 0 && cstate == 3) cstate = 0;
        }
    }
}