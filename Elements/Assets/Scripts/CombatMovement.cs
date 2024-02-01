using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMovement : MonoBehaviour
{
    private Animator animator;
    private bool isSmashActive = false;
    public float jumpHeight = 1.0f;  // Adjust the jump height as needed
    public float forwardDistance = 1.0f;  // Adjust the forward distance as needed
      // Adjust the total jump duration as needed

    void Start()
    {
        // Get the Animator component.
        animator = GetComponent<Animator>();
    }

    // Called from Animation Event in the "Smash" animation timeline.
    public void SmashMovement()
    {
        StartCoroutine(MovePlayerInArc(1.02f));
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

        // Move up to max jump height (0.04 seconds)
        while (elapsedTime < 0.04f)
        {
            transform.position = Vector3.Lerp(startPosition, maxJumpPosition, elapsedTime / 0.04f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the player reaches the max jump position
        transform.position = maxJumpPosition;

        // Stay at max jump position (0.04 to 0.08 seconds)
        yield return new WaitForSeconds(0.04f);

        // Come down from max jump height (0.08 to 1.02 seconds)
        Vector3 endPosition = startPosition - Vector3.right * forwardDistance;

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
        Vector3 endPosition = startPosition + Vector3.left * forwardDistance;

        float elapsedTime = 0f;
        
        while (elapsedTime < jumpDuration)
        {
            float t = elapsedTime / (jumpDuration / 2f); // Adjust duration for half the time on the way up

            // Interpolate both vertical and horizontal movements forming an arc
            if (t <= 1.0f)
            {
                transform.position = Vector3.Lerp(startPosition, maxUpPosition, t) +
                                     Vector3.left * (forwardDistance / 2f) * t; // Cover half the horizontal distance on the way up
            }
            else
            {
                // On the way down, cover the remaining half of the horizontal distance
                t = (elapsedTime - (jumpDuration / 2f)) / (jumpDuration / 2f);
                transform.position = Vector3.Lerp(maxUpPosition, endPosition, t) +
                                     Vector3.left * (forwardDistance / 2f) * t;
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the player reaches the end position
        transform.position = endPosition;
    }
}
