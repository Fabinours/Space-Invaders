using SpaceInvaders.Resources;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public enum Enemy
    {
        SLUG,
        ZOLTAN,
        MANTIS,
        ROCK,
        LANIUS
    }
    
    class EnemyShip : Ship
    {
        /// <summary>
        /// Set an image for every enemy type
        /// </summary>
        private static Dictionary<Enemy, Bitmap> imagePerEnemy = new Dictionary<Enemy, Bitmap>(){
            { Enemy.MANTIS,SpaceInvaders.Properties.Resources.EnemyShip1},
            { Enemy.SLUG,SpaceInvaders.Properties.Resources.EnemyShip2},
            { Enemy.ROCK,SpaceInvaders.Properties.Resources.EnemyShip3},
            { Enemy.ZOLTAN,SpaceInvaders.Properties.Resources.EnemyShip4},
            { Enemy.LANIUS,SpaceInvaders.Properties.Resources.EnemyShip5}
        };

        /// <summary>
        /// Timer to shoot missiles
        /// </summary>
        private Timer shootTimer = new Timer();

        /// <summary>
        /// The shoot frequency of missiles
        /// </summary>
        private int shootFrequency = 75;

        /// <summary>
        /// The enemy type
        /// </summary>
        private Enemy type;

        /// <summary>
        /// The main enemyship constructor
        /// </summary>
        public EnemyShip(double x, double y, Enemy type) : base(x,y) {
            Image = imagePerEnemy[type];
            shootTimer.Tick += new EventHandler(ResetShootTimer);
            StartShootTimer();
            this.type = type;
        }

        /// <summary>
        /// Reset the shoot missiles timer
        /// </summary>
        private void ResetShootTimer(object sender, EventArgs e)
        {
            shootTimer.Stop();
            Shoot();
            StartShootTimer();
        }

        /// <summary>
        /// Starts the shoot missiles timer
        /// </summary>
        private void StartShootTimer()
        {
            shootTimer.Interval = Game.game.randomizer.Next(1, shootFrequency) * (Game.game.gameSize.Height - (int)position.Y);
            shootTimer.Start();
        }

        public void StopShootTimer()
        {
            shootTimer.Stop();
            shootTimer.Dispose();
        }

        /// <summary>
        /// Return the max enemyship size according to every type of enemy
        /// </summary>
        public static Size GetMaxEnemyShipSize()
        {
            Size max = new Size(0,0);
            foreach (Bitmap image in imagePerEnemy.Values)
            {
                if (image.Width > max.Width){max.Width = image.Width;}
                if (image.Height > max.Height){max.Height = image.Height;}
            }
            return max;
        }
    }
}
