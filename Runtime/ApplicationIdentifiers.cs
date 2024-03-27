using System;
using UnityEngine;

namespace IronMountain.AppIdentification
{
    [Serializable]
    public class ApplicationIdentifiers
    {
        [SerializeField] private string fallback;
        [SerializeField] private string iOS;
        [SerializeField] private string android;

        public string Fallback => fallback;
        public string IOS => !string.IsNullOrWhiteSpace(iOS) ? iOS : fallback;
        public string Android => !string.IsNullOrWhiteSpace(android) ? android : fallback;
        
        public bool Contains(string identifier)
        {
            return string.Equals(identifier, fallback)
                   || string.Equals(identifier, iOS)
                   || string.Equals(identifier, android);
        }
    }
}