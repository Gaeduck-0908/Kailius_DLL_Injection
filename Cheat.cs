using System;
using System.Reflection;
using UnityEngine;

namespace Kailius_Injection
{
    public class Cheat : UnityEngine.MonoBehaviour
    {
        private UnityEngine.GameObject Player;
        private UnityEngine.Component Stats;
        private Int32 hp;
        private void OnGUI()
        {
            Player = UnityEngine.GameObject.FindWithTag("Player");

            UnityEngine.Component[] Cmps = Player.GetComponentsInChildren<MonoBehaviour>(true);
            foreach (UnityEngine.Component comp in Cmps)
            {
                if (comp.GetType().Name == "Stats")
                {
                    Stats = comp;
                    FieldInfo[] fis = Stats.GetType().GetFields();
                    foreach (FieldInfo fi in fis)
                    {
                        if (fi.Name == "health")
                        {
                            hp = System.Convert.ToInt32(fi.GetValue(Stats));
                            if (hp != 1000)
                            {
                                fi.SetValue(Stats, 1000);
                            }
                        }
                    }
                }
            }
        }
    }
}
