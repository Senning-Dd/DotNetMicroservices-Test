namespace DashboardService.Api.Queries
{
    public class GetTotalSalesQuery
    {
        public string ProductCode { get; set; }
        public DateTime SalesDateFrom { get; set; }
        public DateTime SalesDateTo { get; set; }
    }

    public class GetTotalSalesResult
    {
        public DashboardService.Api.Queries.Dtos.SalesSummaryDto Total { get; set; }
        public Dictionary<string, DashboardService.Api.Queries.Dtos.SalesSummaryDto> PerProductTotal { get; set; } = new();
    }

    public class GetAgentsSalesQuery
    {
        public DateTime SalesDateFrom { get; set; }
        public DateTime SalesDateTo { get; set; }
    }

    public class GetAgentsSalesResult
    {
        public Dictionary<string, DashboardService.Api.Queries.Dtos.SalesSummaryDto> PerAgentTotal { get; set; } = new();
    }

    public class GetSalesTrendsQuery
    {
        public DateTime SalesDateFrom { get; set; }
        public DateTime SalesDateTo { get; set; }
        public DashboardService.Api.Queries.Dtos.TimeUnit Unit { get; set; }
    }

    public class GetSalesTrendsResult
    {
        public List<DashboardService.Api.Queries.Dtos.PeriodSalesDto> PeriodsSales { get; set; } = new();
    }
}

namespace DashboardService.Api.Queries.Dtos
{
    public class SalesSummaryDto
    {
        public decimal PremiumAmount { get; set; }
        public long PoliciesCount { get; set; }
    }

    public class PeriodSalesDto
    {
        public string Period { get; set; }
        public SalesSummaryDto Sales { get; set; }
    }

    public enum TimeUnit
    {
        Month
    }
}

namespace PolicySearchService.Api.Queries
{
    public class FindPolicyResult
    {
        public List<PolicySearchService.Api.Queries.Dtos.PolicyDto> Policies { get; set; } = new();
    }
}

namespace PolicySearchService.Api.Queries.Dtos
{
    public class PolicyDto
    {
        public string PolicyNumber { get; set; }
        public string ProductCode { get; set; }
        public DateTime PolicyStartDate { get; set; }
        public DateTime PolicyEndDate { get; set; }
        public string PolicyHolder { get; set; }
        public decimal PremiumAmount { get; set; }
    }
}

namespace ProductService.Api.Queries.Dtos
{
    public class ProductDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public List<CoverDto> Covers { get; set; } = new();
        public List<QuestionDto> Questions { get; set; } = new();
    }

    public class CoverDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal SumInsured { get; set; }
    }

    public abstract class QuestionDto
    {
        public string QuestionCode { get; set; }
        public string Text { get; set; }
    }

    public class ChoiceQuestionDto : QuestionDto
    {
        public List<ChoiceDto> Choices { get; set; } = new();
    }

    public class NumericQuestionDto : QuestionDto
    {
    }

    public class ChoiceDto
    {
        public string Code { get; set; }
        public string Label { get; set; }
    }
}

namespace PolicyService.Api.Commands
{
    public class CreateOfferCommand
    {
        public string ProductCode { get; set; }
        public DateTime PolicyFrom { get; set; }
        public DateTime PolicyTo { get; set; }
        public List<string> SelectedCovers { get; set; } = new();
        public List<PolicyService.Api.Commands.Dtos.QuestionAnswer> Answers { get; set; } = new();
    }

    public class CreateOfferResult
    {
        public string OfferNumber { get; set; }
        public decimal TotalPrice { get; set; }
    }

    public class CreatePolicyCommand
    {
        public string OfferNumber { get; set; }
        public PolicyService.Api.Commands.Dtos.PersonDto PolicyHolder { get; set; }
        public PolicyService.Api.Commands.Dtos.AddressDto PolicyHolderAddress { get; set; }
    }

    public class CreatePolicyResult
    {
        public string PolicyNumber { get; set; }
    }
}

namespace PolicyService.Api.Commands.Dtos
{
    public class PersonDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TaxId { get; set; }
    }

    public class AddressDto
    {
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }

    public enum QuestionType
    {
        Numeric,
        Choice
    }

    public abstract class QuestionAnswer
    {
        public string QuestionCode { get; set; }
        public abstract QuestionType QuestionType { get; }
    }

    public class ChoiceQuestionAnswer : QuestionAnswer
    {
        public string Answer { get; set; }
        public override QuestionType QuestionType => QuestionType.Choice;
    }

    public class NumericQuestionAnswer : QuestionAnswer
    {
        public decimal Answer { get; set; }
        public override QuestionType QuestionType => QuestionType.Numeric;
    }
}

namespace PolicyService.Api.Queries
{
    public class GetPolicyDetailsQueryResult
    {
        public PolicyService.Api.Queries.Dtos.PolicyDto Policy { get; set; }
    }
}

namespace PolicyService.Api.Queries.Dtos
{
    public class PolicyDto
    {
        public string Number { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string PolicyHolder { get; set; }
        public decimal TotalPremium { get; set; }
        public string ProductCode { get; set; }
        public List<string> Covers { get; set; } = new();
    }
}
