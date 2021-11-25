using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 0.05f;
    public float LifeTime = 3.0f;
    public int npcStage = 1;
    GameObject[] enemys;


    void Start()
    {
        Destroy(gameObject,LifeTime);
        

    }

    
    void Update()
    {
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemys)
        {
            Collider enemyCollider = enemy.GetComponent<Collider>();
            Collider bulletCollider = GetComponent<Collider>();
            Physics.IgnoreCollision(enemyCollider, bulletCollider, true);
        }
        
        transform.forward.Normalize();
        transform.position += transform.forward * Speed * Time.deltaTime;
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Attack! Player!!");
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (npcStage == 3)
            {
                player.GetComponent<Player>().TurnOnBlur();
            }
            player.GetComponent<Player>().Attacked();
            Destroy(gameObject);
        }

    }
}
