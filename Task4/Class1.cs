namespace Task4
{
    public class LoanEvaluator
    {
        public string GetLoanEligibility(int income, bool hasJob, int creditScore, int dependents, bool ownsHouse)
        {
            if (income < 2000)
                return "Not Eligible";

            return hasJob
                ? EvaluateEmployed(creditScore, dependents, ownsHouse)
                : EvaluateUnemployed(income, creditScore, dependents, ownsHouse);
        }

        private string EvaluateEmployed(int creditScore, int dependents, bool ownsHouse)
        {
            if (creditScore >= 700)
                return EvaluateByDependents(dependents);
            else if (creditScore >= 600)
                return ownsHouse ? "Review Manually" : "Not Eligible";
            else
                return "Not Eligible";
        }

        private string EvaluateByDependents(int dependents)
        {
            if (dependents == 0)
                return "Eligible";
            else if (dependents <= 2)
                return "Review Manually";
            else
                return "Not Eligible";
        }

        private string EvaluateUnemployed(int income, int creditScore, int dependents, bool ownsHouse)
        {
            if (creditScore >= 750 && income > 5000 && ownsHouse)
                return "Eligible";
            else if (creditScore >= 650 && dependents == 0)
                return "Review Manually";
            else
                return "Not Eligible";
        }
    }
}