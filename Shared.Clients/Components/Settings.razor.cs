using Nebula.Shared.Models;

namespace Nebula.Shared.Clients.Components;

public abstract partial class Settings<TViewModel, TCreateModal, TUpdateModal>
    where TViewModel : ViewModel
    where TCreateModal : Modal.Modal
    where TUpdateModal : Modal.Modal
{
}