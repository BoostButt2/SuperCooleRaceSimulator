using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    //Er zijn nieuwe sectiontypes toegevoegd om het maken van een baan makkelijker te maken
    public enum SectionTypes
    {
        Straight,
        LeftCorner,
        SuperLeftCorner,
        RightCorner,
        SuperRightCorner,
        StartGrid,
        Finish,
        StraightVertical
    }
}
