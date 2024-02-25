using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using static UnityEngine.GraphicsBuffer;

public class LightningPoints : MonoBehaviour
{
    // Reference to the VisualEffect component
    private VisualEffect visualEffect;

    // Reference to the GameObject whose transform will be used
    GameObject targetObject;

   public Vector3 offset;

    Transform target;
    

    // Start is called before the first frame update
    void Start()
    {
        // Get the VisualEffect component attached to this GameObject
        visualEffect = GetComponent<VisualEffect>();
        

        FindTarget();
    }

   
    void Update()
    {
        if (visualEffect != null )
        {
            
            visualEffect.SetVector3("Pos1", target.transform.position+offset);
           
        }
        else
        {
            Debug.LogError("VisualEffect component or targetObject not found!");
        }
    }

    void FindTarget()
    {
        PhotonView pv = GetComponentInParent<PhotonView>();

        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        Debug.Log(players.Length);

        
       

        foreach (GameObject player in players)
        {
            PhotonView playerPV = player.GetComponent<PhotonView>();
            Debug.Log(player.gameObject.transform.position);

            if (pv.Owner.ToString() == "#02 'Player2'")
            {
                if (playerPV.Owner.ToString() == "#01 'Player1'")
                {
                    target = player.gameObject.transform;
                    
                }


            }
            else if (pv.Owner.ToString() == "#01 'Player1'")
            {
                if (playerPV.Owner.ToString() == "#02 'Player2'")
                {
                    target = player.gameObject.transform;
                    
                }
            }



        }
    }
}
