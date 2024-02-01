using SharpGrip.FileSystem.Adapters;
using SharpGrip.FileSystem.Models;

namespace Nebula.Clients.APC.Apps.RMP.Api.Domain.FileSystem;

public interface IFileSystem
{
    public const string RisksPrefix = "risks";

    public IAdapter GetAdapter(string prefix);
    public bool DirectoryExists(string path);
    public void CreateDirectory(string path);
    public void CreateFile(string path, byte[] contents, bool overwrite = false);
    public IFile GetFile(string path);
    public string GetRelativePath(string path);
    public string GetAbsolutePath(string path);
}