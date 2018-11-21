using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugBehaviour : MonoBehaviour
{

    // Reference to the player agent
    private DynamicAgent player;

    // The target object
    private Target target;

    // This is called before Start(), so set up this object here
    private void Awake()
    {
        target = GameObject.FindWithTag("Target").GetComponent<Target>();
        player = GameObject.FindWithTag("Player").GetComponent<DynamicAgent>();
    }

    // This method is called when the object becomes enabled and active
    private void OnEnable()
    {
        target.TargetHit += DebugTargetHit;
        player.ScoreUpdated += DebugScoreUpdated;
        player.HitWall += DebugHitWall;
    }

    // This method is called when the behaviour becomes disabled
    private void OnDisable()
    {
        target.TargetHit -= DebugTargetHit;
        player.ScoreUpdated -= DebugScoreUpdated;
    }

    // Log that the target was hit
    private void DebugTargetHit()
    {
        // Schedule target activation
        Debug.Log("Target was hit!");
    }

    // Log that the score was updated
    private void DebugScoreUpdated(int updatedScore)
    {
        // Schedule target activation
        Debug.Log($"Score was updated to {updatedScore}");
    }

    // Log that player hit a wall
    private void DebugHitWall(object sender, WallEventArgs eventArgs)
    {
        Debug.Log(
            $"Hit {eventArgs.Wall} (event sent by {sender.GetType().Name})");
    }

}
