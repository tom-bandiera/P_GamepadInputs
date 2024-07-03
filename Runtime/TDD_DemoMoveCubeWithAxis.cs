using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDD_DemoMoveCubeWithAxis : MonoBehaviour
{
    public Transform m_testObject;

    public float m_joystickLeftX;
    public float m_joystickLeftY;
    public float m_joystickRightX;
    public float m_joystickRightY;

    // Update is called once per frame
    void Update()
    {
        m_testObject.transform.localScale = new Vector3(0.5f + m_joystickLeftX, 0.5f + m_joystickLeftY);
        m_testObject.transform.localPosition = new Vector3(0.5f + m_joystickRightX, 0.5f + m_joystickRightY);
    }

    public void SetJoystickLeftX(float joystickLeftX) => m_joystickLeftX = joystickLeftX;
    public void SetJoystickLeftY(float m_joystickLeftY) => m_joystickLeftX = m_joystickLeftY;
    public void SetJoystickRightX(float m_joystickRightX) => m_joystickLeftX = m_joystickRightX;
    public void SetJoystickRightY(float m_joystickRightY) => m_joystickLeftX = m_joystickRightY;
}
