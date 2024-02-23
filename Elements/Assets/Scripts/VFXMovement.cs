using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class VFXMovement : MonoBehaviour
{
    public string targetTag = "Opponent";
    public float speed = 5f;
    public float delay;
    public float moveUpDuration;
    public float height;

    private Transform target;
    private bool hasMovedUp = false;
    public float time;

    PhotonView vfxPV;
    PlayerController[] players;
    string vfxOwner;
    [SerializeField]
    float damage;

    void Start()
    {
        vfxPV = GetComponent<PhotonView>();
        vfxOwner = vfxPV.Owner.ToString();

        players= FindObjectsOfType<PlayerController>();

        FindTarget();
        
    }

    void Update()
    {
      
        
            StartCoroutine(MoveAfterDelay());
        

    }

    void FindTarget()
    {
        
        
        
        foreach (PlayerController player in players)
        {
            PhotonView playerPV = player.GetComponent<PhotonView>();
            if(vfxOwner== "#02 'Player2'")
            {
                if(playerPV.Owner.ToString()== "#01 'Player1'")
                {
                    target = player.transform;
                }
            }
            else if (vfxOwner == "#01 'Player1'")
            {
                if (playerPV.Owner.ToString() == "#02 'Player2'")
                {
                    target = player.transform;
                }
            }
        }
        

        
    }

    void MoveTowardsTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    IEnumerator MoveUp()
    {
        Debug.Log("Moved up");
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



    

    private IEnumerator MoveAfterDelay()
    {
        if (gameObject.CompareTag("Rock_Hit"))
        {
            Debug.Log("Its rockhit");
            yield return MoveUp();
        }



        yield return new WaitForSeconds(delay);
        MoveTowardsTarget();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        PhotonView playerPV = collision.gameObject.GetComponent<PhotonView>();
        string playerName = playerPV.Owner.ToString();

        if (playerName == "#01 'Player1'")
        {
            if (vfxOwner == "#02 'Player2'")
            {
                Debug.Log("Ball Hit Player1");
                playerPV.RPC("TakeDamageRPC", RpcTarget.OthersBuffered, playerName, damage);
                Destroy(gameObject);
            }

        }
        else if (playerName == "#02 'Player2'")
        {
            if (vfxOwner == "#01 'Player1'")
            {
                Debug.Log("Ball Hit Player2");
                playerPV.RPC("TakeDamageRPC", RpcTarget.OthersBuffered, playerName, damage);
                Destroy(gameObject);
            }

        }
    }

    
}
