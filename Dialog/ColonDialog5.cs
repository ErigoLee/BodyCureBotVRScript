using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColonDialog5 : MonoBehaviour
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
        dialogue = new string[3];
        dialogue[0] = "[DS3249]\n\n아까 보니 이 열쇠 조각이\n필요하실 것 같아서";
        dialogue[1] = "[DS3249]\n\n치료하시는\n동안 고쳤습니다.";
        dialogue[2] = "[DS3249]\n\n가져가서 동료들을\n구해주세요.";
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
            if (count < 3)
            {
                NextDialogue();
            }
            if (count == 3)
            {
                if (!getMission) //종양 치료 미션 진행하기
                {
                    colonManager.ColonEnd();
                    getMission = true;
                }
            }
        }
    }
}
