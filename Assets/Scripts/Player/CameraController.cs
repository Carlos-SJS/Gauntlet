using UnityEngine;
using System;

public class CameraController : MonoBehaviour{
    [SerializeField] private Transform target;
    [SerializeField] private float min_x = -1000;
    [SerializeField] private float min_y = -1000;
    [SerializeField] private float max_x = 1000;
    [SerializeField] private float max_y = 1000;
    [SerializeField] private float offset_x = 3;



    void Start() {
        
    }

    void Update() {
        transform.position = new Vector3(
            Math.Max(Math.Min(target.position.x + offset_x, max_x), min_x), 
            Math.Max(Math.Min(target.position.y, max_y), min_y), -10
        );
    }
}