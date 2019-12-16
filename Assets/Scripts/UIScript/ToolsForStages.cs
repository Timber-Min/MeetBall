﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsForStages : MonoBehaviour
{
    private string[] toolsForStages = {
        "1-1", "",
        "1-2", "",
        "1-3", "",
        "1-4", "",
        "1-5", "",
        "1-6", "",
        "1-7", "",
        "1-8", "",
        "2-1", "Launcher,Accelerator",
        "2-2", "Launcher,Accelerator",
        "2-3", "Launcher,Accelerator",
        "2-4", "Launcher,Accelerator",
        "2-5", "Launcher,Accelerator",
        "2-6", "Launcher,Accelerator",
        "2-7", "Launcher,Accelerator",
        "2-8", "Launcher,Accelerator",
        "3-1", "Launcher,Accelerator",
        "3-2", "Launcher,VelocityResetter,VectorReverser,Accelerator",
        "3-3", "Launcher",
        "3-4", "Launcher,VelocityResetter,VectorReverser,Accelerator",
        "3-5", "Launcher",
        "3-6", "Launcher,VelocityResetter,VectorReverser,Accelerator",
        "3-7", "Launcher,VelocityResetter,VectorReverser,Accelerator",
        "3-8", "Launcher,VelocityResetter,VectorReverser,Accelerator",
        "4-1", "",
        "4-2", "Launcher,VelocityResetter,VectorReverser,Accelerator,Piston",
        "4-3", "Launcher",
        "4-4", "Launcher,VelocityResetter,VectorReverser,Accelerator,Piston",
        "4-5", "Piston",
        "4-6", "Piston,Accelerator",
        "4-7", "Piston,VelocityResetter,Launcher",
        "4-8", "Launcher,VelocityResetter,VectorReverser,Accelerator"
    };

    public string[] getToolsForStages()
    {
        return toolsForStages;
    }
}
