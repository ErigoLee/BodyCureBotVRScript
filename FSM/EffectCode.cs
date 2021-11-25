using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectCode : MonoBehaviour
{
    private float life;
    void Start()
    {
        life = 0.3f;
        Destroy(gameObject, life);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
