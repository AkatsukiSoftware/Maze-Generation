using UnityEngine;
using Random = System.Random;

namespace MazeGeneration.Client.Runtime
{
    public class Maze : MonoBehaviour
    {
        [SerializeField] protected int _widthMax = default;
        [SerializeField] protected int _depthMax = default;

        [SerializeField] protected int _scaleUnit = default;

        [SerializeField] protected byte[,] _map = default;

        private void Awake()
        {
            _map = new byte[_widthMax, _depthMax];
        }

        private void Start()
        {
            InitialiseMap();
            Generate();
            DrawMap();
        }

        private void InitialiseMap()
        {
            //1 = wall
            //0 = corridor
            Random random = new Random();

            for (int z = 0; z < _depthMax; z++)
            {
                for (int x = 0; x < _widthMax; x++)
                {
                    _map[x, z] = 1;
                }
            }
        }

        protected virtual void Generate()
        {
            Random random = new Random();

            for (int z = 1; z < _depthMax - 1; z++)
            {
                for (int x = 1; x < _widthMax - 1; x++)
                {
                    _map[x, z] = (byte)random.Next(2);
                }
            }
        }

        private void DrawMap()
        {
            for (int z = 0; z < _depthMax; z++)
            {
                for (int x = 0; x < _widthMax; x++)
                {
                    if (_map[x, z] == 1)
                    {
                        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        cube.transform.localScale = new Vector3(_scaleUnit, _scaleUnit, _scaleUnit);
                        cube.transform.position = new Vector3(x * _scaleUnit, 0, z * _scaleUnit);
                    }
                }
            }
        }
    }
}