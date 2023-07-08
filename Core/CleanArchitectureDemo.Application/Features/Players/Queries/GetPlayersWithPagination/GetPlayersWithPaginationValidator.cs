using FluentValidation;

namespace CleanArchitectureDemo.Application.Features.Players.Queries.GetPlayersWithPagination
{
    /// <summary>
    /// The GetPlayersWithPagination folder also has the following GetPlayersWithPaginationValidator 
    /// class that can be used to validate the input parameters of the query.
    /// </summary>
    public class GetPlayersWithPaginationValidator : AbstractValidator<GetPlayersWithPaginationQuery>
    {
        public GetPlayersWithPaginationValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1) 
                .WithMessage("PageNumber at least greater than or equal to 1.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1)
                .WithMessage("PageSize at least greater than or equal to 1.");
        }
    }
}
