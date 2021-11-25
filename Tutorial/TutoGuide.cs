using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TutoGuide : MonoBehaviour
{
    [SerializeField] private Image tutoImage;
    [SerializeField] private TMP_Text text;
    private string[] guideTexts; // tutorial에 들어갈 내용
    [SerializeField] private Sprite[] tutoImages;
    private Color tutoTextColor;
    
    void Start()
    {
        InPuteGuideText();
        tutoTextColor = text.color;
        tutoTextColor.a = 0.0f;
        text.color = tutoTextColor;
    }

    private void InPuteGuideText()
    {
        guideTexts = new string[4];
        guideTexts[0] = "<이동>\n\n손동작을 따라하며\n앞뒤로 이동할 수 있습니다.\n포탈로 이동해보세요";
        guideTexts[1] = "<대화넘기기>\n\n손동작을 따라하여\n대화를 넘길 수 있습니다";
        guideTexts[2] = "<물건잡기>\n\n손동작을 따라하여\n물건을 잡을 수 있습니다.\n앞의 물건을 잡아보세요!";
        guideTexts[3] = "<물건 던지기>\n\n손동작을 따라하여\n표시된 구역으로\n물건을 던져보세요";
    }
    
    IEnumerator Step1ImageTransfer()
    {
        tutoImage.sprite = tutoImages[0];
        yield return new WaitForSeconds(0.8f);
        tutoImage.sprite = tutoImages[1];
        yield return new WaitForSeconds(0.8f);
        StartCoroutine(Step1ImageTransfer());
    }

    public void Step1Guide()
    {
        text.text = guideTexts[0];
        tutoTextColor.a = 1.0f;
        text.color = tutoTextColor;
        StartCoroutine(Step1ImageTransfer());
    }

    public void Step1GuideEnd()
    {
        StopAllCoroutines();
        tutoTextColor.a = 0.0f;
        text.color = tutoTextColor;
    }

    IEnumerator Step2ImageTransfer()
    {
        tutoImage.sprite = tutoImages[2];
        yield return new WaitForSeconds(0.8f);
        tutoImage.sprite = tutoImages[3];
        yield return new WaitForSeconds(0.8f);
        StartCoroutine(Step2ImageTransfer());
    }

    public void Step2Guide()
    {
        text.text = guideTexts[1];
        tutoTextColor.a = 1.0f;
        text.color = tutoTextColor;
        StartCoroutine(Step2ImageTransfer());
    }

    public void Step2GuideEnd()
    {
        StopAllCoroutines();
        tutoTextColor.a = 0.0f;
        text.color = tutoTextColor;
    }

    IEnumerator Step3ImageTransfer()
    {
        tutoImage.sprite = tutoImages[4];
        yield return new WaitForSeconds(0.8f);
        tutoImage.sprite = tutoImages[5];
        yield return new WaitForSeconds(0.8f);
        StartCoroutine(Step3ImageTransfer());
    }

    public void Step3Guide()
    {
        text.text = guideTexts[2];
        tutoTextColor.a = 1.0f;
        text.color = tutoTextColor;
        StartCoroutine(Step3ImageTransfer());
    }

    public void Step3GuideEnd()
    {
        StopAllCoroutines();
        tutoTextColor.a = 0.0f;
        text.color = tutoTextColor;
    }

    IEnumerator Step4ImageTransfer()
    {
        tutoImage.sprite = tutoImages[6];
        yield return new WaitForSeconds(0.8f);
        tutoImage.sprite = tutoImages[7];
        yield return new WaitForSeconds(0.8f);
        StartCoroutine(Step4ImageTransfer());
    }

    public void Step4Guide()
    {
        text.text = guideTexts[3];
        tutoTextColor.a = 1.0f;
        text.color = tutoTextColor;
        StartCoroutine(Step4ImageTransfer());
    }

    public void Step4GuideEnd()
    {
        StopAllCoroutines();
        text.text = "\n\n\n\n잘하셨습니다.\n포탈로 이동하세요.";
    }
}
