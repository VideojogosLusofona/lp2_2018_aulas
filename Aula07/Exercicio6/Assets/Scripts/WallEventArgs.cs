/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *
 * Author: Nuno Fachada
 * */

using System;

public class WallEventArgs : EventArgs
{
    // Property containing the wall that the player hit
    public string Wall { get; private set; }

    // Constructor, saves the wall that the player hit
    public WallEventArgs(string wall)
    {
        Wall = wall;
    }
}