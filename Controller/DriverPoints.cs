using System;
using System.Collections.Generic;
using System.Text;

namespace Controller
{
    public class DriverPoints : RaceData<Dictionary<string, int>>
    {

        private List<Dictionary<string, int>> _list = new List<Dictionary<string, int>>();
        public void AddList(Dictionary<string, int> value)
        {
            _list.Add(value);
        }

        public void Add(List<int> stuff)
        {

        }

        public string GetMostPoints()
        {
            string name = "";
            int points = 0;
            foreach (Dictionary<string, int> dict in _list)
            {
                foreach (KeyValuePair<string, int> pp in dict)
                {
                    if (pp.Value > points)
                    {
                        points = pp.Value;
                        name = pp.Key;
                    }
                }
            }
            return name;
        }
    }
}
