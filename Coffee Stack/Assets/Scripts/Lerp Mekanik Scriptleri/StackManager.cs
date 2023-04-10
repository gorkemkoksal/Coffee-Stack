using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StackManager : MonoBehaviour
{
    public List<GameObject> cups = new List<GameObject>();

    [SerializeField] private float movementDelay = 0.25f;

    public static StackManager Instance;
    private void Awake()
    {
        DOTween.SetTweensCapacity(4000, 50);

        if (Instance == null)
            Instance = this;
    }
    private void OnEnable()
    {
        InputManager.onAnyTouch += InputManager_onAnyTouch;
        cups.Add(transform.GetChild(1).gameObject);
    }
    private void OnDisable()
    {
        InputManager.onAnyTouch -= InputManager_onAnyTouch;
    }
    private void InputManager_onAnyTouch(float input)
    {
        if (input != 0)
        {
            MoveCupsInTheList();
        }
        else
        {
            MoveOrigin();
        }
    }

    //void Update()
    //{
    //    if (Input.GetKey(KeyCode.Mouse0))
    //    {
    //        MoveCupsInTheList();
    //    }

    //    if (Input.GetMouseButtonUp(0))
    //    {
    //        MoveOrigin();
    //    }
    //}

    public void StackCube(GameObject other, int index)
    {
        other.transform.parent = transform;
        Vector3 newPos = cups[index].transform.localPosition;
        newPos.y = 0;
        newPos.z += other.transform.localScale.z;                          //generic olsun diye denedim
        other.transform.localPosition = newPos;
        cups.Add(other);

        StartCoroutine(MakeObjectsBigger());
    }

    private IEnumerator MakeObjectsBigger()
    {
        for (int i = cups.Count - 1; i > 0; i--)
        {
            var index = i;
            var scale = Vector3.one;   //buraya meshler gelince ayar cekmek gerekicek
            scale *= 1.5f;

            cups[index].transform.DOScale(scale, 0.1f).OnComplete(() =>
             cups[index].transform.DOScale(Vector3.one, 0.1f));

            yield return new WaitForSeconds(0.05f);
        }
    }

    private void MoveCupsInTheList()
    {
        for (int i = 1; i < cups.Count; i++)
        {
            var pos = cups[i].transform.localPosition;
            pos.x = cups[i - 1].transform.localPosition.x;
            cups[i].transform.DOLocalMove(pos, movementDelay);
        }

    }

    private void MoveOrigin()
    {
        for (int i = 1; i < cups.Count; i++)
        {
            var pos = cups[i].transform.localPosition;
            pos.x = cups[0].transform.localPosition.x;
            cups[i].transform.DOLocalMove(pos, 0.70f);
        }
    }
    public void RemoveCup(GameObject cup)
    {
        cups.Remove(cup);
    }
}
