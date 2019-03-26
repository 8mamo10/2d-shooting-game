using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgrounds : MonoBehaviour
{
    public float speed = 0.1f;
    void Update()
    {
        float y = Mathf.Repeat(Time.time * speed, 1)        ;
    }
}
