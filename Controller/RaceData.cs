using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Controller
{
    public class RaceData<T> : Interface1<T>
    {
        public T something { get; set; }
        private List<T> _list = new List<T>();
        public void AddList(T value)
        {
            _list.Add(value);
        }

        public void Add(List<T> stuff)
        {

        }

        public string GetBest(List<T> participants)
        {
            return "";
        }

        public string IfEmpty()
        {
            if(_list.Count < 1)
            {
                return "";
            }
            else
            {
                return "Deelnemer";
            }
        }

    }
}
