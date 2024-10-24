using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeAhead : MonoBehaviour
{
    public GameObject targetObj;  // 目标对象
    private Vector3 startPosition; // 初始位置

    // Start is called before the first frame update
    void Start()
    {
        // 初始化对象的初始位置
        startPosition = targetObj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // 沿着X轴移动 (可以调节速度speed)
        float speed = 5.0f;  // 速度
        targetObj.transform.position = startPosition + new Vector3(Time.time * speed, 0, 0);
    }
}