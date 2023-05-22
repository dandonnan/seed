namespace Seed.Unity.Addressables
{
    using UnityEngine;
    using UnityEngine.ResourceManagement.AsyncOperations;

    public class AddressableCatalogueItem
    {
        public string Id { get; set; }

        public GameObject Object { get; set; }

        public AsyncOperationHandle Handle { get; set; }

        public bool PreventFlush { get; set; }
    }
}