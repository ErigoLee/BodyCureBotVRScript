using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{

    //private GameObject[] Enemys;
    private float LifeTime = 3.0f;
    public float Speed = 100.0f;

    public GameObject explosionEffect;

    private EffectAudioManager effectAudioManager;
    void Start()
    {
        Destroy(gameObject, LifeTime);
        //Enemys = GameObject.FindGameObjectsWithTag("Enemy");

    }

    public void SetForward(Vector3 setforward)
    {
        transform.forward = setforward;
        
    }

    public void SetEffectAudioManager(EffectAudioManager _effectAudioManager)
    {
        effectAudioManager = _effectAudioManager;
    }
    
    void Update()
    {
        transform.position +=  transform.forward * Speed * Time.deltaTime;
        
        
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        print("detected!");
        
        if (other.gameObject.tag == "Enemy")
        {
            GameObject effect = Instantiate(explosionEffect, transform.position, transform.rotation);
            other.gameObject.GetComponent<NpcFSM>().Attacked();
            effectAudioManager.HitMonsterEffect();
            Debug.Log("Attack! Enemy!!");
            Destroy(effect, 1.0f);
            Destroy(gameObject);
            
        }

    }
}
