using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int amount = 200;
    public float burnRange = 100;

    public Transform target;

    private int count = 0;

    void Update()
    {
        if (Input.GetKeyDown("space"))
            AddShips();
    }

    void AddShips()
    {
        for (int i = 0; i < amount; i++)
        {
            Vector3 pos = Random.insideUnitSphere * 100;
            var obj = Instantiate(bulletPrefab, pos, Quaternion.identity) as GameObject;

            Movement movement = obj.GetComponent<Movement>();
            movement.Target = target;
        }
        count += amount;
    }

    private void OnGUI()
    {
        GUILayout.Label(string.Format("Amoun: {0}", count));
    }
}
