using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class NewBehaviourScript : MonoBehaviour
{
    public List<FloatInputActionReference> m_floatInputActionsReferencesList = new List<FloatInputActionReference>();
    public List<Vector2InputActionReference> m_vector2InputActionsReferencesList = new List<Vector2InputActionReference>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (var floatActionReference in m_floatInputActionsReferencesList)
            floatActionReference.StartListening();
        foreach (var vector2ActionReference in m_vector2InputActionsReferencesList)
            vector2ActionReference.StartListening();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        foreach (var floatActionReference in m_floatInputActionsReferencesList)
            floatActionReference.StartListening();
        foreach (var vector2ActionReference in m_vector2InputActionsReferencesList)
            vector2ActionReference.StartListening();
    }

    private void OnDisable()
    {
        foreach (var floatActionReference in m_floatInputActionsReferencesList)
            floatActionReference.StopListening();
        foreach (var vector2ActionReference in m_vector2InputActionsReferencesList)
            vector2ActionReference.StartListening();
    }

    private void OnDestroy()
    {
        foreach (var floatActionReference in m_floatInputActionsReferencesList)
            floatActionReference.StopListening();
        foreach (var vector2ActionReference in m_vector2InputActionsReferencesList)
            vector2ActionReference.StartListening();
    }

    [System.Serializable]
    public class FloatInputActionReference
    {
        public string m_description;
        public InputActionReference m_whatToObserve;
        public float m_value;
        public UnityEvent<float> m_onChanged;

        public void StartListening()
        {
            m_whatToObserve.action.Enable();
            m_whatToObserve.action.performed += (e) => { 
                m_value = e.ReadValue<float>();
                m_onChanged.Invoke(m_value);
            };
            m_whatToObserve.action.canceled += (e) => {
                m_value = e.ReadValue<float>();

                m_onChanged.Invoke(m_value);
            };
        }

        public void StopListening()
        {
            m_whatToObserve.action.Disable();
            m_whatToObserve.action.performed -= (e) => { m_value = e.ReadValue<float>(); };
            m_whatToObserve.action.canceled -= (e) => {
                m_value = e.ReadValue<float>();

                m_onChanged.Invoke(m_value);
            };
        }
    }

    [System.Serializable]
    public class Vector2InputActionReference
    {
        public string m_description;
        public InputActionReference m_whatToObserve;
        public Vector2 m_value;
        public UnityEvent<Vector2> m_onChanged;

        public void StartListening()
        {

            m_whatToObserve.action.Enable();
            m_whatToObserve.action.performed += (e) => { m_value = e.ReadValue<Vector2>();

                m_onChanged.Invoke(m_value);
            };
            m_whatToObserve.action.canceled += (e) => {
                m_value = e.ReadValue<Vector2>();

                m_onChanged.Invoke(m_value);
            };
        }

        public void StopListening()
        {

            m_whatToObserve.action.Disable();
            m_whatToObserve.action.performed -= (e) => { m_value = e.ReadValue<Vector2>(); };
            m_whatToObserve.action.canceled -= (e) => {
                m_value = e.ReadValue<Vector2>();

                m_onChanged.Invoke(m_value);
            };
        }
    }
}
