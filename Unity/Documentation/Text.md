# Text
Seed assumes the usage of Unity's localisation tools.

## Translations
To get a localised string from a string table, Get on **Translations**.

string text = Translations.Get("id");

It is possible to give a specific table.

string text = Translations.Get("table", "id");

## Formatted String
The **FormattedString** script can be applied to a **TextMeshPro** text to
replace the values in a formatted string e.g. "Press {0}".

When setting up the script on an object, set the id of the string to get from the string table
as the StringId. Assign the TextMeshPro text to the Text parameter.

Another script or piece of code can access the script to then pass in the values to use in replacement
of the temporary values.

For a singular value, there is the SetValue method.

SetValue("Start");

If there are multiple values, these can be set with SetValues instead.

SetValues("Hello", "There");