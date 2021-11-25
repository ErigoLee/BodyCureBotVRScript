using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Dialogue2
{
    [TextArea(5, 3)]
    public string dialogue;
}
public class TutorialDialog : MonoBehaviour
{
    [SerializeField] private TutorialManager tutorialManager;

    [SerializeField] private TextMeshProUGUI txt_Dialogue;

    [SerializeField] private GameObject nextBtn;

    [SerializeField] private EffectAudioManager effectAudioManager;

    // 대화가 얼마나 진행 되었는지 확인
    private int count = 0;
    static private String[] dialogue; // 대화가 들어가는 배열

    public bool nextdialogok = false;

    private void Awake()
    {
        dialogue = new string[4];
        dialogue[0] = "[튜토리얼]\n\n만나서 반가워요!\n대화창을 넘겨주세요.";
        dialogue[1] = "[튜토리얼]\n\n대화창을 넘겨주세요!";
        dialogue[2] = "[튜토리얼]\n\n다시 한 번 더";
        dialogue[3] = "[튜토리얼]\n\n고마워요.";
    }


    void Start()
    {
        ShowDialogue(0);
        //nextBtn.SetActive(true);
    }

    public void ShowDialogue(int count_)
    {
        count = count_;
        NextDialogue();
    }

    public void NextDialogue()
    {
        if (count != 0)
            effectAudioManager.DialogEffect();
        txt_Dialogue.text = dialogue[count];
        count++;
        nextdialogok = false;
    }

    IEnumerator Loading()
    {
        yield return new WaitForSeconds(2.0f);
        tutorialManager.EndStep2();
    }

    void Update()
    {
        if (nextdialogok)
        {
            if(count==3)
            {
                nextBtn.SetActive(false);
            }
            if (count < 4)
            {
                NextDialogue();
            }
        }

        if (count == 4)
        {
            StartCoroutine(Loading());
            count++;
        }
    }
}
