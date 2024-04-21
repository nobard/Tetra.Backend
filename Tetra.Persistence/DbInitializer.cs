namespace Tetra.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(RequestsDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
