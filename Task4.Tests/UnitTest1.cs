using Task4;
using Xunit;

namespace Task4.Tests
{
    public class LoanEvaluatorTests
    {
        [Fact]
        public void IncomeLessThan2000_ShouldReturnNotEligible()
        {
            var evaluator = new LoanEvaluator();
            var result = evaluator.GetLoanEligibility(1500, true, 750, 0, true);
            Assert.Equal("Not Eligible", result);
        }

        [Fact]
        public void Employed_HighCredit_NoDependents_ShouldReturnEligible()
        {
            var evaluator = new LoanEvaluator();
            var result = evaluator.GetLoanEligibility(3000, true, 720, 0, false);
            Assert.Equal("Eligible", result);
        }

        [Fact]
        public void Employed_HighCredit_TwoDependents_ShouldReturnReviewManually()
        {
            var evaluator = new LoanEvaluator();
            var result = evaluator.GetLoanEligibility(4000, true, 720, 2, false);
            Assert.Equal("Review Manually", result);
        }

        [Fact]
        public void Employed_MidCredit_OwnsHouse_ShouldReturnReviewManually()
        {
            var evaluator = new LoanEvaluator();
            var result = evaluator.GetLoanEligibility(4000, true, 650, 1, true);
            Assert.Equal("Review Manually", result);
        }

        [Fact]
        public void Unemployed_HighIncome_HighCredit_OwnsHouse_ShouldReturnEligible()
        {
            var evaluator = new LoanEvaluator();
            var result = evaluator.GetLoanEligibility(6000, false, 760, 1, true);
            Assert.Equal("Eligible", result);
        }

        [Fact]
        public void Unemployed_MidCredit_NoDependents_ShouldReturnReviewManually()
        {
            var evaluator = new LoanEvaluator();
            var result = evaluator.GetLoanEligibility(4000, false, 660, 0, false);
            Assert.Equal("Review Manually", result);
        }

        [Fact]
        public void Unemployed_LowCredit_ShouldReturnNotEligible()
        {
            var evaluator = new LoanEvaluator();
            var result = evaluator.GetLoanEligibility(5000, false, 500, 0, true);
            Assert.Equal("Not Eligible", result);
        }
    }
}