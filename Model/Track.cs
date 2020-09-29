using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Track
    {
        public string Name { get; set; }
        public LinkedList<Section> Sections = new LinkedList<Section>();

        public Track(string name, SectionTypes[] sections)
        {
            this.Name = name;
            this.Sections = ArrayConvertLinkedList(sections);
        }

        public LinkedList<Section> ArrayConvertLinkedList(SectionTypes[] sectionTypes)
        {
            LinkedList<Section> helpingList = new LinkedList<Section>();
            for(int i = 0; i < sectionTypes.Length; i++)
            {
                Section sect = new Section(sectionTypes[i]);
                helpingList.AddLast(sect);
            }
            Console.WriteLine(helpingList);
            return helpingList;
        }




    }
    }

