using HopfieldNetwork.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopfieldNetwork.Memory
{
    public class HopfieldMemory
    {
        private readonly IDictionary<string, Pattern> patternList;
       
        public Matrix WeightMatrix { get; private set; }

        public HopfieldMemory(int row, int col)
        {
            patternList = new Dictionary<string, Pattern>();
            var dim = row * col;
            this.WeightMatrix = new Matrix(new double[dim, dim], true);
        }

        public void AddPattern(Pattern pattern)
        {
            if(this.patternList.ContainsKey(pattern.Name))
            {
                throw new Exception();
            }

            this.patternList.Add(pattern.Name, pattern);

            this.WeightMatrix = this.WeightMatrix + pattern.GetWeightMatrix();
        }

        public void DeletePattern(string patternName)
        {
            if (!this.patternList.ContainsKey(patternName))
            {
                throw new Exception();
            }

            var patternToDelete = this.patternList[patternName];

            this.WeightMatrix = this.WeightMatrix - patternToDelete.GetWeightMatrix();

            this.patternList.Remove(patternName);
        }

        public Matrix GetNormalizedWeightMatrix()
        {
            var normalizedMatrix = new Matrix(this.WeightMatrix);
            normalizedMatrix.Normalize();

            return normalizedMatrix;
        }

        public Pattern RetrieveFromMemory(Pattern degradedPattern, int maxIteration)
        {
            //Compute the energy 
            var energy = this.GetEnergy(degradedPattern.GetVector());

            var pattern = degradedPattern;            

            for (var cpt = 0; cpt < maxIteration; cpt++)
            {
                //Modify the pattern
                var newRandomPattern = pattern.GetNewRandomPattern(string.Format("{0}:{1}", degradedPattern.Name, cpt.ToString()));

                //Compute the new energy
                var newEnergy = GetEnergy(newRandomPattern.GetVector());

                if(newEnergy < energy)
                {
                    newEnergy = energy;
                    pattern = newRandomPattern;
                }
            }

            return pattern;
        }

        internal double GetEnergy(RowVector patternVector)
        {
            var energy = patternVector * this.WeightMatrix * patternVector.Transpose();

            return energy;
        }
    }
}
