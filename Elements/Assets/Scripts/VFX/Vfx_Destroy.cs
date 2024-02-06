using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vfx_Destroy : MonoBehaviour
{
    public float delay;
    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine( VfxDestroyAfterDelay());
    }

    

    IEnumerator VfxDestroyAfterDelay()
    {
        yield return new WaitForSeconds(delay);

        Destroy(gameObject);
    }
}
