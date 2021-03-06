﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace LangtonAnt
{
    class FieldPattern
    {
        public bool[,] Colored { get; private set; }
        public int Size { get; private set; }

        public FieldPattern(string fileName, int size)
        {
            string[] fileContent = null;
            try {
                fileContent = File.ReadAllLines(@fileName);
            } catch (IOException e) {
                // TODO
            } finally {
                Size = size;
                Colored = new bool[size, size];
            }

            Parallel.For(0, size, i => {
                Parallel.For(0, size, j => {
                    if (fileContent[i][j] == '1')
                        Colored[i, j] = true;
                    else
                        Colored[i, j] = false;
                });
            });
        }
    }
}
