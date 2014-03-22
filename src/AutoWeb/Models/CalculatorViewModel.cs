using System.Collections.Generic;

namespace MINI.Models
{
    public class BaseCalculatorViewModel
    {
        public BaseCalculatorViewModel()
        {
            Calculators = new List<CalculatorViewModel>();
        }
        public string Lang { get; set; }
        public double Price { get; set; }
        public string CACode { get; set; }
        public List<CalculatorViewModel> Calculators { get; set; }
    }

    public class CalculatorViewModel
    {
        public string FinanceOrLease { get; set; }
        public int Term { get; set; }
        public List<int> Terms { get; set; }
        public int KMYear { get; set; }
        public List<int> KMYears { get; set; }
        public double DownPayment { get; set; }
        public double MonthlyPayment { get; set; }
        public double InterestRate { get; set; }
    }
}