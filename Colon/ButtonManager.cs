using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{

    private GameObject[] buttons;
    private ButtonDetector[] buttonDetectors;
    private MeshRenderer[] buttonsRender;
    private int stage;
    private int endStage;

    private bool showButtonStart;
    private bool buttonCheckStart;
    private bool buttonActive;
    private bool clickRecongized;
    private int[] buttonOrder;

    private Material defaultButtonMaterial;
    [SerializeField]
    private Material effectButtonMaterial;
    [SerializeField]
    private ButtonGuideGUI buttonGuideGUI;
    [SerializeField]
    private ColonManager colonManager;
    private List<GameObject> scars;

    private int clickButtonID;
    private int order;

    void Start()
    {

        StartReady();
        ButtonStartTurnOn();

    }
    public void StartReady()
    {
        print("Button Start!!");
        buttons = GameObject.FindGameObjectsWithTag("Button");
        GameObject[] scar_array = GameObject.FindGameObjectsWithTag("Scar");
        scars = new List<GameObject>();
        foreach (GameObject scar in scar_array)
        {
            scars.Add(scar);
        }


        buttonDetectors = new ButtonDetector[buttons.Length];
        buttonsRender = new MeshRenderer[buttons.Length];
        for (int i = 0; i < buttons.Length; i++)
        {
            buttonDetectors[i] = buttons[i].GetComponent<ButtonDetector>();
            buttonDetectors[i].SetMyButtonID(i);
            buttonsRender[i] = buttons[i].transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>();
        }
        stage = 0;
        endStage = 3;
        buttonActive = false;
        showButtonStart = false;
        buttonCheckStart = false;
        clickRecongized = false;
        clickButtonID = -1;
        order = 0;
    }

    public void ButtonStartTurnOn()
    {
        buttonActive = true;
        StartCoroutine(ButtonStart());
    }

    IEnumerator ButtonStart()
    {
        yield return new WaitForSeconds(1f);
        buttonGuideGUI.ButtonGuidStart();
        yield return new WaitForSeconds(1f);
        buttonGuideGUI.ButtonGuidEnd();
        StartCoroutine(ShowButton());
        
    }

    IEnumerator ShowButton()
    {
        buttonGuideGUI.ButtonRunAlert(stage);
        yield return new WaitForSeconds(3f);
        buttonGuideGUI.ButtonGuidEnd();
        buttonOrder = new int[3 + stage];
        
        for(int i = 0; i < buttonOrder.Length; i++)
        {
            
            int a = Random.Range(0,5);
            buttonOrder[i] = a;
            defaultButtonMaterial = buttonsRender[a].material;
            yield return new WaitForSeconds(0.3f);
            buttonsRender[a].material = effectButtonMaterial;
            yield return new WaitForSeconds(1.0f); //1f->1.5f
            buttonsRender[a].material = defaultButtonMaterial;
            //yield return new WaitForSeconds(0.3f);
        }
        clickButtonID = -1;
        buttonCheckStart = true;
        clickRecongized = true;
    }

    public void SetClickButtonID(int id)
    {
        if (clickRecongized)
        {
            clickButtonID = id;
        }
            
    }

    public void ClickRecongizedTurnOn()
    {
        if (buttonCheckStart)
        {
            clickRecongized = true;
        }
    }

    IEnumerator ButtonFail()
    {
        yield return new WaitForSeconds(1f);
        buttonGuideGUI.ButtonGuidEnd();
        buttonGuideGUI.TryAgainShow();
        yield return new WaitForSeconds(1f);
        buttonGuideGUI.ButtonGuidEnd();
        showButtonStart = false;
        //stage = 0;
        StartCoroutine("ShowButton");
    }

    

    void Update()
    {
        if (buttonActive)
        {
            if(showButtonStart)
            {
                buttonGuideGUI.ButtonGuidEnd();
                showButtonStart = false;
                stage++;
                if (stage >= endStage)
                {
                    buttonActive = false;
                    buttonCheckStart = false;
                    

                    int rand = Random.Range(2,scars.Count - 2);
                    for(int i = 0; i < rand; i++)
                    {
                        int index = Random.Range(0,scars.Count);
                        GameObject scar = scars[index];
                        scars.RemoveAt(index);
                        Destroy(scar);
                    }
                    buttonGuideGUI.ButtonGuidFinish();
                    colonManager.EndStage2_1();
                    return;
                }
                else
                {
                    StartCoroutine(ShowButton());
                }
            }
            else
            {
                if (buttonCheckStart)
                {
                    
                    if(order>=stage+3)
                    { 
                        print("success");
                        showButtonStart = true;
                        buttonCheckStart = false;
                        order = 0;
                        clickRecongized = false;
                        clickButtonID = -1;
                        return;
                    }

                    if (!clickRecongized)
                    {
                        return;
                    }

                    if (clickButtonID == -1)
                        return;
                    else
                    {
                        if (buttonOrder[order] == clickButtonID)
                        {
                            buttonGuideGUI.ButtonSuccessAlert(buttonOrder[order]);
                            clickButtonID = -1;
                            clickRecongized = false;
                            order++;
                            
                        }
                        else
                        {
                            buttonGuideGUI.ButtonFailAlert(buttonOrder[order]);
                            order = 0;
                            buttonCheckStart = false;
                            clickButtonID = -1;
                            clickRecongized = false;
                            StartCoroutine(ButtonFail());
                        }
                    }

                }
            }
        }
    }    
}
