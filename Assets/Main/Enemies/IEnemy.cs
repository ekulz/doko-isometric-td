using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Main.Enemies
{
    interface IEnemy
    {
        void MoveToFirstGridSpace();

        void MoveNext();

        void CurrentHealth();

        void Die();

        /// <summary>
        /// Call when enemy is blocked
        /// </summary>
        void Enrage(); 
    }
}
