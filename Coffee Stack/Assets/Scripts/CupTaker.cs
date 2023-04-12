using DG.Tweening;
using System.Collections;
using UnityEngine;

public class CupTaker : MonoBehaviour
{
    [SerializeField] private Transform cupPosition;
    [SerializeField] private bool isRight;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float border;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HandedCup"))
        {
            StackManager.Instance.RemoveCup(other.gameObject);
            other.transform.SetParent(this.transform);
            other.transform.position = cupPosition.position;

            var targetPos = isRight ? new Vector3(border,-0.5f,transform.position.z) : new Vector3(-border, -0.5f, transform.position.z);
            transform.DOMove(targetPos, movementSpeed);
        }
    }
}
