using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferLungMaterial : MonoBehaviour
{
    [SerializeField] private Material lungMat;
    [SerializeField] private GameObject leftLung;
    [SerializeField] private GameObject rightLung;
    private MeshRenderer leftLungRender;
    private MeshRenderer rightLungRender;
    void Start()
    {
        leftLungRender = leftLung.GetComponent<MeshRenderer>();
        rightLungRender = rightLung.GetComponent<MeshRenderer>();
    }

    public void TransMaterial()
    {
        leftLungRender.material = lungMat;
        rightLungRender.material = lungMat;
    }

}
