using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Linq;
namespace ClassLibrary1
{
    public static class StandardScaling
    {

        public static IEnumerable<Vector3> Scale(IEnumerable<Vector3> vectors)
        {
            var xMean = vectors.Select(v => v.X).Average();
            var yMean = vectors.Select(v => v.Y).Average();
            var zMean = vectors.Select(v => v.Z).Average();
            var xVariance = CalculateVariance(vectors.Select(v => v.X), xMean);
            var yVariance = CalculateVariance(vectors.Select(v => v.Y), yMean);
            var zVariance = CalculateVariance(vectors.Select(v => v.Z), zMean);
            foreach (var vector in vectors)
            {
                var xNew = (vector.X - xMean) / xVariance;
                var yNew = (vector.Y - yMean) / yVariance;
                var zNew = (vector.Z - zMean) / zVariance;
                yield return new Vector3(xNew, yNew, zNew);
            }
        }
        public static float CalculateVariance(IEnumerable<float> values, float mean)
        {
            float sum = 0;
            foreach (var value in values)
            {
                sum += (float)Math.Pow((value - mean), 2);
            }
            return (float)Math.Sqrt(sum / values.Count());
        }
    }
}
