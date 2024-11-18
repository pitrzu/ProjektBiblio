using WSB.Biblioteka.Contracts.Books;
using WSB.Biblioteka.Contracts.Books.Queries;
using WSB.Biblioteka.Contracts.Generics;
using WSB.Biblioteka.Core.Extensions;

namespace WSB.Biblioteka.Gui;

public class MockQueryHandler : IQueryHandler<GetAvailableBooksQuery, IReadOnlyCollection<AvailableBookResponse>>
{
    public Task<IReadOnlyCollection<AvailableBookResponse>> Handle(IQuery<IReadOnlyCollection<AvailableBookResponse>> request, CancellationToken cancellationToken)
    {
        var response = new List<AvailableBookResponse>()
        {
            new AvailableBookResponse(),
            new AvailableBookResponse(),
            new AvailableBookResponse(),
        };

        return Task.FromResult(response.AsReadOnlyCollection());
    }
}