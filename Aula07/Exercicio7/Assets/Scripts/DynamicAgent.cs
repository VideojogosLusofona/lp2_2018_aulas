/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *
 * Author: Nuno Fachada
 * */

using UnityEngine;
using UnityEngine.Events;
using System;

// This class defines movement for dynamic agents
public class DynamicAgent : MonoBehaviour
{

    // Maximum acceleration for this agent
    public float maxAccel;

    // Maximum speed for this agent
    public float maxSpeed;

    // Maximum angular acceleration for this agent
    public float maxAngularAccel;

    // Maximum rotation (angular velocity) for this agent
    public float maxRotation;

    // Current score
    public int Score { get; private set; }

    // The agent's rigid body
    public Rigidbody2D Rb { get; private set; }

    // Agent steering behaviours
    private ISteeringBehaviour[] steeringBehaviours;

    // A reference to the target
    private Target target;

    // Indicates if player is going too fast
    private bool goingTooFast;

    // This is called before Start(), so set up this object here
    private void Awake()
    {
        // Keep reference to rigid body
        Rb = GetComponent<Rigidbody2D>();

        // Get steering behaviours defined for this agent
        steeringBehaviours = GetComponents<ISteeringBehaviour>();

        // Initialize score
        Score = 0;

        // Not going too fast in the beginning
        goingTooFast = false;

        // Get reference to target
        target = GameObject.FindWithTag("Target").GetComponent<Target>();
    }

    // This method is called when the object becomes enabled and active
    private void OnEnable()
    {
        target.TargetHit += IncrementScore;
    }

    // This method is called when the behaviour becomes disabled
    private void OnDisable()
    {
        target.TargetHit -= IncrementScore;
    }

    // Increment score
    private void IncrementScore()
    {
        Score++;
        OnScoreUpdated();
    }

    // This is called every physics update
    private void FixedUpdate()
    {
        // Obtain steering behaviours
        SteeringOutput steerWeighted = new SteeringOutput();

        foreach (ISteeringBehaviour behaviour in steeringBehaviours)
        {
            SteeringOutput steer = behaviour.GetSteering(target.gameObject);
            steerWeighted = new SteeringOutput(
                steerWeighted.Linear + behaviour.Weight * steer.Linear,
                steerWeighted.Angular + behaviour.Weight * steer.Angular);
        }

        // Apply steering
        Rb.AddForce(steerWeighted.Linear);
        Rb.AddTorque(steerWeighted.Angular);

        // Limit speed
        if (Rb.velocity.magnitude > maxSpeed)
        {
            Rb.velocity = Rb.velocity.normalized * maxSpeed;
        }

        // Limit rotation (angular velocity)
        if (Rb.angularVelocity > maxRotation)
        {
            Rb.angularVelocity = maxRotation;
        }
    }

    // This is called every frame
    private void Update()
    {
        // Am I going too fast now?
        bool goingTooFastNow = Rb.velocity.magnitude > 4.0f / 5.0f * maxSpeed;

        // If there was a change from legal speed to too fast or from too fast
        // back to legal speed, start the SpeedThresholdChange event
        if (goingTooFastNow ^ goingTooFast)
        {
            // In the previous if condition we use the XOR operator which is
            // only true when the two booleans are different (which means there
            // was a change in the legality of the player's speed)

            // Change current speed situation
            goingTooFast = !goingTooFast;
            // Start speed threshold change event
            OnSpeedThresholdChange();
        }
    }

    // Sent when an incoming collider makes contact with this object's
    // collider (2D physics only)
    private void OnCollisionEnter2D(Collision2D col)
    {
        // Did we hit a wall?
        if (col.gameObject.CompareTag("Wall"))
        {
            OnHitWall(col.gameObject.name);
        }
    }

    // This is called when the score is updated
    protected virtual void OnScoreUpdated()
    {
        // We simply raise the ScoreUpdated event if there are any
        // listeners attached
        if (ScoreUpdated != null) ScoreUpdated(Score);
    }

    // This is called when the player hits a wall
    protected virtual void OnHitWall(string wall)
    {
        // Raise the HitWall event if there are any listeners attached
        if (HitWall != null) HitWall(this, new WallEventArgs(wall));
    }

    // This is called when the player goes over the speed limit or when it
    // goes back to legal speed
    protected virtual void OnSpeedThresholdChange()
    {
        if (SpeedThresholdChange != null)
            SpeedThresholdChange.Invoke(goingTooFast);
    }

    // Score update event
    public event Action<int> ScoreUpdated;

    // Wall hit event
    public event EventHandler<WallEventArgs> HitWall;

    // Speed threshold change event, when player starts going too fast or
    // when he comes back to legal speed
    public UnityEventBool SpeedThresholdChange;

    // To use UnityEvent with one or more parameters we need to create our own
    // class that extends UnityEvent<T0, ...> and make it serializable
    [Serializable]
    public class UnityEventBool : UnityEvent<bool> { }
}
