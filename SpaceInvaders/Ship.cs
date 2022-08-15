using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using SpaceInvaders.Resources;
using System.Diagnostics;
using System.Windows.Forms;

namespace SpaceInvaders
{
    /// <summary>
    /// Ship abstract class 
    /// </summary>
    abstract class Ship : GameObject
    {
        #region Fields

        /// <summary>
        /// Missile shot from the ship
        /// </summary>
        private Missile missile;

        #endregion

        #region Constructor
        /// <summary>
        /// Simple Ship constructor
        /// </summary>
        /// <param name="x">start position x</param>
        /// <param name="y">start position y</param>
        public Ship(double x, double y) : base()
        {
            position = new Vecteur2D(x, y);
            Image = SpaceInvaders.Properties.Resources.PlayerShip;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Upadtes ship
        /// </summary>
        public override void Update(Game gameInstance, double deltaT)
        {
            if (gameInstance.IsOutOfBounds(position, size)) { Kill(); };
        }

        /// <summary>
        /// Checks shot possibilities
        /// </summary>
        public virtual bool CanShoot()
        {
            if (Game.game.IsInactive()) { return false; }
            if (IsAlive()){
                if (missile != null){
                    if (missile.IsAlive()){return false;}
                    missile = null;
                    return true;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Shoot if possible
        /// </summary>
        public virtual void Shoot()
        {
            if (CanShoot()){
                missile = new Missile(this);
                Game.game.AddNewGameObject(missile);
            }
        }
        #endregion
    }
}
