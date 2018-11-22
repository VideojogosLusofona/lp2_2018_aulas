/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *
 * Author: Nuno Fachada 
 * */

using UnityEngine;
using UnityEngine.UI;

// Controls when to spawn a static target
public class TargetController : MonoBehaviour
{

    // How long between target destruction and target spawn
    public float delay;

    // The game area
    private GameArea gameArea;

    // The target object
    private Target target;

    // This is called before Start(), so set up this object here
    private void Awake()
    {
        gameArea = new GameArea();
        target = GameObject.FindWithTag("Target").GetComponent<Target>();
    }

    // Spawn the first target
    private void Start()
    {
        SpawnTarget();
    }

    // This method is called when the object becomes enabled and active
    private void OnEnable()
    {
        target.TargetHit += InvokeSpawnTarget;
    }

    // This method is called when the behaviour becomes disabled
    private void OnDisable()
    {
        target.TargetHit -= InvokeSpawnTarget;
    }

    // Invoke the SpawnTarget method with the specified delay
    private void InvokeSpawnTarget()
    {
        // Schedule target activation
        Invoke("SpawnTarget", delay);
    }

    // Spawn the target at a random location
    private void SpawnTarget()
    {
        target.transform.position = gameArea.RandomPosition(0.9f);
        target.Activate();
    }

}
