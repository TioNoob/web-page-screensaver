using System;
using System.Collections.Generic;

namespace Web_Page_Screensaver.Extension
{
    public static class ListExtension
    {
        public static List<E> Shuffle<E>(this List<E> list)
        {
            List<E> randomList = new List<E>();

            Random random = new Random();
            while (list.Count > 0)
            {
                int randomIndex = random.Next(0, list.Count);
                randomList.Add(list[randomIndex]);
                list.RemoveAt(randomIndex);
            }

            return randomList;
        }
    }
}
