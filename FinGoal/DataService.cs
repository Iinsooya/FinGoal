using FinGoal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

namespace FinGoal.Services
{
    public static class DataService
    {
        private const string FileName = "goals.json";

        public static List<FinancialGoal> LoadGoals()
        {
            if (File.Exists(FileName))
            {
                var json = File.ReadAllText(FileName);
                return JsonSerializer.Deserialize<List<FinancialGoal>>(json) ?? new List<FinancialGoal>();
            }
            return new List<FinancialGoal>();
        }

        public static void SaveGoals(List<FinancialGoal> goals)
        {
            var json = JsonSerializer.Serialize(goals);
            File.WriteAllText(FileName, json);
        }
    }
}
