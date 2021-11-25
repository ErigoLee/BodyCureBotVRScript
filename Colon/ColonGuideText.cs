using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColonGuideText : MonoBehaviour
{
    private TMP_Text text;
    private Color color;
    [SerializeField] private ColonManager colonManager;
    [SerializeField] private GameObject colonGuidePanel;
    void Start()
    {
        text = GetComponent<TMP_Text>();
        color = text.color;
        color.a = 0.0f;
        text.color = color;
    }

    public void guideEnd()
    {
        colonGuidePanel.SetActive(false);
        color.a = 0.0f;
        text.color = color;
    }

    IEnumerator ExplainStage2()
    {
        colonGuidePanel.SetActive(true);
        string dialogue = "잘하셨습니다.";
        text.text = dialogue;
        color.a = 1.0f;
        text.color = color;
        yield return new WaitForSeconds(2.0f);
        dialogue = "빛나는 곳으로 이동하여\n조직검사를 수행하세요.";
        text.text = dialogue;
        colonManager.ExplainningEnd();
    }

    public void guideStage2()
    {
        StartCoroutine("ExplainStage2");
    }

    IEnumerator ExplainStage3()
    {
        colonGuidePanel.SetActive(true);
        string dialogue = "잘하셨습니다.";
        text.text = dialogue;
        color.a = 1.0f;
        text.color = color;
        yield return new WaitForSeconds(2.0f);
        dialogue = "빛나는 곳으로 이동하여\n종양치료를 수행하세요.";
        text.text = dialogue;
        colonManager.ExplainningEnd();
    }
    
    public void guideStage3()
    {
        StartCoroutine("ExplainStage3");
    }
}
