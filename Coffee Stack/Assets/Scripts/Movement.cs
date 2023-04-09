using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float verticalSpeed = 5f;
    [SerializeField] float horizontalSpeed = 5f;
    private GameObject mainObject;
    private GameObject handObject; // Eli hareket ettirmek i�in tan�mlad�m

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
        handObject = transform.GetChild(0).gameObject;
        mainObject = transform.GetChild(1).gameObject;
    }
    void Update()
    {
        transform.position += Vector3.forward * verticalSpeed * Time.deltaTime;
    }
    private void InputManager_OnAnyTouch(float input)
    {
        var moveVector = new Vector3(input, 0, 0);
        mainObject.transform.localPosition = Vector3.MoveTowards(mainObject.transform.localPosition,
            mainObject.transform.localPosition + moveVector, Time.deltaTime * horizontalSpeed);

        // �imdilik eli de hareket ettirmek i�in bunu yapt�m ama de�i�tirmek gerekicek
        handObject.transform.localPosition = Vector3.MoveTowards(handObject.transform.localPosition,
            handObject.transform.localPosition + moveVector, Time.deltaTime * horizontalSpeed);
    }
}
