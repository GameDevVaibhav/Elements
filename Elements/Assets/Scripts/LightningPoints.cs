using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class LightningPoints : MonoBehaviour
{
    // Reference to the VisualEffect component
    private VisualEffect visualEffect;

    // Reference to the GameObject whose transform will be used
     GameObject targetObject;
    public string targetTag;

    // Start is called before the first frame update
    void Start()
    {
        // Get the VisualEffect component attached to this GameObject
        visualEffect = GetComponent<VisualEffect>();
        targetObject = GameObject.FindGameObjectWithTag(targetTag);

       
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the VisualEffect component and targetObject are not null
        if (visualEffect != null && targetObject != null)
        {
            // Set the Vector3 property of the VisualEffect component to the position of the targetObject
            visualEffect.SetVector3("Pos1", targetObject.transform.position);
        }
        else
        {
            Debug.LogError("VisualEffect component or targetObject not found!");
        }
    }
}
