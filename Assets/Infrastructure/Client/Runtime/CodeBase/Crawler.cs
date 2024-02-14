using System;

namespace MazeGeneration.Client.Runtime
{
    public class Crawler : Maze
    {
        protected override void Generate()
        {
            bool done = false;

            int x = 0;
            int z = _depthMax / 2;

            Random random = new Random();

            while (!done)
            {
                _map[x, z] = 0;

                if (random.Next(2) == 0)
                {
                    x += random.Next(0, 2);
                }
                else
                {
                    z += random.Next(-1, 2);
                }

                done |= x < 0 || x >= _widthMax || z < 0 || z >= _depthMax;
            }
        }
    }
}