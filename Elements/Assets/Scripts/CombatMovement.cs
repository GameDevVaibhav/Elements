using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMovement : MonoBehaviour
{
    private Animator animator;
    private bool isSmashActive = false;
    public float jumpHeight = 1.0f;  // Adjust the jump height as needed
    public float forwardDistance = 1.0f;  // Adjust the forward distance as needed
    public float jumpDuration = 1.02f;  // Adjust the total jump duration as needed

    void Start()
    {
        // Get the Animator component.
        animator = GetComponent<Animator>();
    }

    // Called from Animation Event in the "Smash" animation timeline.
    public void SmashMovement()
    {
        StartCoroutine(MovePlayerInArc());
    }

    IEnumerator MovePlayerInArc()
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

        // Ensure the player reaches the exact end position.
        transform.position = endPosition;

        // Remember to set isSmashActive back to false after the movement is complete.
    }
}
