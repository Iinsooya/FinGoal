using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FinGoal.Models
{
    public class FinancialGoal
    {
        public string Title { get; set; }
        public decimal TargetAmount { get; set; }
        public decimal CurrentAmount { get; set; }
        public DateTime Deadline { get; set; }

        public double Progress => (double)(CurrentAmount / TargetAmount);
        public string Status => $"{Math.Min(Progress * 100, 100):F1}% достигнуто";
    }
}
