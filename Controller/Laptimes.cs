using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controller
{
    public class Laptimes : RaceData<Dictionary<string, TimeSpan>>
    {
        public int something { get; set; }
        private List<Dictionary<string, TimeSpan>> _list = new List<Dictionary<string, TimeSpan>>();
        public void AddList(Dictionary<string, TimeSpan> value)
        {
            _list.Add(value);
        }

        public void Add(List<int> stuff)
        {

        }

        public string GetFastest()
        {
            string name = "";
            List<TimeSpan> times = new List<TimeSpan>();
            TimeSpan time;
            foreach (Dictionary<string, TimeSpan> dict in _list)
            {
                foreach (KeyValuePair<string, TimeSpan> pp in dict)
                {
                    times.Add(pp.Value);
                }
            }

            time = times.Min();

            foreach (Dictionary<string, TimeSpan> dict in _list)
            {
                foreach (KeyValuePair<string, TimeSpan> pp in dict)
                {
                    if(pp.Value == time)
                    {
                        name = pp.Key;
                    }
                }
            }

            return name;
        }

    }
}
