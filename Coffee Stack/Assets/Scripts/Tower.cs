using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // Þimdilik üst üstte oluþturma kodunu ayarladým ilerleyen zamanlarda kamera ile birlikte yükselmesini vs ayarlamak lazým

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
        // num adet objePrefab kopyasý oluþtur
        for (int i = 0; i < num; i++)
        {
            // Oluþturma gecikmesi süresince bekle
            float delayTime = i * delay;
            Invoke("MakeTower", delayTime);
        }
    }

    void MakeTower()
    {
        // Prefab objesinin kopyasýný spawn noktasýnda oluþtur
        GameObject newObject = Instantiate(objectPrefab, spawnPoint.position, Quaternion.identity);

        // Yeni objenin konumunu ayarla
        Vector3 newPos = newObject.transform.position;
        pos += 1f;
        newPos.y += pos; // Y ekseninde pos birim kadar yukarýda oluþtur
        newObject.transform.position = newPos;
    }
}
