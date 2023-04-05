using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cup"))
        {
            if (!ATMRush.Instance.cups.Contains(other.gameObject))
            {
                //   other.GetComponent<BoxCollider>().isTrigger = false;
                other.gameObject.tag = "Untagged";
                other.gameObject.AddComponent<Collision>();
                var rb = other.gameObject.AddComponent<Rigidbody>();
                rb.isKinematic = true;

                ATMRush.Instance.StackCube(other.gameObject, ATMRush.Instance.cups.Count - 1);

            }
        }
        else if (other.CompareTag("Filler"))
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (other.CompareTag("Packaging"))
        {
            if (transform.GetChild(3).gameObject.activeSelf)
            {
                transform.GetChild(3).gameObject.SetActive(false);
                transform.GetChild(4).gameObject.SetActive(true);
            }
            else if(transform.GetChild(0).gameObject.activeSelf || transform.GetChild(1).gameObject.activeSelf)
            {
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(true);
            }
        }
    }
}
