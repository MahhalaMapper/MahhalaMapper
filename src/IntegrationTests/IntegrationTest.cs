namespace MahhalaMapper.IntegrationTests;

public abstract class IntegrationTest<TInitializer> : MahhalaMapperSpecBase, IAsyncLifetime where TInitializer : IInitializer, new()
{
    System.Threading.Tasks.ValueTask IAsyncDisposable.DisposeAsync() => new System.Threading.Tasks.ValueTask();
    System.Threading.Tasks.ValueTask IAsyncLifetime.InitializeAsync() => new System.Threading.Tasks.ValueTask(new TInitializer().Migrate());
}
public interface IInitializer
{
    Task Migrate();
}
public class DropCreateDatabaseAlways<TContext> : IInitializer where TContext : DbContext, new()
{
    protected virtual void Seed(TContext context){}
    public async Task Migrate()
    {
        await using var context = new TContext();
        var database = context.Database;
        await database.EnsureDeletedAsync();
        var strategy = database.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () => await database.EnsureCreatedAsync());

        Seed(context);

        await context.SaveChangesAsync();
    }
}
public abstract class LocalDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(
        @$"Data Source=(localdb)\mssqllocaldb;Integrated Security=True;MultipleActiveResultSets=True;Database={GetType().Name}_{(uint)GetType().ToString().GetHashCode():X8};Connection Timeout=300",
        o => o.EnableRetryOnFailure(maxRetryCount: 10).CommandTimeout(120));
}
