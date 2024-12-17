using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024
{

    internal class Day7
    {
        private List<Calibration> Calibrations { get; set; }

        public Day7(string input)
        {
            Calibrations = new List<Calibration>();
            string[] lines = input.Split("\r\n");
            foreach(string line in lines)
            {
                if (String.IsNullOrEmpty(line)) continue;
                var inputs = line.Split(':');
                string result = inputs[0];
                string[] operands = inputs[1].Split(' ');
                Calibration calibration = new Calibration(result, operands.ToList());
                Calibrations.Add(calibration);
            }
        }

        public void Solve1()
        {
            long sumOfValidCalibrations = 0;
            foreach(Calibration calibration in Calibrations)
            {
                if (IsValidCalibration(calibration.Result, calibration.Operands))
                    sumOfValidCalibrations += calibration.Result;
            }
            Console.WriteLine(sumOfValidCalibrations);
        }

        public bool IsValidCalibration(long result, List<long> operands)
        {
            //base case
            if(operands.Count == 1)
            {
                return operands[0] == result;
            }
            //two branch recursion
            List<long> multipliedResult = new List<long>();
            multipliedResult.Add(operands[0] * operands[1]);
            List<long> multipliedOperands = operands.Skip(2).ToList();
            multipliedResult.AddRange(multipliedOperands);

            List<long> addResult = new List<long>();
            addResult.Add(operands[0] + operands[1]);
            List<long> addedOperands = operands.Skip(2).ToList();
            addResult.AddRange(addedOperands);

            List<long> concatResult = new List<long>();
            string concatStr = operands[0].ToString() + operands[1].ToString();
            concatResult.Add(long.Parse(concatStr));
            concatResult.AddRange(operands.Skip(2).ToList());

            return IsValidCalibration(result, multipliedResult) || IsValidCalibration(result, addResult) || IsValidCalibration(result, concatResult);
        }


        private class Calibration
        {
            public long Result { get; set; }
            public List<long> Operands { get; set; }
            public Calibration(string result, List<string> operands)
            {
                Result = long.Parse(result);
                Operands = new List<long>();
                foreach (var operand in operands)
                {
                    if (int.TryParse(operand, out int num))
                    {
                        Operands.Add(int.Parse(operand));
                    }
                }
            }
        }
    }
}
