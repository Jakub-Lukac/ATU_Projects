using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace June2019
{
    public class Claims
    {
        private List<Claim> _claimsList;
        private HashSet<string> _validClaims;

        private int[] _countPerCategory;
        private double[] _costPerCategory;
        public Claims(List<Claim> claims)
        {
            _countPerCategory = new int[] { };
            _costPerCategory = new double[] { };
            _validClaims = new HashSet<string>();
            _claimsList = claims;
        }

        public HashSet<string> GetValidClaims()
        {
            foreach (Claim c in _claimsList)
            {
                _validClaims.Add(c.ClaimType);
            }

            return _validClaims;
        }

        public int[] CountPerCategory()
        {
            int[] countPerCategory = new int[_validClaims.Count];

            for (int i = 0; i < _claimsList.Count; i++)
            {
                for (int j = 0; j < _validClaims.Count; j++)
                {
                    if (_claimsList.ToList()[i].ClaimType == _validClaims.ToList()[j])
                    {
                        countPerCategory[j]++;
                    }
                }
            }

            return countPerCategory;
        }


        public double[] CostPerCategory()
        {
            double[] costPerCategory = new double[_validClaims.Count];

            for (int i = 0; i < _claimsList.Count; i++)
            {
                for (int j = 0; j < _validClaims.Count; j++)
                {
                    if (_claimsList.ToList()[i].ClaimType == _validClaims.ToList()[j])
                    {
                        costPerCategory[j] += _claimsList.ToList()[i].Amount;
                    }
                }
            }

            return costPerCategory;
        }

        public double GetTotalClaimsCost()
        {
            double totalAmount = 0;
            foreach (Claim c in _claimsList)
            {
                totalAmount += c.Amount;
            }
            return totalAmount;
        }

        public void DisplayStatisticsTable()
        {
            Console.OutputEncoding = Encoding.UTF8;

            _validClaims = this.GetValidClaims();
            _countPerCategory = this.CountPerCategory();
            _costPerCategory = this.CostPerCategory();

            Table.InitTable(Table._stats);
            Console.WriteLine();

            for (int i = 0; i < _validClaims.Count; i++)
            {
                Console.WriteLine($"{_validClaims.ToList()[i],Table.MARGIN}{_countPerCategory[i],Table.MARGIN}{_costPerCategory[i]:c0}", Table.MARGIN);
            }

            Console.WriteLine($"\n{"Grand Totals", Table.MARGIN}{_claimsList.Count, Table.MARGIN}{this.GetTotalClaimsCost():c0}");
        }

        public List<Claim> ClaimsList { get => _claimsList; set => _claimsList = value; }
    }
}
