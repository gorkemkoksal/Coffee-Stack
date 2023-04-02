using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] float verticalSpeed = 5f;
    [SerializeField] float horizontalSpeed = 5f;
    [SerializeField] private List<GameObject> gameObjects = new List<GameObject>();
    GameObject mainObject;

    private void OnEnable()
    {
        InputManager.onAnyTouch += InputManager_OnAnyTouch;
    }
    private void OnDisable()
    {
        InputManager.onAnyTouch -= InputManager_OnAnyTouch;
    }
    private void Start()
    {
        mainObject = transform.GetChild(0).gameObject;
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        transform.position += Vector3.forward * verticalSpeed * Time.deltaTime;
    }
    private void InputManager_OnAnyTouch(float input)
    {
        rb.AddForce(Vector3.right * input * horizontalSpeed);
    }
}
