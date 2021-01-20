using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    [SerializeField] private float speed = 1f;
    [SerializeField] float jumpForce = 10f;
    Rigidbody myRigidBody;
    bool gameOver = false;

    Vector3 movement;

    // Start is called before the first frame update
    void Awake()
    {
        myRigidBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        myRigidBody.velocity = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        var xDir = Input.GetAxis("Vertical");
        var zDir = Input.GetAxis("Horizontal");

        myRigidBody.velocity = new Vector3(-xDir * speed * Time.deltaTime, myRigidBody.velocity.y, zDir * speed * Time.deltaTime);


        if (Input.GetKey(KeyCode.Space))
        {
            //JumpLerp();
            
            //myRigidBody.AddForce(0, jumpForce, 0);
        }

        if(myRigidBody.position.y < -1)
        {
            gameOver = true;
            ResetPosition();
        }

        
    }

    private void JumpLerp()
    {
        var start = myRigidBody.transform.position;
        myRigidBody.transform.position = Vector3.Slerp(start, new Vector3(myRigidBody.transform.position.x, jumpForce, myRigidBody.transform.position.z), 10);
        //myRigidBody.transform.position = new Vector3(0, jumpForce, 0);
    }

    private void ResetPosition()
    {
        myRigidBody.velocity = new Vector3(0, 0, 0);
        transform.position = new Vector3(0f, 0.434293f, 0f);
    }
}
