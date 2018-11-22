/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *
 * Author: Nuno Fachada
 * */
using UnityEngine;
using UnityEngine.UI;

public class TooFastTextUI : MonoBehaviour
{

    // Reference to the text UI
    private Text tooFastTexttUI;

    // This is called before Start(), so set up this object here
    private void Awake()
    {
        // Keep reference to the text UI
        tooFastTexttUI = GetComponent<Text>();
        UpdateTooFastText(false);
    }

    // Update score in text UI
    public void UpdateTooFastText(bool tooFast)
    {
        if (tooFast)
        {
            tooFastTexttUI.text = "You're going too fast!";
        }
        else
        {
            tooFastTexttUI.text = "";
        }
    }
}
