﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    class Program
    {
        static void Main(string[] args)
        {
            //sık kullanılır
            //bir metot içerisindeki farklı operasyonların bir şablon oluşturulup soyutlanması ve o soyuta somutların atanması işlemidir.
            ScoringAlgorithm algorithm;
            Console.WriteLine("Mans");
            algorithm = new MensScoringAlgorithm();
            Console.WriteLine(algorithm.GenerateScore(8, new TimeSpan(0, 2, 34)));

            Console.WriteLine("Women");
            algorithm = new WomenScoringAlgorithm();
            Console.WriteLine(algorithm.GenerateScore(8, new TimeSpan(0, 2, 34)));

            Console.WriteLine("Children");
            algorithm = new ChildrenScoringAlgorithm();
            Console.WriteLine(algorithm.GenerateScore(8, new TimeSpan(0, 2, 34)));


            Console.ReadLine();
        }
    }

    abstract class ScoringAlgorithm
    {
        public int GenerateScore(int hits,TimeSpan time)
        {
            int score = CalculateBaseScore(hits);
            int reduction = CalculateReduction(time);

            return CalculateOverallScore(score, reduction);
        }

        public abstract int CalculateOverallScore(int score, int reduction);
        public abstract int CalculateBaseScore(int hits);
        public abstract int CalculateReduction(TimeSpan time);
       
    }

    class MensScoringAlgorithm : ScoringAlgorithm
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 5;
        }
    }

    class ChildrenScoringAlgorithm : ScoringAlgorithm
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 3;
        }
    }

    class WomenScoringAlgorithm : ScoringAlgorithm
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 80;
        }

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 2;
        }
    }
}
