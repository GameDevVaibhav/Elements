using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXMovement : MonoBehaviour
{
    public string targetTag = "Opponent"; 
    public float speed = 5f;
    public float delay;

    private Transform target;

    void Start()
    {
        FindTarget();
    }

    void Update()
    {
        StartCoroutine(MoveAfterDelay());
    }

    void FindTarget()
    {
        
        GameObject targetObject = GameObject.FindGameObjectWithTag(targetTag);
        if (targetObject != null)
        {
            Debug.Log("found");
            target = targetObject.transform;
        }
    }

    void MoveTowardsTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private IEnumerator MoveAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        MoveTowardsTarget();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Opponent"))
        {
            Destroy(gameObject);
        }
    }
}
