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
        //else if (other.CompareTag("Filler"))
        //{
        //    transform.GetChild(0).gameObject.SetActive(false);   buralar mesh gelsin oyle simdi ne yapsam bos
        //    transform.GetChild(1).gameObject.SetActive(true);
        //}
    }
}
