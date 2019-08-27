namespace OfficeBall.Api
{
    public class OfficeBallDatabaseSettings : IOfficeBallDatabaseSettings
    {
        public string PlayersCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IOfficeBallDatabaseSettings
    {
        string PlayersCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}