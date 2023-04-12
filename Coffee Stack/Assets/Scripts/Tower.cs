using Cinemachine;
using DG.Tweening;
using System.Collections;
using UnityEngine;
public class Tower : MonoBehaviour
{
    [SerializeField] private Transform hand;
    [SerializeField] private CinemachineVirtualCamera gamePlayCam;
    private Movement movement;
    [SerializeField] AnimationCurve speed;
    GameObject money;
    private void Start()
    {
        movement = GetComponent<Movement>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Money"))
        {
            money = other.gameObject;
            movement.SetIsTowering();
            gamePlayCam.gameObject.SetActive(false);
            StartCoroutine("TowerSequence");
        }
    }
    IEnumerator TowerSequence()
    {
        var time = 0f;
        hand.transform.DOLocalMoveX(1.3f, 1);
        hand.transform.DOLocalRotate(new Vector3(0, 0, 75), 1f);
        yield return new WaitForSeconds(1f);
        money.transform.SetParent(hand);
        while (hand.transform.position.y < 30)
        {
            hand.transform.position =new Vector3(hand.transform.position.x, speed.Evaluate(time),hand.transform.position.z);
            time += 2f*Time.deltaTime;
            yield return new WaitForSeconds(0.001f);
        }

        MoneyManager.Instance.RewardPileOfCoin(4);
    }
}
