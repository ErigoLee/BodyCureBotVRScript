using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogExist : MonoBehaviour
{
    [SerializeField] private GameObject tutoPanel;
    [SerializeField] private GameObject decoPanel;
    [SerializeField] private GameObject preHeartPanel;
    [SerializeField] private GameObject preColonPanel;
    [SerializeField] private GameObject colonPanel1;
    [SerializeField] private GameObject colonPanel2;
    [SerializeField] private GameObject colonPanel3;
    [SerializeField] private GameObject colonPanel4;
    [SerializeField] private GameObject colonPanel5;
    

    //GameObject.FindGameObjectWithTag("Dialog").GetComponent<FirstNpcDialog>().nextdialogok = true;
    public void NextDialog()
    {
        if(tutoPanel.activeSelf == true)
        {
            tutoPanel.GetComponent<TutorialDialog>().nextdialogok = true;
        }
        if(decoPanel.activeSelf == true)
        {
            decoPanel.GetComponent<DecoDialog>().nextdialogok = true;
            //decoPanel.GetComponent<FirstNpcDialog>().nextdialogok = true;
        }
        if(preHeartPanel.activeSelf == true)
        {
            preHeartPanel.GetComponent<PreHeartDialog>().nextdialogok = true;
            //preHeartPanel.GetComponent<FirstNpcDialog>().nextdialogok = true;
        }
        if(preColonPanel.activeSelf == true)
        {
            preColonPanel.GetComponent<PreColonDialog>().nextdialogok = true;
            //preColonPanel.GetComponent<FirstNpcDialog>().nextdialogok = true;
        }
        if(colonPanel1.activeSelf == true)
        {
            colonPanel1.GetComponent<ColonDialog1>().nextdialogok = true;
            //colonPanel1.GetComponent<FirstNpcDialog>().nextdialogok = true;
        }
        if(colonPanel2.activeSelf == true)
        {
            colonPanel2.GetComponent<ColonDialog2>().nextdialogok = true;
            //colonPanel2.GetComponent<FirstNpcDialog>().nextdialogok = true;
        }
        if(colonPanel3.activeSelf == true)
        {
            colonPanel3.GetComponent<ColonDialog3>().nextdialogok = true;
            //colonPanel3.GetComponent<FirstNpcDialog>().nextdialogok = true;
        }
        if(colonPanel4.activeSelf == true)
        {
            colonPanel4.GetComponent<ColonDialog4>().nextdialogok = true;
            //colonPanel4.GetComponent<FirstNpcDialog>().nextdialogok = true;
        }
        if(colonPanel5.activeSelf == true)
        {
            colonPanel5.GetComponent<ColonDialog5>().nextdialogok = true;
            //colonPanel5.GetComponent<FirstNpcDialog>().nextdialogok = true;
        }


    }
    //GameObject.FindGameObjectWithTag("Dialog").GetComponent<FirstNpcDialog>().nextdialogok = false;
    public void StopDialog()
    {
        if (tutoPanel.activeSelf == true)
        {
            tutoPanel.GetComponent<TutorialDialog>().nextdialogok = false;
        }
        if (decoPanel.activeSelf == true)
        {
            decoPanel.GetComponent<DecoDialog>().nextdialogok = false;
            //decoPanel.GetComponent<FirstNpcDialog>().nextdialogok = false;
        }
        if (preHeartPanel.activeSelf == true)
        {
            preHeartPanel.GetComponent<PreHeartDialog>().nextdialogok = false;
            //preHeartPanel.GetComponent<FirstNpcDialog>().nextdialogok = false;
        }
        if (preColonPanel.activeSelf == true)
        {
            preColonPanel.GetComponent<PreColonDialog>().nextdialogok = false;
            //preColonPanel.GetComponent<FirstNpcDialog>().nextdialogok = false;
        }
        if (colonPanel1.activeSelf == true)
        {
            colonPanel1.GetComponent<ColonDialog1>().nextdialogok = false;
            //colonPanel1.GetComponent<FirstNpcDialog>().nextdialogok = false;
        }
        if (colonPanel2.activeSelf == true)
        {
            colonPanel2.GetComponent<ColonDialog2>().nextdialogok = false;
            //colonPanel2.GetComponent<FirstNpcDialog>().nextdialogok = false;
        }
        if (colonPanel3.activeSelf == true)
        {
            colonPanel3.GetComponent<ColonDialog3>().nextdialogok = false;
            //colonPanel3.GetComponent<FirstNpcDialog>().nextdialogok = false;
        }
        if (colonPanel4.activeSelf == true)
        {
            colonPanel4.GetComponent<ColonDialog4>().nextdialogok = false;
            //colonPanel4.GetComponent<FirstNpcDialog>().nextdialogok = false;
        }
        if (colonPanel5.activeSelf == true)
        {
            colonPanel5.GetComponent<ColonDialog5>().nextdialogok = false;
            //colonPanel5.GetComponent<FirstNpcDialog>().nextdialogok = false;
        }
    }
}
