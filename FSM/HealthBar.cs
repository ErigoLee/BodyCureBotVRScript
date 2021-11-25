using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image HealthState;
    public float CurrentHealth;
    private float MaxHealth = 100f;
    [SerializeField] private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        HealthState = GetComponent<Image>();
        //player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealth = (float)player.GetComponent<Player>().health;
        HealthState.fillAmount = CurrentHealth / MaxHealth;
    }
}
