using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.FileSystem;
using SharpGrip.FileSystem.Adapters;
using SharpGrip.FileSystem.Models;

namespace Nebula.Clients.APC.Apps.RMP.Api.Infrastructure.FileSystem;

public class FileSystem : IFileSystem
{
    private readonly SharpGrip.FileSystem.FileSystem fileSystem;
    private readonly IWebHostEnvironment webHostEnvironment;

    public FileSystem(IWebHostEnvironment webHostEnvironment)
    {
        this.webHostEnvironment = webHostEnvironment;

        var adapters = new List<IAdapter>
        {
            new LocalAdapter(IFileSystem.RisksPrefix, Path.Combine(webHostEnvironment.ContentRootPath, "var", "files", "risk"))
        };

        fileSystem = new SharpGrip.FileSystem.FileSystem(adapters);
    }

    public IList<IAdapter> Adapters
    {
        get => fileSystem.Adapters;
        set => fileSystem.Adapters = value;
    }

    public IAdapter GetAdapter(string prefix)
    {
        return fileSystem.GetAdapter(prefix);
    }

    public bool DirectoryExists(string path)
    {
        return fileSystem.DirectoryExists(path);
    }

    public void CreateDirectory(string path)
    {
        fileSystem.CreateDirectory(path);
    }

    public void CreateFile(string path, byte[] contents, bool overwrite = false)
    {
        fileSystem.WriteFile(path, contents, overwrite);
    }

    public IFile GetFile(string path)
    {
        return fileSystem.GetFile(path);
    }

    public string GetRelativePath(string path)
    {
        return GetFile(path).Path.Split(webHostEnvironment.WebRootPath).Last();
    }

    public string GetAbsolutePath(string path)
    {
        return GetFile(path).Path;
    }
}