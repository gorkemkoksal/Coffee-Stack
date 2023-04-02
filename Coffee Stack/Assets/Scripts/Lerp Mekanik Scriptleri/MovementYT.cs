using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementYT : MonoBehaviour
{
    public float swipeSpeed;
    public float moveSpeed;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;    
    }

    void Update()
    {
        transform.position += Vector3.forward * moveSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.Mouse0))
        {
            Move();
        }
    }

    private void Move()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = mainCamera.transform.localPosition.z;

        Ray ray = mainCamera.ScreenPointToRay(mousePos);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity) )
        {
            GameObject firstCube = ATMRush.Instance.cubes[0];
            Vector3 hitVec = hit.point;
            hitVec.y = firstCube.transform.localPosition.y;
            hitVec.z = firstCube.transform.localPosition.z;

            firstCube.transform.localPosition = Vector3.MoveTowards(firstCube.transform.localPosition, hitVec, Time.deltaTime * swipeSpeed);
        }
    }
}
