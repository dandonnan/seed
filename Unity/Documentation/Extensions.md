# Extensions

## Controller Colours
**Seed** has a list of colours that it uses for changing the lightbar on DualShock 4 and DualSense controllers.
It is possible to convert these into colours for use in Unity.

Color color = ControllerColours.Green.ToColor();

## IEnumerable
If a random item in a list is required, it is possible to get it by calling an extension method.

int randomInt = new List<int> { 1, 2, 3, 4, 5 }.GetRandom();

## Input Actions
The "new" Unity Input System can check whether an input has been pressed. For cases where the next check would
be to get the **Vector2** value from the input, this has been merged into one method where a boolean is returned
as normal, but the vector is now given as an output.

if (input.WasPressedThisFrame(out Vector2 value)) { }

It is also possible to capture an input to prevent any further input checks against that action from returning
true for the rest of the frame. This functions the same way as WasPressedThisFrame, but resets the action.

if (input.WasCapturedThisFrame()) { }

## Strings
If a **Vector3** or **Quaternion** are represented as strings, new objects can be created using the values in
the string to set the properties. The strings must be in brackets and separated by commas.

Vector3 position = "(4,1,5)".ToVector3();
Quaternion rotation = "(2,3,1,2)".ToQuaternion();