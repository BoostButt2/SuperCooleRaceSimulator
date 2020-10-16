using System;
using System.Collections.Generic;
using System.Text;

namespace Controller
{
    public class DriverPlaces : RaceData<Dictionary<string, int>>
    {
        public int something { get; set; }
        private List<Dictionary<string, int>> _list = new List<Dictionary<string, int>>();
        public void AddList(Dictionary<string, int> value)
        {
            _list.Add(value);
        }

        public void Add(List<int> stuff)
        {

        }

        public string GetBestDriver()
        {
            string name = "";
            int place = 4;
            foreach(Dictionary<string, int> dict in _list)
            {
                foreach(KeyValuePair<string, int> pp in dict)
                {
                    if (pp.Value < place)
                    {
                        place = pp.Value;
                        name = pp.Key;
                    }
                }
            }
            return name;
        }
    }
}
