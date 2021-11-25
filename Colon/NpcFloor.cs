using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcFloor : MonoBehaviour
{
    private GameObject npc;
    // Start is called before the first frame update
    void Start()
    {
        npc = GameObject.FindGameObjectWithTag("NPC");

    }

    // Update is called once per frame
    void Update()
    {
        FloorUp();
    }

    public void FloorUp()
    {
        if((npc.transform.position.y-gameObject.transform.position.y)>0.4f)
        {
            if(gameObject.transform.position.y<9.5f)
            {
                gameObject.transform.position = new Vector3(0, (float)(npc.transform.position.y - 0.4), -11.05f);
            }
        }
    }
}
