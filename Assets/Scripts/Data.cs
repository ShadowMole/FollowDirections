﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Data
{
    private static int difficulty;

    public static int Difficulty
    {
        get
        {
            return difficulty;
        }
        set
        {
            difficulty = value;
        }
    }
}
