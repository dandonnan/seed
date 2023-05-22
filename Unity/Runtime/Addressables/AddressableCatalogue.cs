namespace Seed.Unity.Addressables
{
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.AddressableAssets;
    using UnityEngine.ResourceManagement.AsyncOperations;

    public class AddressableCatalogue
    {
        private static AddressableCatalogue instance;

        private Dictionary<string, AddressableCatalogueItem> loadedObjects;

        private AddressableCatalogue()
        {
            instance = this;

            loadedObjects = new Dictionary<string, AddressableCatalogueItem>();
        }

        public static void Initialise()
        {
            if (instance == null)
            {
                new AddressableCatalogue();
            }
        }

        public static GameObject CreateObject(string id, Vector3 position)
        {
            return CreateObject(id, position, Quaternion.identity);
        }

        public static GameObject CreateObject(string id, Vector3 position, Transform parent)
        {
            AddressableCatalogueItem item = LoadAsset(id);

            GameObject obj = GameObject.Instantiate(item.Object, parent, false);

            obj.transform.localPosition = position;

            return obj;
        }

        public static GameObject CreateObject(string id, Vector3 position, Quaternion rotation)
        {
            AddressableCatalogueItem item = LoadAsset(id);

            return GameObject.Instantiate(item.Object, position, rotation);
        }

        public static void Flush()
        {
            IEnumerable<AddressableCatalogueItem> items = instance.loadedObjects.Values.Where(o => o.PreventFlush == false);

            List<string> itemsToFlush = new List<string>();

            foreach (AddressableCatalogueItem item in items)
            {
                Addressables.Release(item.Handle);
                itemsToFlush.Add(item.Id);
            }

            itemsToFlush.ForEach(i => instance.loadedObjects.Remove(i));
        }

        private static AddressableCatalogueItem LoadAsset(string id, bool preventFlush = false)
        {
            if (instance.loadedObjects.TryGetValue(id, out AddressableCatalogueItem item) == false)
            {
                AsyncOperationHandle<GameObject> handle = Addressables.LoadAssetAsync<GameObject>(id);

                handle.WaitForCompletion();

                item = new AddressableCatalogueItem
                {
                    Id = id,
                    Object = handle.Result,
                    Handle = handle,
                    PreventFlush = preventFlush,
                };

                instance.loadedObjects.Add(id, item);
            }

            return item;
        }
    }
}