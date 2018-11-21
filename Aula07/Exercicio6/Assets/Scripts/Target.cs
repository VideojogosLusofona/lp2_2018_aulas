/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *
 * Author: Nuno Fachada 
 * */

using UnityEngine;
using System;

// Defines a static target
public class Target : MonoBehaviour
{
    // Activate target
    public void Activate() {
        gameObject.SetActive(true);
    }

    // Target is deactivated if someone collides with it
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Deactive target
        gameObject.SetActive(false);
        // Notify listeners that target was hit
        OnTargetHit();
    }

    // This is called when target is hist
    protected virtual void OnTargetHit()
    {
        if (TargetHit != null) TargetHit();
    }

    // Event raised when target is hit
    public event Action TargetHit;
}
