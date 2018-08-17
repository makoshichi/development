using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDbApp.Model
{
    // Developer note: There seems to be a lot of debate whether marker interfaces are a code smell or not, I simply used it in this project as a type parameter constraint for a generic method,
    // which is valid IMHO (it sure beats using "class" as constraint)
    interface IJsonModel
    {
        // Marker interface
    }
}
