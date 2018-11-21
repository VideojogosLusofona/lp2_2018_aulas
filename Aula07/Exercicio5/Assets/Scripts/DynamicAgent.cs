/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *
 * Author: Nuno Fachada 
 * */

using UnityEngine;
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

    // This is called before Start(), so set up this object here
    private void Awake()
    {
        // Keep reference to rigid body
        Rb = GetComponent<Rigidbody2D>();

        // Get steering behaviours defined for this agent
        steeringBehaviours = GetComponents<ISteeringBehaviour>();

        // Initialize score
        Score = 0;

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

    // This is called when the score is updated
    protected virtual void OnScoreUpdated()
    {
        // We simply raise the ScoreUpdated event if there are any
        // listeners attached
        if (ScoreUpdated != null) ScoreUpdated(Score);
    }

    // Score update event
    public event Action<int> ScoreUpdated;
}
