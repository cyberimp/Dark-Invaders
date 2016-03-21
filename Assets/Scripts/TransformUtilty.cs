using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dark.Invaders
{
    class TransformUtilty
    {
        List<Transform> GetChildren(Transform trans, List<Transform> prevList)
        {
            List<Transform> newlist;
            if (prevList == null)
                newlist = new List<Transform>();
            else
                newlist = prevList;

            if (trans.GetComponentsInChildren<Transform>() == null)
                newlist.Add(trans);
            else
            {
                foreach (Transform child in trans.GetComponentsInChildren<Transform>())
                {
                    List<Transform> childList = GetChildren(child, newlist);
                    newlist = childList;
                }
            }

            return newlist;
        }
    }
}
