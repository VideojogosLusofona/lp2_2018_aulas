/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *
 * Author: Nuno Fachada 
 * */

using UnityEngine;
using UnityEngine.UI;

public class UpdateScoreUI : MonoBehaviour
{

    // Reference to the player agent
    private DynamicAgent player;
    // Reference to the text UI
    private Text textUI;

    // This is called before Start(), so set up this object here
    private void Awake()
    {
        // Keep reference to the text UI
        textUI = GetComponent<Text>();
        player = GameObject.FindWithTag("Player").GetComponent<DynamicAgent>();
        UpdateScoreText(0);
    }

    // This method is called when the object becomes enabled and active
    private void OnEnable()
    {
        player.ScoreUpdated += UpdateScoreText;
    }

    // This method is called when the behaviour becomes disabled
    private void OnDisable()
    {
        player.ScoreUpdated -= UpdateScoreText;
    }

    // Update score in text UI
    private void UpdateScoreText(int score)
    {
        textUI.text = $"Score: {score}";
    }
}
