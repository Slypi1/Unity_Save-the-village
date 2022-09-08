using System.Collections.Generic;
using UnityEngine;

public class TimerSystem : MonoBehaviour
{
    List<ITimer> timers = new List<ITimer>();
    public void AddTimer(ITimer timer)
    {
        timers.Add(timer);
    }
  void OnEnable()
  {
     CreateButton.Create—haracterbool += CreateTimer;
  }
  void OnDisable()
  {
     CreateButton.Create—haracterbool -= CreateTimer;
  }
  void CreateTimer(int activ)
  {
     if (activ == 0)
     {
       timers[0].Tick();
     }
     else timers[1].Tick();
  }
}
