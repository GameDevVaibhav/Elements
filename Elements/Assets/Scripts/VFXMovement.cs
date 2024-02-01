using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXMovement : MonoBehaviour
{
    public string targetTag = "Opponent";
    public float speed = 5f;
    public float delay;
    public float moveUpDuration = 0.9f; // Duration for the upward movement
    public float height;

    private Transform target;
    private bool hasMovedUp = false;
    public float time = 1.0f;
     

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

    IEnumerator MoveUp()
    {
        if (!hasMovedUp)
        {
            float elapsedTime = 0f;
            Vector3 startPosition = transform.position;
            Vector3 targetPosition = transform.position + Vector3.up * height;

            while (elapsedTime < moveUpDuration)
            {
                float t = elapsedTime / moveUpDuration;
                transform.position = Vector3.Lerp(startPosition, targetPosition, t);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = targetPosition;
            hasMovedUp = true;
        }
    }

    public void  MoveInArc()
    {
       


    }

    

    private IEnumerator MoveAfterDelay()
    {
        if (gameObject.CompareTag("Rock_Hit"))
        {
            yield return MoveUp();
        }
       

        yield return new WaitForSeconds(delay);
        MoveTowardsTarget();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Opponent"))
        {
            Destroy(gameObject);
        }
    }
}
