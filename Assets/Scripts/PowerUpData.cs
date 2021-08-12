using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "PowerUp", menuName = "Data/New PowerUp")]
    public class PowerUpData : ScriptableObject
    {        
        [SerializeField] private float activeTime;
        [SerializeField] private int points;
        [SerializeField] private Vector2 size;
        
        public float ActiveTime => activeTime;
        public int Points => points;
        public Vector2 Size => size;
    }
