using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneTransfer : MonoBehaviour
{
    [SerializeField] private Image panel;
    [SerializeField] private TotalManager totalManager;
    int stage = 0;
    private Color color;
    private bool fadeIn;
    private bool fadeOut;
    private GameObject GR;
    void Start()
    {
        GR = GameObject.FindGameObjectWithTag("GR");
        color = panel.color;
        color.a = 0.0f;
        panel.color = color;
        fadeIn = false;
        fadeOut = false;
    }
    public void FadeInTurnOn(int _stage)
    {
        stage = _stage;
        GR.GetComponent<GestureRecongizedLeft>().enabled = false;
        GR.GetComponent<GestureRecongizedRight>().enabled = false;
        fadeIn = true;
    }

    IEnumerator Interval()
    {
        switch (stage)
        {
            case -2:
                totalManager.ScreenEnd();
                break;
            case -1:
                totalManager.TutoEnd();
                break;
            case 0:
                totalManager.DecoEnd();
                break;
            case 1:
                totalManager.LungEnd();
                break;
            case 2:
                totalManager.PreHeartEnd();
                break;
            case 3:
                totalManager.HeartEnd();
                break;
            case 4:
                totalManager.PreColonEnd();
                break;
            case 5:
                totalManager.ColonEnd();
                break;
        }
        yield return new WaitForSeconds(1.0f);
        fadeOut = true;
    }

    void Update()
    {
        if (fadeIn)
        {
            color.a += (Time.deltaTime / 2);
            panel.color = color;
            if (color.a > 0.9f)
            {
                fadeIn = false;
                color.a = 1.0f;
                panel.color = color;
                StartCoroutine(Interval());
            }
        }

        if (fadeOut)
        {
            color.a -= (Time.deltaTime / 2);
            panel.color = color;
            if (color.a < 0.1f)
            {
                GR.GetComponent<GestureRecongizedLeft>().enabled = true;
                GR.GetComponent<GestureRecongizedRight>().enabled = true;
                fadeOut = false;
                color.a = 0.0f;
                panel.color = color;
            }
        }
    }
}
