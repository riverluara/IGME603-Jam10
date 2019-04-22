using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that serves as a maintenance of player movement by detected input and
/// applying movement forces
/// </summary>
[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour {

    // CLASSES
    /// <summary>
    /// The set of key codes for controller inputs
    /// </summary>
    [Serializable]
    public class ControlInputs
    {
        [SerializeField] public KeyCode leftKey = KeyCode.A;
        [SerializeField] public KeyCode rightKey = KeyCode.D;
        [SerializeField] public KeyCode upKey = KeyCode.W;
        [SerializeField] public KeyCode downKey = KeyCode.S;
    }


    // CONSTANTS
    #region Constants
    private const float _DEFAULT_MAXSPEED = 10f;
    private const float _DEFAULT_FRICTION = 7f;
    private const float _DEFAULT_WALK = 5f;
    private const float _DEFAULT_CLAMP_STOP = 0.01f;
    private const float _DEFAULT_SNAP_ANGLE = 45f;
    #endregion

    // FIELDS and MEMBERS
    #region Fields
    public GameObject playerModel;
    [SerializeField] private ControlInputs inputs;

    public float mass = 1f;
    [SerializeField] private float maxSpeed = _DEFAULT_MAXSPEED;
    [SerializeField] private float frictionForce = _DEFAULT_FRICTION;
    [SerializeField] private float walkForce = _DEFAULT_WALK;
    public float squareForceToClampAt = _DEFAULT_CLAMP_STOP;

    private Vector3 applyForce = Vector3.zero;
    private Vector3 velocity = Vector3.zero;
    private Vector3 direction;
    private Vector3 rotation;
    private Vector3 acceleration;
    private Vector3 position;
    public float rotationSnapAngle = _DEFAULT_SNAP_ANGLE;

    private Rigidbody rigidPlayer;
    #endregion


    // METHODS
    #region Methods
    // Use this for initialization
    void Start() {
        rigidPlayer = GetComponent<Rigidbody>();
        direction = transform.forward;
        velocity = Vector3.zero;
        acceleration = Vector3.zero;

        ValidateFields();
    }

    void FixedUpdate()
    {
        position = transform.position;
        ResetForces();

        // Apply various forces based off of the various types of input that could
        // be going on at any given moment
        if (Input.GetAxisRaw("Horizontal") != 0f || Input.GetAxisRaw("Vertical") != 0f)
        {
            ApplyWalkForce();
        }
        else if (velocity.sqrMagnitude != 0f)
        {
            ApplyFrictionForce();
        }

        ApplyForces();
        MovePlayer();
    }


    /// <summary>
    /// Validate input fields to make sure that they are working properly prior to updates
    /// </summary>
    private void ValidateFields()
    {
        // Maximum speed
        if (maxSpeed < 0f)
        {
            maxSpeed *= -1f;
        }
        else if (maxSpeed == 0f)
        {
            maxSpeed = _DEFAULT_MAXSPEED;
        }

        // Frictional force
        if (frictionForce < 0f)
        {
            frictionForce *= -1f;
        }
        else if (frictionForce == 0f)
        {
            frictionForce = _DEFAULT_FRICTION;
        }

        // Walking force
        if (walkForce < 0f)
        {
            walkForce *= -1f;
        }
        else if (walkForce == 0f)
        {
            walkForce = _DEFAULT_WALK;
        }
    }


    /// <summary>
    /// Apply the forces that occur when the player walks
    /// </summary>
    private void ApplyWalkForce()
    {
        // Left
        if (Input.GetKey(inputs.leftKey))
        {
            AddForce(Vector3.left * walkForce);
        }
        // Right
        if (Input.GetKey(inputs.rightKey))
        {
            AddForce(Vector3.right * walkForce);
        }
        // Up
        if (Input.GetKey(inputs.upKey))
        {
            AddForce(Vector3.forward * walkForce);
        }
        // Down
        if (Input.GetKey(inputs.downKey))
        {
            AddForce(Vector3.back * walkForce);
        }

        // Horizontal controller input
        if (!Input.GetKey(inputs.leftKey) && !Input.GetKey(inputs.rightKey)
            && Input.GetAxisRaw("Horizontal") != 0f)
        {
            AddForce(Vector3.right * Input.GetAxisRaw("Horizontal") * walkForce);
        }

        // Vertical controller input
        if (!Input.GetKey(inputs.upKey) && !Input.GetKey(inputs.downKey)
            && Input.GetAxisRaw("Vertical") != 0f)
        {
            AddForce(Vector3.forward * Input.GetAxisRaw("Vertical") * walkForce);
        }
    }


    /// <summary>
    /// Apply forces to slow down the player character
    /// </summary>
    private void ApplyFrictionForce()
    {
        if (applyForce.sqrMagnitude == 0f)
        {
            // Test whether the initial values are positive or negative
            Vector3 frictionToApply = velocity.normalized * -1f * frictionForce;
            Debug.Log("Applying " + frictionToApply + " friction");
            Vector3 velocityBefore = new Vector3(
                velocity.x > 0f ? 1f : 0f,
                0f,
                velocity.z > 0f ? 1f : 0f);

            Vector3 velocityAfter = (frictionToApply / mass) * Time.deltaTime;
            velocityAfter = new Vector3(
                velocityAfter.x > 0f ? 1f : 0f,
                0f,
                velocityAfter.z > 0f ? 1f : 0f);

            // Have the values switched?
            if (velocityBefore.x != velocityAfter.x)
            {
                frictionToApply.x = 0f;
            }
            if (velocityBefore.z != velocityAfter.z)
            {
                frictionToApply.z = 0f;
            }

            // If the velocity is not to default to zero quite yet,
            // zero out the velocity
            if (frictionToApply.sqrMagnitude == 0f)
            {
                //Debug.Log("ZER0-ING FRICTION");
                velocity = Vector3.zero;
                return;
            }
            else
            {
                AddForce(frictionToApply);

                //Debug.Log("Applying " + applyForce.normalized * -1f * frictionForce + "\nForce after friction applied is " + applyForce);
            }
        }
        else
        {

        }
    }


    /// <summary>
    /// Add all of the forces to the acceleration
    /// </summary>
    private void ApplyForces()
    {
        acceleration += applyForce / mass;
    }


    /// <summary>
    /// Final application of player velocity to the rigidbody
    /// </summary>
    private void MovePlayer()
    {
        UpdatePosition();
        SetTransform();
    }


    /// <summary>
    /// Add a force to the force to be applied at the end of the frame
    /// </summary>
    /// <param name="forceToAdd">Force to add to applyForce</param>
    private void AddForce(Vector3 forceToAdd)
    {
        applyForce += forceToAdd;
    }


    /// <summary>
    /// Update the internal position components
    /// </summary>
    private void UpdatePosition()
    {
        // Accumulation of acceleration changes the velocity
        velocity += acceleration * Time.deltaTime;
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        position += velocity * Time.deltaTime;
        direction = velocity.normalized;
    }


    /// <summary>
    /// Update the character's transform using the internal position components
    /// </summary>
    private void SetTransform()
    {
        // Set the direction of the character
        if (direction.sqrMagnitude == 0)
        {
            direction = playerModel.transform.forward;
        }
        else
        {
            direction.y = 0f;
            playerModel.transform.forward = direction;
        }

        // Use the rigidbody to move the character
        rigidPlayer.MovePosition(position);
    }


    /// <summary>
    /// Reset the temporary movement calculations
    /// </summary>
    private void ResetForces()
    {
        applyForce = Vector3.zero;
        acceleration = Vector3.zero;
    }


    /// <summary>
    /// Detect collisions with other objects
    /// </summary>
    /// <param name="collision">Object collided with</param>
    void OnTriggerStay(Collider collision) {

        Transform parent = collision.gameObject.transform.parent;

        // Detect if the Player collided into a fight-triggering object
        if (parent != null)
        {
            if (parent.name == "Nodes")
            {
                if (Input.GetKeyDown(KeyCode.J))
                {
                    NodeManager.getInstance().loadScene(collision.gameObject);
                }
            }
        }
    }
    #endregion
}
