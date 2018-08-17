namespace MovieDbApp.Model
{
    // Developer note: There seems to be some debate if marker interfaces are a valid aproach at all; I simply used it in this project as a type parameter constraint for a generic method,
    // which is valid IMHO (it sure beats using "class" as constraint). 
    interface IJsonModel
    {
        // Marker interface
    }
}
