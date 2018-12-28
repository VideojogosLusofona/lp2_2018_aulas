using System;
using MiniGameEngine;

namespace SmallGame
{
    // A script which controls the player, implemented as a component
    public class Player : Component
    {
        // Player script requries access to the key observer and position
        // components
        private KeyObserver keyObserver;
        private Position position;

        // Initialize player
        public override void Start()
        {
            keyObserver = ParentGameObject.GetComponent<KeyObserver>();
            position = ParentGameObject.GetComponent<Position>();
        }

        // Update player in the current frame
        public override void Update()
        {
            // Get player position
            float x = position.Pos.X;
            float y = position.Pos.Y;

            // Check what keys were pressed and update position accordingly
            foreach (ConsoleKey key in keyObserver.GetCurrentKeys())
            {
                switch (key) {
                    case ConsoleKey.UpArrow:
                        y -= 1;
                        break;
                    case ConsoleKey.DownArrow:
                        y += 1;
                        break;
                    case ConsoleKey.RightArrow:
                        x += 1;
                        break;
                    case ConsoleKey.LeftArrow:
                        x -= 1;
                        break;
                }
            }

            // Make sure player doesn't get outside of game area
            x = Math.Clamp(x, 0, ParentScene.xdim - 3);
            y = Math.Clamp(y, 0, ParentScene.ydim - 3);

            // Update player position
            position.Pos = new Vector3(x, y, position.Pos.Z);
        }
    }
}
