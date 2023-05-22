# Addressables
Unity has a system called Addressables which allows loading of a specified resource which has
been set up with an addressable identifier. It requires that any content loaded this way is
also unloaded, but it doesn't provide any easy functionality to do this in bulk.

The **AddressableCatalogue** is a wrapper that can create **GameObjects** by using an addressable
resource as a base, and keep track of what resources have been loaded so that they can be unloaded
when requested.

## Usage
The **AddressableCatalogue** must first be initialised. This is a singleton, so it only needs
to be done once - either when the game is first started, or whenever.

AddressableCatalogue.Initialise();

To create a **GameObject**, the catalogue takes the identifier for the addressable as well as
a **Vector3** position to place the object at. There are overloads for setting a **Transform**
as the parent object, or giving the rotation as a **Quaternion**. When setting a parent object,
the new object will instead use the given position as a **local position** from the parent.

If an addressable has already been loaded, it will not need to load again. If it has not been
loaded, it will be loaded **synchronously** (as opposed to the addressable system's use of async).

In each instance, the created GameObject is returned.

GameObject obj = AddressableCatalogue.CreateObject("MyAddressableId", Vector3.zero);
GameObject objWithParent = AddressableCatalogue.CreateObject("MyAddressableId", Vector3.zero, transform);
GameObject objWithRotation = AddressableCatalogue.CreateObject("MyAddressableId", Vector3.one, Quaternion.identity);

To unload all resources that have been loaded via the catalogue, they can be flushed.

AddressableCatalogue.Flush();