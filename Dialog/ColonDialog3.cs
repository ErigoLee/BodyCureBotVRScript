using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColonDialog3 : MonoBehaviour
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
        dialogue[0] = "[DS3249]\n\n전 잠시 할일이\n있으니 종양검사를\n진행해주세요.";
        dialogue[1] = "[DS3249]\n\n그리 어렵지 않을겁니다.\n\n";
        dialogue[2] = "-퀘스트-\n\n조직검사를 진행하세요.\n\n";
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
                if (!getMission) //button 오브젝트 활성화
                {
                    colonManager.PreStartStage2();
                    getMission = true;
                }
            }
        }
    }
}
