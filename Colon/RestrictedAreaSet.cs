using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestrictedAreaSet : MonoBehaviour
{
    
    private float restricted_z_max;
    private float restricted_z_min;
    private float restricted_z_min_2;
    private float restricted_z_min_3;
    private float restricted_x_max;
    private float restricted_x_min;

    private bool stage2;
    private bool stage3;
    void Start() //restricted
    {
        restricted_z_max = 8.3f;
        restricted_z_min = -19.3f;
        restricted_z_min_2 = -4.5f;
        restricted_z_min_3 = -11.0f;
        restricted_x_max = 1.5f;
        restricted_x_min = -1.5f;
        stage3 = false;
        stage2 = false;
    }

    public void Stage2TurnOn()
    {
        stage2 = true;
    }

    public void Stage2TurnOff()
    {
        stage2 = false;
    }


    public void Stage3TurnOn()
    {
        stage3 = true;
    }

    public void Stage3TurnOff()
    {
        stage3 = false;
    }
    
    void Update()
    {
        Vector3 position = transform.localPosition;

        if (stage3)
        {
            if (position.z < restricted_z_min_3)
            {
                transform.localPosition = new Vector3(position.x, position.y, restricted_z_min_3);
            }
        }
        else
        {
            
            if(stage2)
            {
                if(position.z < restricted_z_min_2)
                {
                    transform.localPosition = new Vector3(position.x, position.y, restricted_z_min_2);
                }
            }
            else
            {
                if (position.z < restricted_z_min)
                {
                    transform.localPosition = new Vector3(position.x, position.y, restricted_z_min);
                }
            }   
        }
        
        
        
        if (position.z > restricted_z_max)
        {
            transform.localPosition = new Vector3(position.x, position.y, restricted_z_max);
        }
       
        

        if(position.x > restricted_x_max)
        {
            transform.localPosition = new Vector3(restricted_x_max,position.y,position.z);
        }

        if(position.x < restricted_x_min)
        {
            transform.localPosition = new Vector3(restricted_x_min,position.y,position.z);
        }
    }

    

    
}
