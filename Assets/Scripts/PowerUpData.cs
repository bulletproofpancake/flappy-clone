using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "PowerUp", menuName = "Data/New PowerUp")]
    public class PowerUpData : ScriptableObject
    {        
        [SerializeField] private float activeTime;
        [SerializeField] private Vector2 size;
        [SerializeField] private int points;
        
        public float ActiveTime => activeTime;
        public Vector2 Size => size;
        public int Points => points;
    }
