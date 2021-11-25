using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColonDialog4 : MonoBehaviour
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
        dialogue = new string[4];
        dialogue[0] = "[DS3249]\n\n이런..악성종양에 놈들이\n   인형을 연결했나보군요.";
        dialogue[1] = "[DS3249]\n\n아직 시간이 더 필요한데...";
        dialogue[2] = "[DS3249]\n\n부탁드립니다...";
        dialogue[3] = "-퀘스트-\n\n악성종양에 연결된\n인형 타겟에 물풍선을\n던져 제거하세요!";
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
            if (count < 4)
            {
                NextDialogue();
            }
            if (count == 4)
            {
                if (!getMission) //종양 치료 미션 진행하기
                {
                    colonManager.PreStartStage3();
                    getMission = true;
                }
            }
        }
    }
}
