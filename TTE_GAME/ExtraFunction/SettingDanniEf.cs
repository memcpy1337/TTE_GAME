using System;
using System.Collections.Generic;
using System.Text;

namespace TTE_GAME.ExtraFunction
{
    class SettingDanniEf
    {

        public static int[] SettingDanniBeseda(int id_Polzovatelya, int id_Pol_Beseda)
        {
            int[] Danni = { };
            if (id_Pol_Beseda >= 2000000000)
            {
                return Danni = new int[]
                {
                    id_Pol_Beseda,
                    id_Polzovatelya

                };
            }
            else
            {
                return Danni = new int[]
                {
                    id_Polzovatelya,
                    id_Polzovatelya
                };
            }
        }



    }
}
