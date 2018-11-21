/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *
 * Author: Nuno Fachada 
 * */
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

}
