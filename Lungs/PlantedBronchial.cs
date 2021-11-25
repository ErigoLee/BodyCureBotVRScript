using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantedBronchial : MonoBehaviour
{
    [SerializeField] private GameObject recoverTrigger;
    public void RecoverTriggerTurnOn()
    {
        recoverTrigger.SetActive(true);
    }
}    
