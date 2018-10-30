using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wonder : MonoBehaviour {

    [SerializeField]
    private float maxTime = 10;
    [SerializeField]
    private float minTime = 5;
    [SerializeField]
    private float range = 120;

    private Vector3 originPos;
    private Vector3 curPos;
    private Vector3 targetPos;
    private float curTime = 0;
    private float moveTime = 0;
    private float stopTime = 0;

	void Start ()
    {
        originPos = transform.position;
	}

	void Update ()
    {
		if(curTime >= moveTime + stopTime)
        {
            curPos = transform.position;
            targetPos = originPos + Random.insideUnitSphere * range;
            moveTime = Random.Range(minTime, maxTime);
            stopTime = Random.Range(minTime, maxTime);
            curTime = 0;
        }
        else
        {
            curTime += Time.deltaTime;
            transform.position = Vector3.Lerp(curPos, targetPos, curTime / moveTime);
        }
	}
}
