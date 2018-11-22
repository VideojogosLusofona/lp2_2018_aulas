/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *
 * Author: Nuno Fachada
 * */

using UnityEngine;
using UnityEngine.UI;

public class HitWallTextControllerUI : MonoBehaviour
{

    // Reference to the player agent
    private DynamicAgent player;

    // Time in seconds how long the hit wall text will appear
    public float duration = 1f;

    // Reference to the hit wall text UI
    private Text hitWallTextUI;

    // This is called before Start(), so set up this object here
    private void Awake()
    {
        // Keep reference to player object
        player = GameObject.FindWithTag("Player").GetComponent<DynamicAgent>();
        // Keep reference to the text UI and remove any text
        hitWallTextUI = GetComponent<Text>();
        ClearHitWallText();
    }

    // This method is called when the object becomes enabled and active
    private void OnEnable()
    {
        player.HitWall += ShowHitWallText;
    }

    // This method is called when the behaviour becomes disabled
    private void OnDisable()
    {
        player.HitWall -= ShowHitWallText;
    }

    // Update score in text UI
    private void ShowHitWallText(object sender, WallEventArgs eventArgs)
    {
        if (IsInvoking("ClearHitWallText")) CancelInvoke("ClearHitWallText");
        hitWallTextUI.text = $"Hit {eventArgs.Wall}!";
        Invoke("ClearHitWallText", duration);
    }

    // Clear wall text
    private void ClearHitWallText()
    {
        hitWallTextUI.text = "";
    }
}
