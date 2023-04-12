using DG.Tweening;
using UnityEngine;

public class Collision : MonoBehaviour
{
    bool isMilkshake;
    bool isEnded;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cup"))
        {
            if (!StackManager.Instance.cups.Contains(other.gameObject))
            {
                //   other.GetComponent<BoxCollider>().isTrigger = false;
                other.gameObject.tag = "HandedCup";
                other.gameObject.AddComponent<Collision>();
                //   var rb = other.gameObject.AddComponent<Rigidbody>();
                var rb = other.gameObject.GetComponent<Rigidbody>();
                rb.isKinematic = true;

                StackManager.Instance.StackCube(other.gameObject, StackManager.Instance.cups.Count - 1);
                AudioManager.Instance.audioSource.PlayOneShot(AudioManager.Instance.takingCup, 1f);
                MoneyManager.Instance.GetMoney(1);

            }
        }
        else if (other.CompareTag("Filler"))
        {
            if (isMilkshake) return;

            //for (int i = 0; i < transform.childCount; i++)
            //{
            //transform.GetChild(i).gameObject.SetActive(false);
            //}
            //transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
            AudioManager.Instance.audioSource.PlayOneShot(AudioManager.Instance.pooring, 1f);
            MoneyManager.Instance.GetMoney(1);
        }
        else if (other.CompareTag("Milkshake"))
        {
            if (isMilkshake) return;
            isMilkshake = true;

            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
            transform.GetChild(3).gameObject.SetActive(true);
            MoneyManager.Instance.GetMoney(1);
        }
        else if (other.CompareTag("Packager"))
        {
            //if (isMilkshake)
            //{
            //    transform.GetChild(3).gameObject.SetActive(false);
            //    transform.GetChild(4).gameObject.SetActive(true);
            //    MoneyManager.Instance.GetMoney(1);                                        paraaaaaaaaaaaaaaa
            //}

            //else if(transform.GetChild(0).gameObject.activeSelf || transform.GetChild(1).gameObject.activeSelf)
            //{
            //    for (int i = 0; i < transform.childCount; i++)
            //    {
            //        transform.GetChild(i).gameObject.SetActive(false);
            //    }
            //    transform.GetChild(2).gameObject.SetActive(true);            
            //}
            MoneyManager.Instance.GetMoney(1);
            transform.GetChild(2).gameObject.SetActive(true);
            AudioManager.Instance.audioSource.PlayOneShot(AudioManager.Instance.packaging, 1f);
        }
        else if (other.CompareTag("LevelEnd"))
        {
            if (isEnded) { return; }
            isEnded = true;
            var movement = transform.parent.GetComponent<Movement>();
        }
    }
}
