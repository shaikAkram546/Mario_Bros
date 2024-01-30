using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public Transform cameraChild;
    public float resetSpeed = 0.5f;
    public float camreaSpeed = 0.3f;
    public Bounds cameraBounds;
    private Transform target1;
    public Transform lastPosition;
    public LayerMask lastLayer;


    private float offsetZ;
    private Vector3 lastTargetPosition;
    private Vector3 currentVelocity;
    private bool followsPlayer;
    
    private void Awake()
    {
        BoxCollider2D myCol = GetComponent<BoxCollider2D>();
        myCol.size = new Vector2(Camera.main.aspect * 2f * Camera.main.orthographicSize, 0.18f);
        cameraBounds = myCol.bounds;


    }
    private void Start()
    {
        
        target1 = GameObject.FindGameObjectWithTag(Tags.player_tag).transform;
        lastTargetPosition = target1.position;
        offsetZ = (transform.position - target1.position).z;
        followsPlayer = true;
    }
    private void Update()
    {
        detectCol();
    }
    private void FixedUpdate()
    {
        if (followsPlayer)
        {
            Vector3 aheadTargetPos = target1.position + Vector3.forward * offsetZ;
            if (aheadTargetPos.x >= transform.position.x)
            {
                Vector3 newCameraPosition = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref currentVelocity, camreaSpeed);
                transform.position = new Vector3(newCameraPosition.x, transform.position.y, newCameraPosition.z);
                lastTargetPosition = target1.position;
            }
        }
    }
   void detectCol()
    {
        if(Physics2D.Raycast(cameraChild.position, Vector2.left, 0.01f, lastLayer))
        {
           // print("called");
            followsPlayer = false;

        }

        
    }



}
