using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBronDetector : MonoBehaviour
{
    [SerializeField] private LungManager lungManager;

    void OnTriggerEnter(Collider other)
    {
        NewBronchial newBronchinal = other.gameObject.GetComponent<NewBronchial>();
        if(newBronchinal)
        {
            newBronchinal.Attaching();
            lungManager.EndStep4();
        }
    }
}
