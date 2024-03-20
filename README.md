# Kailius_DLL_Injection
![image](https://github.com/Gaeduck-0908/Kailius_DLL_Injection/assets/82009667/e79181cf-d27d-4992-b3d5-f474016b1a35)

Original Game : https://github.com/Walkator/kailius

Injector : https://github.com/warbler/SharpMonoInjector

# DLL SourceCode
> Cheat.cs
```csharp
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
```
> Loader.cs
```csharp
namespace Kailius_Injection
{
    public class Loader
    {
        static UnityEngine.GameObject gameObject;

        public static void Load()
        {
            gameObject = new UnityEngine.GameObject();
            gameObject.AddComponent<Cheat>();
            UnityEngine.Object.DontDestroyOnLoad(gameObject);
        }

        public static void Unload()
        {
            UnityEngine.Object.Destroy(gameObject);
        }
    }
}
```
> .csproj
```csproj
<Deterministic>false</Deterministic>
```
> Inject
```bat
.\smi.exe inject -p Kailius -a C:\Users\user\Desktop\Projects\Unity_DLL_Injection\Kailius_Injection\bin\Release\Kailius_Injection.dll -n Kailius_Injection -c Loader -m Load
```
