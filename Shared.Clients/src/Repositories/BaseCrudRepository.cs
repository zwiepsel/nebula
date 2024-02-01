using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Nebula.Shared.Clients.Data;
using Nebula.Shared.Models;

namespace Nebula.Shared.Clients.Repositories;

public abstract class BaseCrudRepository<TViewModel, TIndexViewModel, TCreateModel, TUpdateModel> : BaseRepository
    where TViewModel : ViewModel
    where TIndexViewModel : ViewModel
    where TCreateModel : CreateModel
    where TUpdateModel : UpdateModel
{
    protected readonly string EntityBaseUri;

    protected BaseCrudRepository(IApi api, string entityBaseUri) : base(api)
    {
        EntityBaseUri = entityBaseUri;
    }

    public async Task<IList<TViewModel>> GetAll(CancellationToken cancellationToken = default)
    {
        return await Api.GetAsync<IList<TViewModel>>(EntityBaseUri, cancellationToken);
    }

    public async Task<IList<TIndexViewModel>> GetAllIndex(CancellationToken cancellationToken = default)
    {
        return await Api.GetAsync<IList<TIndexViewModel>>($"{EntityBaseUri}/index", cancellationToken);
    }

    public async Task<TViewModel> Get(int id, CancellationToken cancellationToken = default)
    {
        return await Api.GetAsync<TViewModel>($"{EntityBaseUri}/{id}", cancellationToken);
    }

    public async Task<TViewModel> Create(TCreateModel createModel, CancellationToken cancellationToken = default)
    {
        return await Api.PostAsync<TViewModel>(EntityBaseUri, createModel, cancellationToken);
    }

    public async Task<TViewModel> Update(TUpdateModel updateModel, CancellationToken cancellationToken = default)
    {
        return await Api.PutAsync<TViewModel>($"{EntityBaseUri}/{updateModel.Id}", updateModel, cancellationToken);
    }

    public async Task Delete(int id, CancellationToken cancellationToken = default)
    {
        await Api.DeleteAsync($"{EntityBaseUri}/{id}", cancellationToken);
    }
}