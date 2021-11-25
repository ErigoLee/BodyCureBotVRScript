using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureAction : MonoBehaviour
{
    public float speed = 1.0f;

    public GameObject player;
    public GameObject centerCam;

    private Vector3 centerCamDir;

    private bool defenceStart;

    private bool tutoNotGoing;

    void Start()
    {
        defenceStart = false;
    }

    public void TutoNotGoingTurnOn()
    {
        tutoNotGoing = true;
    }

    public void TutoNotGoingTurnOff()
    {
        tutoNotGoing = false;
    }

    public void GoStraight()
    {
        if(!tutoNotGoing)
        {
            centerCamDir = centerCam.transform.forward;
            centerCamDir.y = 0;
            centerCamDir.Normalize();

            player.transform.Translate(centerCamDir * speed * Time.deltaTime);
        }

    }

    public void GoBack()
    {
        if(!tutoNotGoing)
        {
            centerCamDir = -centerCam.transform.forward;
            centerCamDir.y = 0;
            centerCamDir.Normalize();

            player.transform.Translate(centerCamDir * speed * Time.deltaTime);
        }
        
    }


    public void DefenceTurnOn()
    {
        defenceStart = true;
    }

    public void DefenceTurnOff()
    {
        defenceStart = false;
    }

    public void AttackAction(string handName)
    {

        if(defenceStart)
        {
            if (handName.Equals("leftHand"))
            {
                Player player = this.player.GetComponent<Player>();
                if (player != null)
                {
                    player.chargeLeftBullet();
                }
            }

            if (handName.Equals("rightHand"))
            {
                Player player = this.player.GetComponent<Player>();
                if (player != null)
                {
                    player.chargeRightBullet();
                }
            }
        }
        else
        {
            return;
        }

    }
}
