using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExplainText : MonoBehaviour
{
    [SerializeField] private DefenceManger defenceManger;
    [SerializeField] private GameObject explainPanel;
    private TMP_Text text;


    void Start()
    {
        text = GetComponent<TMP_Text>();
        StartCoroutine("ExplainScreen");
    }


    IEnumerator ExplainScreen()
    {
        yield return new WaitForSeconds(2.0f);
        string dialogue = "기관지가\n자라나는 동안";
        text.text = dialogue;
        yield return new WaitForSeconds(2.0f);
        dialogue = "적들이 와요!";
        text.text = dialogue;
        yield return new WaitForSeconds(2.0f);
        dialogue = "적들을 향해\n총을 발사하세요.";
        text.text = dialogue;
        yield return new WaitForSeconds(2.0f);
        dialogue = "STEP1에서는 \n총알을 무한히\n발사할 수 있어요.";
        text.text = dialogue;
        yield return new WaitForSeconds(2.0f);
        dialogue = "STEP2부터는\n장전을 해야해요.";
        text.text = dialogue;
        yield return new WaitForSeconds(2.0f);
        dialogue = "V 손동작을 취하면\n장전할 수 있어요.";
        text.text = dialogue;
        yield return new WaitForSeconds(2.0f);
        dialogue = "이제 게임을\n시작할게요!";
        text.text = dialogue;
        yield return new WaitForSeconds(2.0f);
        defenceManger.DefenceStart();
    }
}
