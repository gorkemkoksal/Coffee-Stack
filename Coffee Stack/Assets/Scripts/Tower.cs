using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // �imdilik �st �stte olu�turma kodunu ayarlad�m ilerleyen zamanlarda kamera ile birlikte y�kselmesini vs ayarlamak laz�m

    public GameObject objectPrefab;
    public Transform spawnPoint;
    public float delay = 0f;
    public float pos = 0f;




    void Start()
    {
        NumberOfTower();
    }

    void NumberOfTower(int num = 10)
    {
        // num adet objePrefab kopyas� olu�tur
        for (int i = 0; i < num; i++)
        {
            // Olu�turma gecikmesi s�resince bekle
            float delayTime = i * delay;
            Invoke("MakeTower", delayTime);
        }
    }

    void MakeTower()
    {
        // Prefab objesinin kopyas�n� spawn noktas�nda olu�tur
        GameObject newObject = Instantiate(objectPrefab, spawnPoint.position, Quaternion.identity);

        // Yeni objenin konumunu ayarla
        Vector3 newPos = newObject.transform.position;
        pos += 1f;
        newPos.y += pos; // Y ekseninde pos birim kadar yukar�da olu�tur
        newObject.transform.position = newPos;
    }
}
