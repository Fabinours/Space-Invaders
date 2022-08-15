using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using SpaceInvaders;
using SpaceInvaders.Resources;

namespace SpaceInvaders
{
    class PlayerShip : Ship
    {
        /// <summary>
        /// PlayerShip constructor
        /// </summary>
        public PlayerShip() : base(Game.game.gameSize.Width/2,Game.game.gameSize.Height-(SpaceInvaders.Properties.Resources.PlayerShip.Size.Height*1.5)) { }
        public override void Update(Game gameInstance, double deltaT)
        {
            base.Update(gameInstance, deltaT);
            Move(gameInstance,deltaT);
            Shoot();
        }

        /// <summary>
        /// Move playership according to player controls
        /// </summary>
        private void Move(Game gameInstance, double deltaT)
        {
            // if space is pressed
            if (gameInstance.keyPressed.Contains(Keys.Left)){
                Vecteur2D newPosition = position + new Vecteur2D(-moveSpeed * deltaT, 0);
                if (!gameInstance.IsOutOfBounds(newPosition, size)){position = newPosition;}
            }
            if (gameInstance.keyPressed.Contains(Keys.Right)){
                Vecteur2D newPosition = position + new Vecteur2D(moveSpeed * deltaT, 0);
                if (!gameInstance.IsOutOfBounds(newPosition, size)){position = newPosition;} 
            }
        }

        /// <summary>
        /// Checks shoot possibilities
        /// </summary>
        public override void Shoot()
        {
            if (CanShoot())
            {
                Game gameInstance = Game.game;
                if (gameInstance.keyPressed.Contains(Keys.Space)){
                    base.Shoot();
                    // release key space (no autofire)
                    gameInstance.ReleaseKey(Keys.Space);
                }
            }
        }
    }
}
