using System;
using System.Collections.Generic;
using System.Text;

namespace Controller
{
    class RaceData<T>
    {

        private List<T> _list = new List<T>();

        public void AddList(T value)
        {
            _list.Add(value);
        }
    }
}
