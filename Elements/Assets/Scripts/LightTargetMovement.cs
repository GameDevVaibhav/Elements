using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LightTargetMovement : MonoBehaviour
{
    Transform target;
    public float speed;
    void Start()
    {
        GameObject targetObject= GameObject.FindGameObjectWithTag("Opponent");
        target = targetObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);
    }
    
}
