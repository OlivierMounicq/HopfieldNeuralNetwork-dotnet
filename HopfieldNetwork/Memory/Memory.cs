using HopfieldNetwork.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopfieldNetwork.Memory
{
    public class Memory
    {
        private readonly IDictionary<string, Pattern> patternList;

        private Matrix weightMatrix;

        public Memory()
        {
            patternList = new Dictionary<string, Pattern>();
        }

        public void AddPattern(Pattern pattern)
        {
            if(this.patternList.ContainsKey(pattern.Name))
            {
                throw new Exception();
            }

            this.patternList.Add(pattern.Name, pattern);

            this.weightMatrix = this.weightMatrix + pattern.GetWeightMatrix();
        }

        public void DeletePattern(string patternName)
        {
            if (this.patternList.ContainsKey(patternName))
            {
                throw new Exception();
            }

            var patternToDelete = this.patternList[patternName];

            this.weightMatrix = this.weightMatrix - patternToDelete.GetWeightMatrix();

            this.patternList.Remove(patternName);
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
            var energy = patternVector * this.weightMatrix * patternVector.Transpose();

            return energy;
        }
    }
}
