using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public interface Interface1<T>
    {
        public T something { get; set; }

        public void Add(List<T> eenInterface);

        public string GetBest(List<T> participants);
    }
}
