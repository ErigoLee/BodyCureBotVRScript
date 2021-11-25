using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonGenerator : MonoBehaviour
{
    [SerializeField] private GameObject balloon;
    private GameObject[] pointers;
    private List<GameObject> ballons;
    private List<GameObject> scars;
    [SerializeField] private EffectAudioManager effectAudioManager;

    void Start()
    {
        Setting();
    }
    public void Setting()
    {
        pointers = new GameObject[3];
        ballons = new List<GameObject>();
        scars = new List<GameObject>();
        pointers[0] = transform.GetChild(0).gameObject;
        pointers[1] = transform.GetChild(1).gameObject;
        pointers[2] = transform.GetChild(2).gameObject;
        GameObject ballon1 = Instantiate(balloon, pointers[0].transform.position,pointers[0].transform.rotation);
        GameObject ballon2 = Instantiate(balloon, pointers[1].transform.position, pointers[1].transform.rotation);
        GameObject ballon3 = Instantiate(balloon, pointers[2].transform.position, pointers[2].transform.rotation);
        ballons.Add(ballon1);
        ballons.Add(ballon2);
        ballons.Add(ballon3);
        GameObject[] scars_array = GameObject.FindGameObjectsWithTag("Scar");
        foreach(GameObject scar in scars_array)
        {
            scars.Add(scar);
        }
    }

    public void DeleteBalloon(GameObject _balloon, bool effectWork)
    {
        ballons.Remove(_balloon);
        if (effectWork)
        {
            effectAudioManager.ThrowEffect();
        }

        if (ballons.Count < 3)
        {
            bool[] position_exist = new bool[pointers.Length];
            position_exist[0] = false;
            position_exist[1] = false;
            position_exist[2] = false;

            foreach (GameObject ballon in ballons)
            {
                float min = 1000000000f;
                int index = -1;
                for (int i = 0; i < position_exist.Length; i++)
                {
                    float distance = Vector3.Distance(pointers[i].transform.position, ballon.transform.position);
                    if (min > distance && !position_exist[i])
                    {
                        min = distance;
                        index = i;
                    }

                }
                if (index == 0)
                    position_exist[index] = true;
                else if (index == 1)
                    position_exist[index] = true;
                else
                    position_exist[index] = true;
            }

            for (int i = 0; i < position_exist.Length; i++)
            {
                if (!position_exist[i])
                {
                    GameObject _balloon_ = Instantiate(balloon, pointers[i].transform.position, pointers[i].transform.rotation);
                    ballons.Add(_balloon_);
                }
            }
        }
    }
}
