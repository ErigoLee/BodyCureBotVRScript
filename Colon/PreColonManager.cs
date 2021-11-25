using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreColonManager : MonoBehaviour
{
    [SerializeField] private GameObject portal;
    public GameObject nextBtn;
    //dialog
    private bool colon1dia;
    [SerializeField] private GameObject precolonobj;
    //길안내
    [SerializeField] private GameObject colon1_line_1;
    void Start()
    {
        portal.SetActive(false);
        colon1dia = false;
        precolonobj.SetActive(true);
        nextBtn.SetActive(false);
        //길안내
        colon1_line_1.SetActive(false);
        StartStage0();
    }

    public void StartStage0()
    {
        colon1dia = true;
        //nextBtn
        nextBtn.SetActive(true);
        //PreColonEnd();
    }

    IEnumerator PreColonEndLoading()
    {
        yield return new WaitForSeconds(2.0f);
        precolonobj.SetActive(false);
        portal.SetActive(true);
        //길안내
        colon1_line_1.SetActive(true);
    }

    public void PreColonEnd()
    {
        nextBtn.SetActive(false);
        StartCoroutine(PreColonEndLoading());
    }

    public bool GetColon1dia()
    {
        return colon1dia;
    }
    
}
