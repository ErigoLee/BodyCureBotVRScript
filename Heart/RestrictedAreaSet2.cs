using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestrictedAreaSet2 : MonoBehaviour
{
    private float restricted_z_max;
    private float restricted_z_max_2;
    private float restricted_z_min;
    private float restricted_y_max;
    private float restricted_y_min;
    private float restricted_x_max;
    private float restricted_x_min;
    private bool expandZMax = false;
    void Start() //restricted
    {
        restricted_z_max = 46.0f;
        restricted_z_max_2 = 47.5f;
        restricted_z_min = -42.0f;
        restricted_y_max = 4.0f;
        restricted_y_min = -2.0f;
        restricted_x_max = 2.9f;
        restricted_x_min = -2.9f;

    }

    public void ExpandZMaxTurnOn()
    {
        expandZMax = true;
    }

    void Update()
    {
        Vector3 position = transform.localPosition;

        if (expandZMax)
        {
            if (position.z > restricted_z_max_2)
            {
                transform.localPosition = new Vector3(position.x, position.y, restricted_z_max);
            }
        }
        else
        {
            if (position.z > restricted_z_max)
            {
                transform.localPosition = new Vector3(position.x, position.y, restricted_z_max);
            }
        }
        

        if (position.z < restricted_z_min)
        {
            transform.localPosition = new Vector3(position.x, position.y, restricted_z_min);
        }

        if (position.x > restricted_x_max)
        {
            transform.localPosition = new Vector3(restricted_x_max, position.y, position.z);
        }

        if (position.x < restricted_x_min)
        {
            transform.localPosition = new Vector3(restricted_x_min, position.y, position.z);
        }

        if(position.y > restricted_y_max)
        {
            transform.localPosition = new Vector3(position.x, restricted_y_max, position.z);
        }

        if(position.y < restricted_y_min)
        {
            transform.localPosition = new Vector3(position.x, restricted_y_min, position.z);
        }
    }
}
