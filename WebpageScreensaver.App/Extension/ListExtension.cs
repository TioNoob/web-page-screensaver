﻿using System;
using System.Collections.Generic;

namespace WebpageScreensaver.App.Extension
{
    public static class ListExtension
    {
        public static void Shuffle<E>(this List<E> list)
        {
            Random random = new Random();
            while (list.Count > 0)
            {
                int randomIndex = random.Next(0, list.Count);
                list.Add(list[randomIndex]);
                list.RemoveAt(randomIndex);
            }
        }
    }
}