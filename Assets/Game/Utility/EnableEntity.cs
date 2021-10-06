using System.Collections.Generic;
using UnityEngine;

namespace Game.Utility
{
    public class EnableEntity : MonoBehaviour
    {
        [SerializeField] private List<MonoBehaviour> listToDisable;

        public void EnableList()
        {
            for (int i = 0; i < listToDisable.Count; i++)
            {
                listToDisable[i].enabled = true;
            }
        }
    }
}
