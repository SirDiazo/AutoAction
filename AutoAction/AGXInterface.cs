﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using KSP.IO;
using System.Reflection;

namespace AutoAction
{
    class AGXInterface
    {
        public static bool AGExtInstalled()
        {
            try
            {
                Type calledType = Type.GetType("ActionGroupsExtended.AGExtExternal, AGExt");
                return (bool)calledType.InvokeMember("AGXInstalled", BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Static, null, null, null);
            }
            catch //if AGX not installed, above throws a null ref error, catch it
            {
                return false;
            }
        }
        public static void AGExtToggleGroup(int group)
        {
            Type calledType = Type.GetType("ActionGroupsExtended.AGExtExternal, AGExt");
            calledType.InvokeMember("AGXToggleGroup", BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Static, null, null, new System.Object[] { group });
        }
    }
}
