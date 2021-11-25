using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationObject : MonoBehaviour
{
    [SerializeField] private bool throwingObject;
    private Vector3 position;
    private Vector3 initialPosition;
    private bool checking = false;
    void Start()
    {
        checking = false;
        initialPosition = transform.localPosition;
    }

    IEnumerator CheckingLoading()
    {
        yield return new WaitForSeconds(1.5f);
        checking = false;
        transform.localPosition = initialPosition;
    }

    void Update()
    {
        position = transform.localPosition;
        if (throwingObject)
        {
            if (position.y < 0.3f)
            {
                if (!checking)
                {
                    checking = true;
                    StartCoroutine(CheckingLoading());
                }
            }
            
        }
        else
        {
            
            if (position.y < 0.3f)
            {
                transform.localPosition = initialPosition;
            }
        }
    }
}
