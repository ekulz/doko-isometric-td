using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Main.Environment
{
    interface ITower
    {
        void Shoot();

        void Delete();

        void Upgrade();
    }
}
