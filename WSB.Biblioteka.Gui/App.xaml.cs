using System.Configuration;
using System.Data;
using System.Windows;
using MediatR;
using WSB.Biblioteka.Contracts.Books;
using WSB.Biblioteka.Contracts.Books.Queries;
using WSB.Biblioteka.Contracts.Generics;

namespace WSB.Biblioteka.Gui;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public readonly IMediator commandQueryMediator;

    public Task<IReadOnlyCollection<AvailableBookResponse>> GetBooks()
        => commandQueryMediator.Send(new GetAvailableBooksQuery());
}