using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : MonoBehaviour
{
    [SerializeField] private GameObject firworkInstante;
    [SerializeField] private GameObject letterImage;
    [SerializeField] private GameObject letterText;
    private Vector3 fireworkPos;
    private Vector3 fireworkPos2;
    void Start()
    {
        StartCoroutine(letterForPlayer());
        fireworkPos = new Vector3(-2.0f, 3.0f, 3.0f);
        fireworkPos2 = new Vector3(2.0f,3.0f, 3.0f);
        Instantiate(firworkInstante,fireworkPos,Quaternion.Euler(new Vector3(0,0,0)));
        Instantiate(firworkInstante, fireworkPos2, Quaternion.Euler(new Vector3(0, 0, 0)));
        StartCoroutine(FireWorking());
    }

    IEnumerator FireWorking()
    {
        yield return new WaitForSeconds(3.0f);
        Instantiate(firworkInstante, fireworkPos, Quaternion.Euler(new Vector3(0, 0, 0)));
        Instantiate(firworkInstante, fireworkPos2, Quaternion.Euler(new Vector3(0, 0, 0)));
        StartCoroutine(FireWorking());
    }

    IEnumerator letterForPlayer()
    {
        letterImage.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        letterImage.SetActive(false);
        letterText.SetActive(true);
    }
}
