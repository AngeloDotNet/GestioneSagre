namespace GestioneSagre.DataAccess.Models.Services.Infrastructure;

public class LocalTransactionLogger : ITransactionLogger
{
    private readonly IHostingEnvironment env;
    private readonly SemaphoreSlim semaphore = new SemaphoreSlim(1);

    public LocalTransactionLogger(IHostingEnvironment env)
    {
        this.env = env;
    }

    public async Task LogTransactionFestaCreateAsync(FestaCreateInputModel inputModel)
    {
        string filePath = Path.Combine(env.ContentRootPath, "Data", "transactions.txt");
        string content = $"\r\n{inputModel.DataInizio}\t{inputModel.DataFine}\t{inputModel.Titolo}\t{inputModel.Edizione}\t{inputModel.Luogo}";

        CheckLogsFolderExist(filePath);

        try
        {
            await semaphore.WaitAsync();
            await File.AppendAllTextAsync(filePath, content);
        }
        finally
        {
            semaphore.Release();
        }
    }

    public async Task LogTransactionFestaEditAsync(FestaEditInputModel inputModel)
    {
        string filePath = Path.Combine(env.ContentRootPath, "Data", "transactions.txt");
        string content = $"\r\n{inputModel.DataInizio}\t{inputModel.DataFine}\t{inputModel.GuidFesta}\t{inputModel.Titolo}\t{inputModel.Edizione}\t{inputModel.Luogo}";

        CheckLogsFolderExist(filePath);

        try
        {
            await semaphore.WaitAsync();
            await File.AppendAllTextAsync(filePath, content);
        }
        finally
        {
            semaphore.Release();
        }
    }

    public async Task LogTransactionLogoEditAsync(LogoEditInputModel inputModel)
    {
        string filePath = Path.Combine(env.ContentRootPath, "Data", "transactions.txt");
        string content = $"\r\n{inputModel.GuidFesta}\t{inputModel.Logo.Name}";

        CheckLogsFolderExist(filePath);

        try
        {
            await semaphore.WaitAsync();
            await File.AppendAllTextAsync(filePath, content);
        }
        finally
        {
            semaphore.Release();
        }
    }

    public async Task LogTransactionVersioneCreateAsync(VersioneCreateInputModel inputModel)
    {
        string filePath = Path.Combine(env.ContentRootPath, "Data", "transactions.txt");
        string content = $"\r\n{inputModel.TestoVersione}";

        CheckLogsFolderExist(filePath);

        try
        {
            await semaphore.WaitAsync();
            await File.AppendAllTextAsync(filePath, content);
        }
        finally
        {
            semaphore.Release();
        }
    }

    private static void CheckLogsFolderExist(string filePath)
    {
        if (!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }
    }
}