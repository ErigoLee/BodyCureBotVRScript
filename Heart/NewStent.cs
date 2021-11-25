using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewStent : MonoBehaviour
{
    [SerializeField] private GameObject upFat;
    [SerializeField] private GameObject downFat;
    [SerializeField] private HeartManager heartManager;
    [SerializeField] private RestrictedAreaSet2 restrictedAreaSet2;
    [SerializeField] private EffectAudioManager effectAudioManager;
    private float elaspedTime = 0.0f;
    private float endTime = 5.0f;
    private bool rateStart = false;
    private Vector3 scale;

    public void InitialPos()
    {
        scale = transform.localScale;
        Vector3 position = upFat.transform.localPosition;
        position.y += 0.01f;
        upFat.transform.localPosition = position;
        position = downFat.transform.localPosition;
        position.y -= 0.01f;
        downFat.transform.localPosition = position;
        StartCoroutine(ReadyInterval());
    }
    IEnumerator ReadyInterval()
    {
        yield return new WaitForSeconds(5.0f);
        rateStart = true;
        effectAudioManager.ExpandedStentEffect();
    }

    
    void Update()
    {
        if (rateStart)
        {
            elaspedTime += Time.deltaTime;
            scale.x += Time.deltaTime * 80;
            scale.y += Time.deltaTime * 80;
            transform.localScale = scale;
            Vector3 position = upFat.transform.localPosition;
            position.y += Time.deltaTime * 0.09f;
            upFat.transform.localPosition = position;
            position = downFat.transform.localPosition;
            position.y -= Time.deltaTime * 0.09f;
            downFat.transform.localPosition = position;
            if (elaspedTime >= endTime)
            {
                heartManager.EndStage2();
                restrictedAreaSet2.ExpandZMaxTurnOn();
                rateStart = false;
            }
        }
    }
}
