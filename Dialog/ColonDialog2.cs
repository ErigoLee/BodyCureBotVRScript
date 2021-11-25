using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColonDialog2 : MonoBehaviour
{
    [SerializeField] private ColonManager colonManager;

    [SerializeField] private TextMeshProUGUI txt_Dialogue;

    [SerializeField] private EffectAudioManager effectAudioManager;

    //대화가 얼마나 진행 되었는지 확인
    private int count = 0;
    static private string[] dialogue; //대화에 들어갈 배열

    public bool nextdialogok = false;

    private bool getMission = false;
    private void Awake()
    {
        dialogue = new string[6];
        dialogue[0] = "[DS3249]\n\n감사합니다. 아직\n멀쩡한 분이 계시다니..";
        dialogue[1] = "[DS3249]\n\n갑자기 동료들이\n이렇게 되다니..";
        dialogue[2] = "[DS3249]\n\n혹시 바쁘시지 않다면 \n저 좀 도와주시겠습니까?";
        dialogue[3] = "[DS3249]\n\n일단 벽에 붙어 있는\n종양들을 제거해주세요.";
        dialogue[4] = "[DS3249]\n\n그냥 물건 잡듯이\n잡고 떼시면 됩니다.";
        dialogue[5] = "-퀘스트-\n\n동료를 도와\n대장을 치료하세요!";
    }
    void Start()
    {
        ShowDialogue(0);
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

    void Update()
    {
        if (nextdialogok)
        {
            if (count < 6)
            {
                NextDialogue();
            }
            if (count == 6)
            {
                if (!getMission) //종양 제거 미션 진행하기
                {
                    colonManager.StartStage1();
                    getMission = true;
                }
            }
        }
    }
}
