using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsButton : MonoBehaviour
{
    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private float deadZone = 0.025f;
    [SerializeField] private ButtonDetector buttonDetector;
    [SerializeField] private Material pressedMaterial;
    [SerializeField] private Material defaultButtonMaterial;
    [SerializeField] private EffectAudioManager effectAudioManager;
    private MeshRenderer buttonRenderer;

    private bool _isPressed;
    private Vector3 _startPos;
    private ConfigurableJoint _joint;
    private float minY;
    private Vector3 prePos;

    private bool inLeft;
    private bool inRight;

    void Start()
    {
        
        _startPos = transform.localPosition;
        _joint = GetComponent<ConfigurableJoint>();
        buttonRenderer = transform.GetChild(0).gameObject.GetComponent<MeshRenderer>();
        minY = -0.6f;
        inRight = false;
        inLeft = false;
        
    }

    void Update()
    {
        Vector3 position = transform.localPosition;

        if(_startPos.x != position.x)
        {
            position.x = _startPos.x;
            transform.localPosition = position;
        }

        if(_startPos.z != position.z)
        {
            position.z = _startPos.z;
            transform.localPosition = position;
        }


        if (position.y > _startPos.y)
        {
            transform.localPosition = _startPos;
        }

        if (position.y < minY)
        {
            Vector3 new_position = new Vector3(position.x,minY,position.y);
            transform.localPosition = new_position;
        }

        if (!_isPressed && GetValue() + threshold >= 1)
            Pressed();
        if (_isPressed && GetValue() - threshold <= 0)
            Released();
        if(!inRight && !inLeft)
        {
            Rigidbody rigidbody = GetComponent<Rigidbody>();
            if (_startPos.y > transform.localPosition.y)
            {
                transform.localPosition = _startPos;
                Released();
            }
        }
        prePos = transform.localPosition;
    }

    private float GetValue()
    {
        var value = Vector3.Distance(_startPos, transform.localPosition) / _joint.linearLimit.limit;

        if (Mathf.Abs(value) < deadZone)
            value = 0;

        return Mathf.Clamp(value, -1f, 1f);
    }

    private void Pressed()
    {
        effectAudioManager.ButtonClickEffect();
        _isPressed = true;
        buttonRenderer.material = pressedMaterial;
        buttonDetector.Pressed();
        print("pressed");
    }

    private void Released()
    {
        _isPressed = false;
        buttonRenderer.material = defaultButtonMaterial;
        buttonDetector.Released();
        print("release");
    }

    public void InLeftTurnOn()
    {
        inLeft = true;
    }

    public void InRightTurnOn()
    {
        inRight = true;
    }

    public void InLeftTurnOff()
    {
        inLeft = false;
    }

    public void InRightTurnOff()
    {
        inRight = false;
    }
}
