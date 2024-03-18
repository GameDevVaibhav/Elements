using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//Some of the Combats needs player to move so this scripts moves the player.
public class CombatMovement : MonoBehaviour
{
    private Animator animator;
    private bool isSmashActive = false;
    public float jumpHeight = 1.0f;
    public float forwardDistance = 1.0f;

    void Start()
    {
        
        animator = GetComponent<Animator>();
    }

   
    public void SmashMovement()
    {
        StartCoroutine(MovePlayerUpAndLeft(0.8f));
    }

    public void SpinKickMovement()
    {
        StartCoroutine(MovePlayerUpAndLeft(0.8f));
    }

    public void LongPowerHit()
    {
        StartCoroutine(MovePlayerUpAndLeft(1.04f));
    }

    IEnumerator MovePlayerInArc(float jumpDuration)
    {
        Vector3 startPosition = transform.position;
        Vector3 maxJumpPosition = transform.position + Vector3.up * jumpHeight;

        float elapsedTime = 0f;

        while (elapsedTime < 0.04f)
        {
            transform.position = Vector3.Lerp(startPosition, maxJumpPosition, elapsedTime / 0.04f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = maxJumpPosition;

        yield return new WaitForSeconds(0.04f);

        Vector3 endPosition = startPosition - GetWorldForward() * forwardDistance;

        while (elapsedTime < jumpDuration)
        {
            transform.position = Vector3.Lerp(maxJumpPosition, endPosition, (elapsedTime - 0.08f) / (jumpDuration - 0.08f));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = endPosition;
    }

    IEnumerator MovePlayerUpAndLeft(float jumpDuration)
    {
        Vector3 startPosition = transform.position;
        Vector3 maxUpPosition = startPosition + Vector3.up * 3f;
        Vector3 endPosition = startPosition + GetWorldLeft() * forwardDistance;

        float elapsedTime = 0f;

        while (elapsedTime < jumpDuration)
        {
            float t = elapsedTime / (jumpDuration / 2f);

            if (t <= 1.0f)
            {
                transform.position = Vector3.Lerp(startPosition, maxUpPosition, t) +
                                     GetWorldLeft() * (forwardDistance / 2f) * t;
            }
            else
            {
                t = (elapsedTime - (jumpDuration / 2f)) / (jumpDuration / 2f);
                transform.position = Vector3.Lerp(maxUpPosition, endPosition, t) +
                                     GetWorldLeft() * (forwardDistance / 2f) * t;
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = endPosition;
    }

    Vector3 GetWorldForward()
    {
        return transform.TransformDirection(Vector3.forward);
    }

    Vector3 GetWorldLeft()
    {
        return Quaternion.Euler(0, -90, 0) * GetWorldForward();
    }
}
