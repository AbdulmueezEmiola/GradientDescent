using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Linq;
namespace ClassLibrary1
{
    public class RelateTwoArrays
    {
        public List<Vector3> firstVector { get; set; }
        public List<Vector3> secondVector { get; set; }
        public RelateTwoArrays()
        {
            firstVector = new List<Vector3>();
            secondVector = new List<Vector3>();
        }
        public void RelateTwoTuples(List<Tuple<string, Vector3>> tuple1, List<Tuple<string, Vector3>> tuple2)
        {
            var tuple1Vector = tuple1.Select(x => x.Item2);
            var tuple2Vector = tuple2.Select(x => x.Item2);
            var scaledVector1 = StandardScaling.Scale(tuple1Vector);
            var scaledVector2 = StandardScaling.Scale(tuple2Vector).ToList();
            for (int i = 0; i < tuple1.Count; i++)
            {
                var value = GetCorrespondingPoints(scaledVector1.ElementAt(i), scaledVector2);
                firstVector.Add(tuple1Vector.ElementAt(i));
                int pos = scaledVector2.IndexOf(value);
                secondVector.Add(tuple2Vector.ElementAt(pos));
            }
            //int count = firstVector.Count;
            //interpolateLagrangeMany(tuple1.Where(x => x != null).Select(x=>x.Item2).ToList(), firstVector, secondVector,count);
            //interpolateLagrangeMany(tuple2.Where(x => x != null).Select(x => x.Item2).ToList(), secondVector, firstVector, count);
        }
        private Vector3 GetCorrespondingPoints(Vector3 vector, IEnumerable<Vector3> vectors)
        {
            double minimumDistance = Vector3.Distance(vector, vectors.ElementAt(0));
            Vector3 returnValue = vectors.ElementAt(0);
            foreach (Vector3 vector2 in vectors)
            {
                double temp = Vector3.Distance(vector, vector2);
                if (temp < minimumDistance)
                {
                    minimumDistance = temp;
                    returnValue = vector2;
                }
            }
            return returnValue;
        }
    }
}
