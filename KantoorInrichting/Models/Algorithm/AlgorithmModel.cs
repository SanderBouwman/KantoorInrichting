// created by: Robin
// on: 27-12-2015

using System;

namespace KantoorInrichting.Models.Algorithm
{
    public class AlgorithmModel {
        public string Name { get; set; }
        public Type Value { get; set; }

        public static AlgorithmModel CreateAlgorithm( string name, Type value ) {
            return new AlgorithmModel {
                Name = name,
                Value = value
            };
        }
    }
}