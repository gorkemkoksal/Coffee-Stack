using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float verticalSpeed = 5f;
    [SerializeField] float horizontalSpeed = 5f;
    [SerializeField] CinemachineVirtualCamera followCam;
    private GameObject mainObject;
    private GameObject handObject; // Eli hareket ettirmek için tanýmladým
    private bool isLevelEnded;
    private bool isTowering;

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
        if (transform.childCount <= 1)
        {
            followCam.gameObject.SetActive(false);
        }
        if (isTowering) { return; }
        transform.position += Vector3.forward * verticalSpeed * Time.deltaTime;
    }
    private void InputManager_OnAnyTouch(float input)
    {
        if (isLevelEnded) { return; }

        var moveVector = new Vector3(input, 0, 0);
        mainObject.transform.localPosition = Vector3.MoveTowards(mainObject.transform.localPosition,
            mainObject.transform.localPosition + moveVector, Time.deltaTime * horizontalSpeed);

        // Þimdilik eli de hareket ettirmek için bunu yaptým ama deðiþtirmek gerekicek
        handObject.transform.localPosition = Vector3.MoveTowards(handObject.transform.localPosition,
            handObject.transform.localPosition + moveVector, Time.deltaTime * horizontalSpeed);
    }
    public void SetIsTowering()
    {
        isTowering = true;
    }


}
