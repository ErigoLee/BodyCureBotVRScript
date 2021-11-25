﻿using System.Collections;using System.Collections.Generic;using UnityEngine;using UnityEngine.UI;using TMPro;public class BVTransferGuide : MonoBehaviour{    [SerializeField] private BVTransfer bVTransfer;    [SerializeField] private HeartManager heartManager;    [SerializeField] private GameObject guidePanel;    [SerializeField] private TMP_Text text;    private Color color;    void Start()    {        color = text.color;        color.a = 0;        text.color = color;    }    IEnumerator TransferExplain()    {        guidePanel.SetActive(true);        string dialogue = "혈관 비행 시작";        text.text = dialogue;        color.a = 1;        text.color = color;        yield return new WaitForSeconds(2.0f);        dialogue = "보고있는 방향으로\n방향을 조절하여\n비행할 수 있어요.";        text.text = dialogue;        yield return new WaitForSeconds(2.0f);        dialogue = "혈관을 따라\n이동하며 지방질을\n피해야해요.";        text.text = dialogue;        yield return new WaitForSeconds(2.0f);        dialogue = "혈관이 막힌 부분에\n도착 시 비행이\n멈추게 돼요.";        text.text = dialogue;        yield return new WaitForSeconds(2.0f);        dialogue = "비행을 \n시작할게요!";        text.text = dialogue;        yield return new WaitForSeconds(2.0f);        color.a = 0;        text.color = color;        guidePanel.SetActive(false);        bVTransfer.TransferCanTurnOn();    }    public void BVTransferExplain()    {        StartCoroutine(TransferExplain());    }    IEnumerator FailExplain()    {        guidePanel.SetActive(true);        string dialogue = "지방질과\n충돌했어요.";        text.text = dialogue;        color.a = 1;        text.color = color;        yield return new WaitForSeconds(2.0f);        dialogue = "다시 기회를\n드릴게요!";        text.text = dialogue;        yield return new WaitForSeconds(2.0f);        guidePanel.SetActive(false);        color.a = 0;        text.color = color;        bVTransfer.GoBack();        bVTransfer.TransferCanTurnOn();    }    public void FaildMissionExplain()    {        StartCoroutine(FailExplain());    }    IEnumerator SuccessExplain()    {        guidePanel.SetActive(true);        string dialogue = "비행 성공하셨습니다.";        text.text = dialogue;        color.a = 1;        text.color = color;        yield return new WaitForSeconds(2.0f);        dialogue = "이제 다음 미션을\n수행해 주십시오.";        text.text = dialogue;        yield return new WaitForSeconds(2.0f);        guidePanel.SetActive(false);        heartManager.EndStage0_2();    }    public void SuccessMissionExplain()    {        StartCoroutine(SuccessExplain());    }}