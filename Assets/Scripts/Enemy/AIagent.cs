using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIagent : MonoBehaviour
{
    [Header("Seek")]
    public Transform target;
    public Transform player;
    [Header("Wonder")]
    public float offset = 1.0f;
    public float radius = 40.0f;
    public float jitter = 5.0f;
    private Vector3 targetDir;
    private Vector3 randomDir;
    [Header("Physics")]
    private Vector3 force;
    private Vector3 velocity;
    public float weighting = 7.5f;
    public float maxVelocity = 100f;
    public float StopingDistance = 5;

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        ComputeForces();
        HandleVelocity();
        this.gameObject.transform.LookAt(target);
    }
    void ComputeForces()
    {

        // Reset the force
        force = Vector3.zero;

        if (Vector3.Distance(player.position, this.transform.position) < 20f)
        {
            target = player;
        }
        if (target == null)
        {
            force = force + Wonder();
        }
        else
        {
            force = force + Seek();

        }
    }
    void HandleVelocity()
    {
        // Add force to velocity
        velocity += force * Time.deltaTime;
        // Truncate it if we need to
        if (velocity.magnitude > maxVelocity)
        {
            velocity = velocity.normalized * maxVelocity;
        }
        // Check if velocity is valid
        if (velocity != Vector3.zero)
        {

            // Add position
            transform.position += velocity * Time.deltaTime;
            // Add rotation
            transform.rotation = Quaternion.LookRotation(velocity);
            if (target != null)
            {
                if (Vector3.Distance(target.position, transform.position) < StopingDistance)
                {

                    velocity = Vector3.zero;// change the velocity of the enemy to 0;
                    Attack();
                }
            }
        }

    }
    #region Movement
    public Vector3 Wonder()
    {
        Vector3 WonderForce = Vector3.zero;


        float randX = Random.Range(0, 0x7fff) - (0x7fff * 0.5f);
        float randY = 0;
        float randZ = Random.Range(0, 0x7fff) - (0x7fff * 0.5f);

        #region Calculate RandomDir
        // Create the random directon vector
        randomDir = new Vector3(randX, randY, randZ);
        // Normalize the random direction
        randomDir = randomDir.normalized;
        // Multiply jitter to randomDir
        randomDir *= jitter;
        #endregion

        #region Calculate TargetDir
        // Append target dir with random dir
        targetDir += randomDir;
        // Normalize the target dir
        targetDir.Normalize();
        // Amplify it by the radius
        targetDir *= radius;
        #endregion

        // Calculate seek position using targetDir
        Vector3 seekPos = transform.position + targetDir;
        seekPos += transform.forward.normalized * offset;

        // Calculate direction
        Vector3 desiredForce;
        Vector3 direction = seekPos - transform.position;

        // Check if direction is valid
        if (direction != Vector3.zero)
        {
            desiredForce = direction.normalized * weighting;
            WonderForce = desiredForce - velocity;
        }

        return WonderForce;
    }
    public Vector3 Seek()
    {
        float slowingDistance = 5;
        // Create a new force to calculate
        Vector3 SeekForce = Vector3.zero;



        // If there is no target, return zero
        if (target == null) return SeekForce;

        // Otherwise, calculate a desired force
        Vector3 desiredForce;
        // Get the direction from target to agent
        Vector3 direction = target.position - transform.position;


        // Check if the direction is valid
        if (direction != Vector3.zero)
        {
            // calculate distance and change the desireForce depending on the distace
            if (direction.magnitude < slowingDistance)
            {
                desiredForce = direction.normalized * weighting * (direction.magnitude / slowingDistance);
            }
            else
            {
                desiredForce = direction.normalized * weighting;

            }
            SeekForce = desiredForce - velocity;

        }

        // Return the force!
        return SeekForce;
    }
    #endregion
    public virtual void Attack()
    {

    }
}


